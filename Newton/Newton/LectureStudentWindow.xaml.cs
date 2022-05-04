using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace Newton
{
    public partial class LectureStudentWindow : Window
    {
        public ObservableCollection<Lecture> LectureList { get; set; } = new ObservableCollection<Lecture>();

        public LectureStudentWindow()
        {
            InitializeComponent();

            using (var entity = new DbEntity())
            {
                foreach(var lecture in entity.Lecture)
                {
                    LectureList.Add(lecture);
                }
            }
        }

        private void ShowLecture_Click(object sender, RoutedEventArgs e)
        {
            if (dgr.SelectedIndex == -1)
            {
                MessageBox.Show($"Не выбрана лекция. Выберите задачу и повторите попытку.");
            }
            else
            {
                Process.Start($"{Environment.CurrentDirectory}/lectures/{ ((Lecture)dgr.SelectedValue).ID}.pdf");
            }
        }
    }
}
