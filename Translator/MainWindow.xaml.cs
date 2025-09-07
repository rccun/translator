using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            { "a","ф"},
{"b","и"},
{"c","с"},
{"d","в"},
{"e","у"},
{"f","а"},
{"g","п"},
{"h","р"},
{"i","ш"},
{"j","о"},
{"k","л"},
{"l","д"},
{"m","ь"},
{"n","т"},
{"o","щ"},
{"p","з"},
{"q","й"},
{"r","к"},
{"s","ы"},
{"t","е"},
{"u","г"},
{"v","м"},
{"w","ц"},
{"x","ч"},
{"y","н"},
{"z","я" }

        };
        bool canHandleMouseClick = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void translate(string text)
        {
            string ans = "", lang = "";
            List<string> l = new List<string>();
            foreach (var i in text.ToCharArray()) l.Add(i.ToString());
            if (dict.Keys.Contains(l[0])) lang = "en";
            else lang = "ru";
            foreach (var k in l)
            {
                if (k == " " || k == "\r" || k == "\n") ans += k;
                else if (lang == "en") ans += dict[k];
                else ans += findItem(k);
            }
            textBlock.Text = "";
            textBox1.Text = ans;
        }
        private void validation(string text)
        {
            string i;
            var list_text = text.ToCharArray();
            foreach (var j in list_text)
            {
                i = j.ToString();
                if (!dict.Keys.Contains(i) && !dict.Values.Contains(i) && i != " " && i != "\n")
                {
                    textBlock.Text = "Введены некорректные символы";
                    canHandleMouseClick = true;
                }
                else translate(text);
            }
        }
        private string findItem(string item)
        {
            string ans = "";
            foreach (var p in dict) if (p.Value == item) ans = p.Key;
            return ans;
        }
        private void onClick(object sender, RoutedEventArgs e)
        {
            canHandleMouseClick = false;
            validation(textBox1.Text);
        }

        private void textBox1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (canHandleMouseClick)
            {

                textBlock.Text = "";
                textBox1.Text = "";
                canHandleMouseClick = false;
            }
        }
    }
}