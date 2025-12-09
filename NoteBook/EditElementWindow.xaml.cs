using Logic;
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
using System.Windows.Shapes;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditElementWindow.xaml
    /// </summary>
    public partial class EditElementWindow : Window
    {
        private EducationalElement element;
        public EditElementWindow(EducationalElement elt)
        {
            InitializeComponent();
            element = elt;
            name.Text = element.Name;
            coef.Text = element.Coef.ToString();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                element.Name = name.Text;
                element.Coef = (float)Convert.ToDouble(coef.Text);
                DialogResult = true;
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }
    }
}
