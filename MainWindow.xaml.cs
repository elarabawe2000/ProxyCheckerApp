using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Xml.Linq;

namespace ProxyCheckerApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Proxy> Proxies { get; } = new();
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                var config = XDocument.Load("appconfig.xml");
                var sources = config.Descendants("Source");
                foreach (var source in sources)
                {
                    Console.WriteLine($"Source: {source.Value}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config: {ex.Message}");
            }
        }
    }

    public class Proxy
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string Type { get; set; }
    }
}
