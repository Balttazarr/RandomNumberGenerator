using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;



namespace RandomNumberGenerator
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            bool op1ok = int.TryParse(txt_RMin.Text, out int min);

            bool op2ok = int.TryParse(txt_RMax.Text, out int max);

            if (op1ok == false || op2ok == false)
                throw new ArgumentException("wrong numbers");

            int hownumbers = (int)slValue.Value;

            string url = @"http://www.random.org/integers/?num=" +
                hownumbers.ToString() +
                "&min=" + min.ToString() +
                "&max=" + max.ToString() +
                "&col=1&base=10&format=plain&rnd=new";
            try
            {
                string data = HtmlDownload.HtmlToString(url);

                string[] dataArray = data.Split('\n');

                foreach (var item in dataArray)
                {
                    listBox1.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
