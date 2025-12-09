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
using Logic;
namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        private Exam exam;
        private Notebook notebook;
        private IStorage storage;

        public EditExamWindow(Notebook nb, IStorage storage)
        {
            InitializeComponent();
            notebook = nb;
            this.storage = storage;
            DrawModules();

            exam = new Exam();
            date.SelectedDate = exam.DateExam;
            coef.Text = exam.Coef.ToString();
            isAbsent.IsChecked = exam.IsAbsent;
            score.Text = exam.Score.ToString();
            teacher.Text = exam.Teacher;           
            modules.SelectedItem = exam.Module;
        }

        private void DrawModules()
        {
            modules.Items.Clear();
            foreach(Module m in notebook.ListModules())
            {
                modules.Items.Add(m);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                exam.Coef = (float)Convert.ToDouble(coef.Text);
                exam.DateExam = date.SelectedDate.Value;
                exam.IsAbsent = isAbsent.IsChecked.Value;
                exam.Module = modules.SelectedItem as Module;
                exam.Score = (float)Convert.ToDouble(score.Text);
                exam.Teacher = teacher.Text;

                notebook.AddExam(exam);
                storage.Save(notebook);
                Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
