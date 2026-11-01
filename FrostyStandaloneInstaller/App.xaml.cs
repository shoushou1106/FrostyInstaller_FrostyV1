using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System;
using Microsoft.Extensions.Logging;
using System.Windows.Controls;

namespace FrostyStandaloneInstaller
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static List<Task>? _tasks;
        private static IProgress<double>? _taskProgress;
        private static IProgress<string>? _taskStatus;

        public static List<Task>? Tasks { get => _tasks; set => _tasks = value; }
        public static IProgress<double>? TaskProgress { get => _taskProgress; set => _taskProgress = value; }
        public static IProgress<string>? TaskStatus { get => _taskStatus; set => _taskStatus = value; }

        private static List<string> _languages = new();
        private static ResourceManager _resourceManager = new ResourceManager("FrostyStandaloneInstaller.Localization.Loc", Assembly.GetExecutingAssembly());

        public static List<string> Languages { get => _languages; set => _languages = value; }
        public static ResourceManager ResourceManager { get => _resourceManager; set => _resourceManager = value; }
    }
}
