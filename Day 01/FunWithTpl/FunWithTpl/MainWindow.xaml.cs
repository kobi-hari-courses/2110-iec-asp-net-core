using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunWithTpl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void btnGo_Click(object sender, RoutedEventArgs e)
        //{
        //    txtPleaseWait.Visibility = Visibility.Visible;
        //    progressBar.IsIndeterminate = true;
        //    btnGo.IsEnabled = false;

        //    var task = PrimesCalculator.GetAllPrimesAsync(200000);

        //    task.ContinueWith(t =>
        //    {
        //        lstResults.ItemsSource = task.Result;
        //        btnGo.IsEnabled = true;
        //        progressBar.IsIndeterminate = false;
        //        txtPleaseWait.Visibility = Visibility.Collapsed;
        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //}

        private async void btnGo_Click2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("A");

            var res = await Calculate();

            Debug.WriteLine("B");
            Debug.WriteLine(res);
        }

        private async Task<int> Calculate()
        {
            Debug.WriteLine("1");

            txtPleaseWait.Visibility = Visibility.Visible;
            progressBar.IsIndeterminate = true;
            btnGo.IsEnabled = false;

            Debug.WriteLine("2");

            var task = PrimesCalculator.GetAllPrimesAsync(200000);

            Debug.WriteLine("3");

            var results = await task;

            Debug.WriteLine("4");

            lstResults.ItemsSource = results;
            btnGo.IsEnabled = true;
            progressBar.IsIndeterminate = false;
            txtPleaseWait.Visibility = Visibility.Collapsed;

            return 12;
        }


    }
}
