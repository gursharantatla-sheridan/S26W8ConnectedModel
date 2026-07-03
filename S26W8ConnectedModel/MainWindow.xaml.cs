using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace S26W8ConnectedModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // read conn str from App.config file
        string connStr = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(connStr);

            string query = "select * from Employees";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable tbl = new DataTable();
            tbl.Load(reader);
            grdEmployees.ItemsSource = tbl.DefaultView;

            conn.Close();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}