/// <copyright>3Shape A/S</copyright>

using ThreeShapeLorisProgrammingTool.Commands;
using ThreeShapeLorisProgrammingTool.Test;
using ThreeShapeLorisProgrammingTool.Logger;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace PE_MB_Tester.MainViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
        public event PropertyChangedEventHandler PropertyChanged;

        //Logging mechanism declaration
        Logger _logger;

        //View variables inicialization
        private string _JTAGStatusColor = "Red";
        private string _PMICStatusColor = "Red";
        private string _UARTStatusColor = "Red";
        private string _RouterStatusColor = "Red";
        public string JTAGStatusColor
        {
            get { return _JTAGStatusColor; }
            set
            {
                Color c = Color.FromName(value);
                if (c.IsKnownColor)
                {
                    _JTAGStatusColor = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PMICStatusColor
        {
            get { return _PMICStatusColor; }
            set
            {
                Color c = Color.FromName(value);
                if (c.IsKnownColor)
                {
                    _PMICStatusColor = value;
                    OnPropertyChanged();
                }
            }
        }
                    public string UARTStatusColor
        {
            get { return _UARTStatusColor; }
            set
            {
                Color c = Color.FromName(value);
                if (c.IsKnownColor)
                {
                    _UARTStatusColor = value;
                    OnPropertyChanged();
                }
            }
        }
                    public string RouterStatusColor
        {
            get { return _RouterStatusColor; }
            set
            {
                Color c = Color.FromName(value);
                if (c.IsKnownColor)
                {
                    _RouterStatusColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            //Logging mechanism initialization
            _logger = new Logger();


            var appCapabilities = new OpenQA.Selenium.Appium.AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            appCapabilities.AddAdditionalCapability("platformName", "Windows");
            var calculatorSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);






        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void ReadConfig()
        {
            try
            {
                if ((
                    ConfigurationManager.AppSettings.Get("UARTName") is not null &&
                    ConfigurationManager.AppSettings.Get("JTAGName") is not null &&
                    ConfigurationManager.AppSettings.Get("PMICName") is not null &&
                    ConfigurationManager.AppSettings.Get("PowerSupplyVisa") is not null))
                {
                   // _penDrive.GetExpextedVid(ConfigurationManager.AppSettings.Get("PenDriveVid"));
                }
                else
                {
                    throw new Exception("Trying to read config value, but it is null! The app might work incorrectly!!");
                }
            }
            catch (Exception ex)
            {
                _logger.log(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}