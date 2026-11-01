using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
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

namespace FrostyStandaloneInstaller.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void MainMenu_Modify_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate();
            MainMenu_Uninstall.Content = App.ResourceManager.GetString("OK");
            MainMenu_Modify.Content = CultureInfo.InstalledUICulture;
        }

        private void MainMenu_Uninstall_Click(object sender, RoutedEventArgs e)
        {
            if (App.Tasks is null)
            {
                App.Tasks = new();
            }
            Task Uninstall = new Task(() =>
            {
                //code
            });

            App.Tasks.Add();

            TaskPage taskPage = new();
            NavigationService.Navigate(taskPage);
        }

        private void MainMenu_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private Task TestTask(Progress<double> progress, Progress<string> status)
        {
            try
            {
                App.TaskStatus.Report("_title\\Test Task VVV");
                App.TaskStatus.Report("Test Status VVV");
                App.TaskProgress.Report(0.0);
                Thread.Sleep(1);

                App.TaskStatus.Report("_title\\Test Task VVVVVV");
                App.TaskStatus.Report("Test Status VVVVVV");
                App.TaskProgress.Report(14);
                Thread.Sleep(1);

                App.TaskStatus.Report("_title\\Test Task Complete");
                App.TaskStatus.Report("Test Status Complete");
                App.TaskProgress.Report(100.0);
                Thread.Sleep(1);
            }
            catch (NullReferenceException)
            {
            }
            return Task.CompletedTask;
        }
    }
}
