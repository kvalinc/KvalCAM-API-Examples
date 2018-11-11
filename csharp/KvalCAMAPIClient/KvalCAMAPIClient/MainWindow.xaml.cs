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

        private void Button_Click(object sender, RoutedEventArgs e)
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

                var editorApi = new EditorApi(config);
                editorApi.RestApiV1EditorDoorjobPut(new LoadDoorJobIntoEditorParameters(Id: result.Results.First().Id));

                ResponseTextBox.Text = "Sucesss";
            }
            catch (Exception ex)
            {
                ResponseTextBox.Text = $"Error: {ex.Message}";
            }
        }
    }
}
