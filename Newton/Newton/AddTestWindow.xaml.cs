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

namespace Newton
{
    /// <summary>
    /// Interaction logic for AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        public TaskModel Task { get; set; }


        public AddTestWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            using (var entity = new DbEntity())
            {
                Task = new TaskModel
                {
                    ID = entity.Task.Count() + 1,
                    Header = header.Text,
                    Answer = answer.Text,
                    Complexity = (Complexity)((ComboBoxItem)level.SelectedItem).Content,
                    Completed = false
                };
            }

            Close();
        }
    }
}
