using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KvalCAMAPIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        private async void LoadNamedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Use the base path set for connecting using the API
                var api = new KvalCAMApi(BaseAddressTextBox.Text);
                // Get the job
                var result = await api.GetDoorJobByName(JobNameTextBox.Text);
                await api.UploadDoorJobToEditor(result);

                ResponseTextBox.Text = $"Success, loaded job: {JobNameTextBox.Text}";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }

        private async void LoadCodeCreatedJobButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Creating a job purely from code
                // NOTE: Any property not set will be left blank when loaded into KvalCAM
                var job = new JObject
                {
                    ["Name"] = "Job1",
                    ["Description"] = "This is a job from the API",
                    ["DoorData"] = JsonObjectFactory.CreateDoorData("80", "36", "1.75"),

                    ["FeatureGroups"] = new JArray
                    {
                        new JObject
                        {
                            ["Name"] = "Group1",
                            ["Locations"] = new JArray
                            {
                                JsonObjectFactory.CreateFeatureGroupLocation("36", "0", "0"),
                                JsonObjectFactory.CreateFeatureGroupLocation("45", "0", "0")
                            },
                            ["Children"] = new JArray
                            {
                                JsonObjectFactory.CreateCircle("Circle1", "Lock", "0", "0", "$door.thickness/2", "3/4", "1"),
                                JsonObjectFactory.CreateCircle("Circle2", "Lock", "3", "0", "$door.thickness/2", "1.25", "0.2")
                            }
                        }
                    }
                };

                // Use the base path set for connecting using the API
                var api = new KvalCAMApi(BaseAddressTextBox.Text);
                // Load the job into the editor
                await api.UploadDoorJobToEditor(job);

                ResponseTextBox.Text = "Sucessfully loaded job created in code";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }

        // Gets a feature group from the library by name using the search API call
        private async Task<JObject> GetFeatureGroupByName(string name)
        {
            var api = new KvalCAMApi(BaseAddressTextBox.Text);
            var result = await api.GetFeatureGroupByName(name);

            if (result == null)
            {
                throw new Exception($"FeatureGroup with name \"{name}\" not found");
            }

            return result;
        }

        // Gets a door job from the library by name using the search API call
        private async Task<JObject> GetDoorJobByName(string name)
        {
            var api = new KvalCAMApi(BaseAddressTextBox.Text);
            var result = await api.GetDoorJobByName(name);

            if (result == null)
            {
                throw new Exception($"DoorJob with name \"{name}\" not found");
            }

            return result;
        }

        private async void LoadComposedJobButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Creating a job by querying existing feature groups and attaching them to an existing job

                // This is the door job name to be attached to (must exist in the job library)
                var doorJobName = "DoorJob1";

                // These are the feature group names to be attached to the job (must exist in the feature groups library)
                var featureGroupNames = new List<string>
                {
                    "FeatureGroup1",
                    "FeatureGroup2"
                };

                // Get the job
                var job = await GetDoorJobByName(doorJobName);

                var featureGroups = new JArray();
                foreach (var fgName in featureGroupNames)
                {
                    var fg = await GetFeatureGroupByName(fgName);
                    featureGroups.Add(fg);
                }

                // Set the feature groups on the job
                job["FeatureGroups"] = featureGroups;

                // Load the composed job into the editor
                var api = new KvalCAMApi(BaseAddressTextBox.Text);
                await api.UploadDoorJobToEditor(job);

                var responseSb = new StringBuilder();
                responseSb.AppendLine($"Sucessfully loaded job: {doorJobName} with the following feature groups attached:");

                foreach (var fgName in featureGroupNames)
                {
                    responseSb.AppendLine(fgName);
                }

                ResponseTextBox.Text = responseSb.ToString();
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }

        }

        private readonly SerialPort _serialPort;
        private void ListenToSerialPortCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var responseSb = new StringBuilder();
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }


                if (ListenToSerialPortCheckBox.IsChecked.HasValue && ListenToSerialPortCheckBox.IsChecked.Value)
                {
                    responseSb.AppendLine("Attemping to listen to serial port...");
                    responseSb.AppendLine("Port names found:");
                    foreach (var portName in SerialPort.GetPortNames())
                    {
                        responseSb.AppendLine(portName);
                    }

                    var baudRate = 9600;
                    responseSb.AppendLine($"Listening to port with baud rate: {baudRate}, port name: {COMPortTextBox.Text}");
                    _serialPort.PortName = COMPortTextBox.Text;
                    _serialPort.BaudRate = 9600;
                    _serialPort.ReadTimeout = 1000;
                    _serialPort.Open();
                }
                else
                {
                    responseSb.AppendLine("Stopped listening to serial port");
                }

                ResponseTextBox.Text = responseSb.ToString();

            }
            catch (Exception ex)
            {
                responseSb.AppendLine($"Error: {ex.Message}");
                ResponseTextBox.Text = responseSb.ToString();
            }

        }

        private void COMPortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListenToSerialPortCheckBox.IsChecked = false;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var input = _serialPort.ReadLine().Trim();

                Dispatcher.BeginInvoke((Action)(async () =>
                {
                    try
                    {
                        var api = new KvalCAMApi(BaseAddressTextBox.Text);
                        var job = await GetDoorJobByName(input);

                        await api.UploadDoorJobToEditor(job);

                        ResponseTextBox.Text = $"Loaded job: {input} from serial port read";
                    }
                    catch (Exception ex)
                    {

                        ResponseTextBox.Text = $"Error: {ex.Message}";
                    }
                }
            ));
            }
            catch (TimeoutException)
            {
                Dispatcher.BeginInvoke((Action)(() => ResponseTextBox.Text = "Serial port read timed out!"));
            }
        }
    }
}
