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
                // Use the base path set for connecting using the API
                var config = new Configuration { BasePath = BaseAddressTextBox.Text };

                // Get the job
                var result = GetDoorJobByName(JobNameTextBox.Text, config);

                // Load the job into the editor
                var editorApi = new EditorApi(config);
                editorApi.RestApiV1EditorDoorjobPut(new LoadDoorJobIntoEditorParameters(Id: result.Id));

                ResponseTextBox.Text = "Sucesss";
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

                ResponseTextBox.Text = "Sucesss";
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

                ResponseTextBox.Text = "Sucesss";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }

        }
    }
}
