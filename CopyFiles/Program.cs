using CopyFiles.Data;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFiles
{
    static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Trace("Start of program.");

            string configFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

            Logger.Info($"Config file name: {configFile}");

            //using System.Configuration;  // Add a reference to System.Configuration.dll
//var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm(ReadConfigFile(configFile));
            Application.Run(form);
            WriteConfigFile(form.Config, configFile);
            Logger.Trace("End of program.");
        }

        private static ConfigData ReadConfigFile(string configFile)
        {
            try
            {
                Logger.Info($"Read config file : {configFile}");
                return JsonConvert.DeserializeObject<ConfigData>(System.IO.File.ReadAllText(configFile));
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
            return null;
        }

        private static void WriteConfigFile(ConfigData config, string configFile)
        {
            try
            {
                if(config == null || string.IsNullOrEmpty(configFile))
                {
                    throw new ArgumentNullException("config or configFile");
                }
                Logger.Info($"Write config file : {configFile}");
                System.IO.File.WriteAllText(configFile, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }
    }
}
