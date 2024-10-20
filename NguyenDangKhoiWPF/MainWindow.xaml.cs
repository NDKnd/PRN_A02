using BLLs;
using BusinessObjecst;
using Microsoft.Extensions.Configuration;
using System.IO;
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

namespace NguyenDangKhoiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService icustomerService;
        private readonly IConfiguration config;
        public MainWindow()
        {
            InitializeComponent();
            icustomerService = new CustomerService();
            config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var pass = txtPass.Password;

            var adminUser = config["AdminAccount:Email"];
            var adminPassword = config["AdminAccount:Password"];
            var adminName = config["AdminAccount:Name"];

            if (email !=  null && pass != null)
            {
                if(email == adminUser && pass.Equals(adminPassword))
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Hide();
                }
                else
                {
                    Customer cus = icustomerService.Login(email, pass);
                    if (cus != null)
                    {
                        CustomerWindow cusWindow = new CustomerWindow();
                        cusWindow.Show();
                        this.Hide();
                    }
                    
                }

            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}