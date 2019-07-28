using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

//Load ref


namespace RobotPlayground
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ImportMap.ImportMap importmap;

        public App()
        {
            importmap = new ImportMap.ImportMap();
        }

    }
}
