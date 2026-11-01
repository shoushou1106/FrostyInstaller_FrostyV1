using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FrostyStandaloneInstaller.Pages
{
    /// <summary>
    /// Interaction logic for TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        public TaskPage()
        {
            InitializeComponent();
            RunTasks();
        }

        private async void RunTasks()
        {
            if (App.Tasks is not null)
            {
                double totalProgress = 0.0;
                App.TaskProgress = new Progress<double>(progress =>
                {
                    CurrentTaskProgressBar.Value = progress;
                    if (progress == 100.0) 
                    {
                        totalProgress += progress / App.Tasks.Count;
                        TotalTaskProgressBar.Value = totalProgress;
                    }
                    else
                    {
                        TotalTaskProgressBar.Value = totalProgress + (progress / App.Tasks.Count);
                    }
                });
                App.TaskStatus = new Progress<string>(status =>
                {
                    if (status.StartsWith("_title\\"))
                    {
                        status.Remove(0, 7);
                        CurrentTaskTitle.Content = status;
                    }
                    else
                    {
                        CurrentTaskStatus.Content = status;
                    }
                });

                await Task.WhenAll(App.Tasks);

                CurrentTaskStatus.Content = "finish";
            }
        }
    }
}
