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
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        private Logic.Notebook notebook;
        private Logic.IStorage storage;

        public ListExamsWindow(Logic.Notebook nb, Logic.IStorage storage)
        {
            InitializeComponent();
            notebook = nb;
            this.storage = storage;
            DrawExams();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DrawExams()
        {
            exams.Items.Clear();
            foreach(Exam e in notebook.ListExams())
            {
                exams.Items.Add(e);
            }
            scores.Items.Clear();
            foreach(AvgScore avg in notebook.ComputeScores())
            {
                scores.Items.Add(avg);
            }
        }

        private void ExamDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (exams.SelectedItem is Exam ex)
            {
                EditExamWindow win = new EditExamWindow(notebook, storage, ex);
                win.ShowDialog();
                DrawExams();
            }
        }

        private void EditSelected(object sender, RoutedEventArgs e)
        {
            if (exams.SelectedItem is Exam ex)
            {
                EditExamWindow win = new EditExamWindow(notebook, storage, ex);
                win.ShowDialog();
                DrawExams();
            }
        }

        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            if (exams.SelectedItem is Exam ex)
            {
                var res = MessageBox.Show("Delete selected exam?","Confirm",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                if(res==MessageBoxResult.Yes)
                {
                    notebook.RemoveExam(ex);
                    storage.Save(notebook);
                    DrawExams();
                }
            }
        }
    }
}
