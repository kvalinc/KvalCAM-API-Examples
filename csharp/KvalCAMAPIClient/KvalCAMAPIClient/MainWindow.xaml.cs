using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
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

        private void LoadNamedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Use the base path set for connecting using the API
                var config = new Configuration { BasePath = BaseAddressTextBox.Text };

                // Get the job
                var result = GetDoorJobByName(JobNameTextBox.Text, config);

                // Load the job into the editor
                var editorApi = new EditorApi(config);
                editorApi.RestApiV1EditorDoorjobPut(new LoadDoorJobIntoEditorParameters(Id: result.Id));

                ResponseTextBox.Text = $"Success, loaded job: {JobNameTextBox.Text}";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }

        private void LoadCodeCreatedJobButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Use the base path set for connecting using the API
                var config = new Configuration { BasePath = BaseAddressTextBox.Text };

                // Creating a job purely from code
                // NOTE: Any property not set will be left blank when loaded into KvalCAM

                var job = new DoorJob
                {
                    Name = "Job1",
                    Description = "This is a job from the API",
                    DoorData = new DoorData(Length: "80", Width: "36", Thickness: "1.5"),
                    FeatureGroups = new List<FeatureGroup>
                    {
                        new FeatureGroup
                        {
                            Name = "Group1",
                            Locations = new List<LWTLocation>
                            {
                                new LWTLocation(LLocation: "36", WLocation: "0", TLocation: "0"),
                                new LWTLocation(LLocation: "45", WLocation: "0", TLocation: "0"),
                            },

                            Children = new List<AbstractFeature>
                            {
                                new Circle(
                                    LLocation: "0",
                                    WLocation: "0",
                                    TLocation: "$door.thickness/2",
                                    Bevel: "0",
                                    Depth: "1",
                                    Diameter: "3/4",
                                    DiameterMinimum: "Diameter",
                                    DiameterMaximum: "Diameter",
                                    DepthMinimum: "Depth",
                                    DepthMaximum: "Depth")
                            }
                        }
                    }
                };

                // Load the job into the editor
                var editorApi = new EditorApi(config);
                var parameters = new UploadDoorJobIntoEditorParameters(job);
                editorApi.RestApiV1EditorDoorjobUploadPut(parameters);

                ResponseTextBox.Text = "Sucessfully loaded job created in code";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }

        // Gets a feature group from the library by name using the search API call
        private FeatureGroup GetFeatureGroupByName(string name, Configuration config)
        {
            var featureGroupsApi = new FeatureGroupsApi(config);

            var result = featureGroupsApi.RestApiV1FeaturegroupsSearchPost(new SearchFeatureGroupsParameters(Name: name));

            if (result.Results == null || result.Results.Count == 0)
            {
                throw new Exception($"FeatureGroup with name \"{name}\" not found");
            }

            if (result.Results.Count > 1)
            {
                throw new Exception($"Multiple feature groups with the name \"{name}\" were found");
            }

            return result.Results.First();
        }

        // Gets a door job from the library by name using the search API call
        private DoorJob GetDoorJobByName(string name, Configuration config)
        {
            var doorJobsApi = new DoorJobsApi(config);
            var result = doorJobsApi.RestApiV1DoorjobsSearchPost(new SearchDoorJobsParameters(Name: name));

            if (result.Results == null || result.Results.Count == 0)
            {
                throw new Exception($"DoorJob with name \"{name}\" not found");
            }

            if (result.Results.Count > 1)
            {
                throw new Exception($"Multiple door jobs with the name \"{name}\" were found");
            }

            return result.Results.First();
        }

        private void LoadComposedJobButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Use the base path set for connecting using the API
                var config = new Configuration { BasePath = BaseAddressTextBox.Text };

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
                var job = GetDoorJobByName(doorJobName, config);

                // Get the feature groups
                var featureGroups = featureGroupNames.Select(name => GetFeatureGroupByName(name, config)).ToList();

                // Set the feature groups on the job
                job.FeatureGroups = featureGroups;

                // Load the composed job into the editor
                var editorApi = new EditorApi(config);
                var parameters = new UploadDoorJobIntoEditorParameters(job);
                editorApi.RestApiV1EditorDoorjobUploadPut(parameters);

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

                Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        var config = new Configuration { BasePath = BaseAddressTextBox.Text };
                        var job = GetDoorJobByName(input, config);

                        var editorApi = new EditorApi(config);
                        var parameters = new UploadDoorJobIntoEditorParameters(job);
                        editorApi.RestApiV1EditorDoorjobUploadPut(parameters);

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
