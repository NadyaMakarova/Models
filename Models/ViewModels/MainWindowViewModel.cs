using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Npgsql;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace Models.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //object? _n;

        object? _p;

        object? _pg;

        object? _m;

        object? _b;
        public string Greeting => "Welcome to Avalonia!";

        //public List<PeriodViewModel> Periods { get; set; }

        public ICommand MillsCommand { get; set; }

        public ICommand GoeloCommand { get; set; }

        //public object? Y { get; set; }

        //public object? Y { get; set; }

        //public object? Pob { get; set; }

        //public object? Pi { get; set; }

        //public double? Pop { get; set; }

        //public double? Pisp { get; set; }

        //public double? Pd { get; set; }

        //object? _r;

        //public object? N
        //{
        //    get
        //    {
        //        return _n;
        //    }
        //    set
        //    {
        //        if (value == _n)
        //            return;
        //        _n = value;
        //        try
        //        {
        //            this.RaisePropertyChanged(nameof(N));
        //            if (Convert.ToInt32(N) > 0)
        //            {
        //                Periods = new List<PeriodViewModel>();
        //                for (int i = 1; i <= Convert.ToInt32(N); i++)
        //                {
        //                    Periods.Add(new PeriodViewModel((i).ToString(), (i)));
        //                }
        //                this.RaisePropertyChanged(nameof(Periods));
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}

        public object? P
        {
            get
            {
                return _p;
            }
            set
            {
                if (value == _p)
                    return;
                _p = value;
                this.RaisePropertyChanged(nameof(P));
            }
        }

        public object? Pg
        {
            get
            {
                return _pg;
            }
            set
            {
                if (value == _pg)
                    return;
                _pg = value;
                this.RaisePropertyChanged(nameof(Pg));
            }
        }

        public object? B
        {
            get
            {
                return _b;
            }
            set
            {
                if (value == _b)
                    return;
                _b = value;
                this.RaisePropertyChanged(nameof(B));
            }
        }

        public object? M
        {
            get
            {
                return _m;
            }
            set
            {
                try
                {
                    if (value == _m)
                        return;
                    _m = value;
                    var newPeriods = new List<PeriodViewModel>();
                    for (var i = 1; i <= Convert.ToInt32(value); i++)
                    {
                        newPeriods.Add(new PeriodViewModel(i));
                    }
                    Periods = newPeriods;
                    this.RaisePropertyChanged(nameof(M));
                    this.RaisePropertyChanged(nameof(Periods));
                }
                catch
                {

                }
            }
        }

        public List<PeriodViewModel> Periods { get; set; }

        public object? K { get; set; }

        public object? V { get; set; }

        public object? S { get; set; }

        public object? T { get; set; }

        public object? N { get; set; }

        public object? Nex { get; set; }

        public MainWindowViewModel()
        {
            try
            {
                //Periods = new List<PeriodViewModel>();
                Periods = new List<PeriodViewModel>();
                MillsCommand = ReactiveCommand.Create(MillsCalculation);
                GoeloCommand = ReactiveCommand.Create(GoeloCalculation);
            }
            catch
            {

            }
        }

        public static double Fact(double n)
        {
            double p;
            p = 1;
            for (int i = 1; i <= n; i++)
            {
                p = p * i;
            }
            return p;
        }

        public void MillsCalculation()
        {
            try
            {
                P = Convert.ToString(Math.Round(C(Convert.ToDouble(S), Convert.ToDouble(V), Convert.ToDouble(K)), 3));
            }
            catch
            {

            }
        }

        public static double C(double s, double v, double k)
        {
            return (Fact(s) * Fact(v + k)) / (Fact(v - 1) * Fact(s + k + 1));
        }

        //public void AddElements(int index)
        //{
        //    try
        //    {
        //        var newList = new List<PeriodViewModel>();
        //        var periods = new List<PeriodViewModel>();
        //        for (int i = 0; i < index; i++)
        //        {
        //            var newElement = new PeriodViewModel((i + 1).ToString(), (i + 1));
        //            periods.Add(newElement);
        //        }
        //        Periods = new List<PeriodViewModel>(periods);
        //        this.RaisePropertyChanged(nameof(Periods));
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void Download(string fileName)
        //{
        //    try
        //    {
        //        var newFile = new FileInfo(fileName);
        //        var Excel_Package = new ExcelPackage(newFile);
        //        var workSheet = Excel_Package.Workbook.Worksheets[0];
        //        var cells = workSheet.Cells;
        //        //foreach (var type in TypeOperations)
        //        //{
        //        //    type.AddData(cells);
        //        //}
        //        Pk = Convert.ToDouble(cells["F3"].Value.ToString().Replace(".", ","));
        //        this.RaisePropertyChanged(nameof(Pk));
        //        Pob = Convert.ToDouble(cells["G3"].Value.ToString().Replace(".", ","));
        //        this.RaisePropertyChanged(nameof(Pob));
        //        Pi = Convert.ToDouble(cells["H3"].Value.ToString().Replace(".", ","));
        //        this.RaisePropertyChanged(nameof(Pi));
        //        this.RaisePropertyChanged(nameof(TypeOperations));

        //    }
        //    catch
        //    {
        //    }
        //}

        public void GoeloCalculation()
        {
            try
            {
                B = Math.Round(-(-Math.Log(Convert.ToDouble(M) / Convert.ToDouble(N) + 1)) / Convert.ToDouble(T), 3);
                Pg = Math.Round((1 - Convert.ToDouble(Nex) / Convert.ToDouble(N)),3);
                foreach (var el in Periods)
                {
                    el.Lyambda = Math.Round((Convert.ToDouble(N) * Convert.ToDouble(B) * Math.Pow(Math.E, -Convert.ToDouble(B) * Convert.ToDouble(el.T))), 3);
                }
            }
            catch
            {

            }
        }

        //public void Calculation()
        //{
        //    try
        //    {
        //        TypeOperations.ForEach(o => o.Calculation());
        //        Pop = 1;
        //        foreach (var oper in TypeOperations)
        //        {
        //            Pop = Pop * Math.Pow(Convert.ToDouble(oper.P), Convert.ToDouble(oper.k));
        //        }
        //        Pisp = Convert.ToDouble(Pk) * Convert.ToDouble(Pob) * Convert.ToDouble(Pi);
        //        Pd = Pop + (1 - Pop) * Pisp;
        //        this.RaisePropertyChanged(nameof(Pop));
        //        this.RaisePropertyChanged(nameof(Pisp));
        //        this.RaisePropertyChanged(nameof(Pd));
        //    }
        //    catch
        //    {

        //    }
        //}

    }
}
