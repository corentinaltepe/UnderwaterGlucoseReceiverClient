using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UnderwaterGlucoseReceiverClient.ViewModel;

namespace UnderwaterGlucoseReceiverClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Makes the Binding between the View and the ViewModel
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var app = new MainWindow();
            var context = new GlucoseClientApp(new MvvmDialogs.DialogService());
            app.DataContext = context;
            app.Show();

            if (e.Args.Length == 1) //make sure an argument is passed
            {
                FileInfo file = new FileInfo(e.Args[0]);
                if (file.Exists) //make sure it's actually a file
                {
                    // Opening from a file - TODO
                    //((GlucoseClientApp)app.DataContext).OpenFromJDP(file.FullName);
                    //throw new NotImplementedException();
                }
            }
        }
    }
}
