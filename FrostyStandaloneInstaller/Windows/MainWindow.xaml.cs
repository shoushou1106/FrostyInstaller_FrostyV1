using Frosty.Controls;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Linq;

namespace FrostyStandaloneInstaller.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : FrostyWindow
{
    public MainWindow()
    {
        InitializeComponent();
        App.Tasks = new();

        // Language subtag (maybe): https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
        App.Languages = new() { "en-US", "zh-CN" };
        if (App.Languages.Contains(CultureInfo.InstalledUICulture.ToString()))
        {
            CultureInfo.CurrentCulture = CultureInfo.InstalledUICulture;
            CultureInfo.CurrentUICulture = CultureInfo.InstalledUICulture;
            if (App.ResourceManager.GetString("_FlowDirection") == "LeftToRight")
            {
                this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            }
            else if (App.ResourceManager.GetString("_FlowDirection") == "RightToLeft")
            {
                this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
            }
            else
            {
                this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            }
        }
        else
        {
            // Default en-US
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            CultureInfo.CurrentUICulture= CultureInfo.CreateSpecificCulture("en-US");
            this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
        }
    }

    public void SwitchLanguage(string languageSubtag)
    {
        if (App.Languages.Contains(languageSubtag))
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(languageSubtag);
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(languageSubtag);
            if (App.ResourceManager.GetString("_FlowDirection") == "LeftToRight")
            {
                this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            }
            else if (App.ResourceManager.GetString("_FlowDirection") == "RightToLeft")
            {
                this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
            }
            else
            {
                this.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            }
        }
    }
}