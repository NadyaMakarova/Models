using Avalonia.Controls;
using Avalonia.Interactivity;
using Models.ViewModels;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Drawing;
using Avalonia.Input;
using ScottPlot.Avalonia;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System.Collections.Generic;
using SukiUI.Controls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace Models.Views
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowViewModel { get; set; } /*=> DataContext as MainWindowViewModel;*/

        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel = new MainWindowViewModel();
            var goeloCalculation = this.FindControl<Button>("goeloCalculation");
            goeloCalculation.DataContext = MainWindowViewModel;
            var millsCalculation = this.FindControl<Button>("millsCalculation");
            millsCalculation.DataContext = MainWindowViewModel;
            var M = this.FindControl<TextBox>("M");
            M.DataContext = MainWindowViewModel;
            var B = this.FindControl<TextBox>("B");
            B.DataContext = MainWindowViewModel;
            var T = this.FindControl<TextBox>("T");
            T.DataContext = MainWindowViewModel;
            var N = this.FindControl<TextBox>("N");
            N.DataContext = MainWindowViewModel;
            var Nex = this.FindControl<TextBox>("Nex");
            Nex.DataContext = MainWindowViewModel;
            var P = this.FindControl<TextBox>("P");
            P.DataContext = MainWindowViewModel;
            var periods = this.FindControl<TreeView>("periods");
            periods.DataContext = MainWindowViewModel;
            var S = this.FindControl<TextBox>("S");
            S.DataContext = MainWindowViewModel;
            var V = this.FindControl<TextBox>("V");
            V.DataContext = MainWindowViewModel;
            var K = this.FindControl<TextBox>("K");
            K.DataContext = MainWindowViewModel;
            var Pg = this.FindControl<TextBox>("Pg");
            Pg.DataContext = MainWindowViewModel;
            //var side = this.FindControl<SideMenu>("side");
            //side.DataContext = MainWindowViewModel;
            //side.DataContext = MainWindowViewModel;
            //MainWindowViewModel = new MainWindowViewModel();
            //DataContext = MainWindowViewModel;
            //var comboBox = this.FindControl<ComboBox>("comboBox");
            //comboBox.DataContext = mainWindow;
        }

        //public void SelectionChanged(object sender, SelectionChangedEventArgs args)
        //{
        //    if ((sender as ComboBox).DataContext != null)
        //        ((sender as ComboBox).DataContext as TypeOperationViewModel).Lyambda = Convert.ToDouble(((args.AddedItems[0] as ComboBoxItem).Content as TextBlock).Text);
        //    //MainWindowViewModel.
        //    //var json = JsonConvert.SerializeObject(ViewModel.DtConfiguration);
        //    //File.WriteAllText("Models\\DtConfiguration.json", json);
        //}


        public async void Clicked(object sender, RoutedEventArgs args)
        {
            try
            {
                AvaPlot avaPlot1 = this.Find<AvaPlot>("avaPlot1");
                avaPlot1.Plot.Clear();
                var xList = new List<double>();
                var yList = new List<double>();
                foreach (var period in MainWindowViewModel.Periods)
                {
                    xList.Add(Convert.ToDouble(period.T));
                    yList.Add(Convert.ToDouble(period.Lyambda));
                }
                avaPlot1.Plot.AddScatter(xList.ToArray(), yList.ToArray());
                avaPlot1.Refresh();
            }
            catch
            {

            }
        }
    }

}
