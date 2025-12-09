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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Notebook notebook;
        private IStorage storage;
        public EditUnitsWindow(Notebook notebook, IStorage storage)
        {
            InitializeComponent();
            this.notebook = notebook;
            this.storage = storage;
            DrawUnits();
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            units.Items.Clear();
            foreach (var item in list)
                units.Items.Add(item);
            modules.Items.Clear();
        }

        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if(units.SelectedItem is Unit unit)
            {
                EditElementWindow third = new EditElementWindow(unit);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();
                    storage.Save(notebook);
                }                
            }
        }

        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    DrawUnits();
                    storage.Save(notebook);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if(units.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    DrawUnits();
                    storage.Save(notebook);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void DrawModules()
        {
            if (units.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                modules.Items.Clear();
                foreach (Module m in list)
                    modules.Items.Add(m);
            }            
        }

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        private void EditModule(object sender, MouseButtonEventArgs e)
        {
            if(modules.SelectedItem is Module m)
            {
                EditElementWindow window = new EditElementWindow(m);
                if (window.ShowDialog() == true)
                {
                    DrawModules();
                    storage.Save(notebook);
                }
                    
            }
        }

        private void CreateModule(object sender, RoutedEventArgs e)
        {
            if(units.SelectedItem is Unit unit)
            {
                Module m = new Module();
                EditElementWindow window = new EditElementWindow(m);
                if(window.ShowDialog()==true)
                {
                    unit.Add(m);
                    DrawModules();
                    storage.Save(notebook);
                }
            }
        }

        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            if(modules.SelectedItem is Module m)
            {
                if(units.SelectedItem is Unit u)
                {
                    u.Remove(m);
                    DrawModules();
                    storage.Save(notebook);
                }
            }
        }
    }
}
