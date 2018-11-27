using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
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
        }

        private void LoadNamedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = new Configuration { BasePath = BaseAddressTextBox.Text };
                var doorJobsApi = new DoorJobsApi(config);

                var result = doorJobsApi.RestApiV1DoorjobsSearchPost(new SearchDoorJobsParameters(Name: JobNameTextBox.Text));

                if (result.Results == null || result.Results.Count == 0)
                {
                    throw new Exception("Door job with name given not found");
                }

                if (result.Results.Count > 1)
                {
                    throw new Exception($"Multiple jobs ({result.Results.Count}) with the same name were found");
                }

                var editorApi = new EditorApi(config);
                editorApi.RestApiV1EditorDoorjobPut(new LoadDoorJobIntoEditorParameters(Id: result.Results.First().Id));

                ResponseTextBox.Text = "Sucesss";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }

        private void LoadPremadeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = new Configuration { BasePath = BaseAddressTextBox.Text };
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

                var editorApi = new EditorApi(config);
                var parameters = new UploadDoorJobIntoEditorParameters(job);
                editorApi.RestApiV1EditorDoorjobUploadPut(parameters);

                ResponseTextBox.Text = "Sucesss";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }
    }
}
