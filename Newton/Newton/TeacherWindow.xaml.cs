using System.Collections.ObjectModel;
using System.Windows;

namespace Newton
{
    public partial class TeacherWindow : Window
    {
        private Teacher Teacher { get; set; }
        public ObservableCollection<TaskModel> TaskList { get; set; } = new ObservableCollection<TaskModel>();


        public TeacherWindow()
        {
            InitializeComponent();
        }

        public TeacherWindow(Teacher teacher)
        {
            InitializeComponent();

            Teacher = teacher;

            RefreshList();
        }


        private void RefreshList()
        {
            TaskList.Clear();

            using (var entity = new DbEntity())
            {
                foreach (var task in entity.Task)
                {
                    TaskList.Add(new TaskModel
                    {
                        ID = task.ID,
                        Header = task.Header,
                        Answer = task.Answer,
                        Complexity = (Complexity)task.Complexity
                    });
                }
            }
        }


        private void ShowLecture_Click(object sender, RoutedEventArgs e)
        {
            new LectureTeacherWindow().ShowDialog();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (dgr.SelectedIndex == -1)
            {
                MessageBox.Show($"Не выбрана задача. Выберите задачу и повторите попытку.");
            }
            else
            {
                using (var entity = new DbEntity())
                {
                    entity.Task.Remove(entity.Task.Find(((TaskModel)dgr.SelectedValue).ID));

                    entity.SaveChanges();
                }

                RefreshList();
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var win = new AddTestWindow();
            win.ShowDialog();

            using (var entity = new DbEntity())
            {
                entity.Task.Add(new Task
                {
                    ID = win.Task.ID,
                    Header = win.Task.Header,
                    Answer = win.Task.Answer,
                    Complexity = (int)win.Task.Complexity,
                    Teacher_ID = Teacher.ID
                });

                entity.SaveChanges();
            }

            RefreshList();
        }
    }
}
