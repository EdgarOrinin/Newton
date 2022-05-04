using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Newton
{
    public partial class StudentWindow : Window
    {
        private Student Student { get; set; }
        public ObservableCollection<TaskModel> TaskList { get; set; } = new ObservableCollection<TaskModel>();


        public StudentWindow()
        {
            InitializeComponent();
        }


        public StudentWindow(Student student)
        {
            InitializeComponent();

            Student = student;

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
                        Complexity = (Complexity)task.Complexity,
                        Completed = entity.StudentTasks.Any(t => t.Task_ID == task.ID && t.Student_ID == Student.ID)
                    });
                }
            }
        }


        private void TakeTask_Click(object sender, RoutedEventArgs e)
        {
            if (dgr.SelectedIndex == -1)
            {
                MessageBox.Show($"Не выбрана задача. Выберите задачу и повторите попытку.");
            }
            else
            {
                var win = new TakeTestWindow((TaskModel)dgr.SelectedValue);
                win.ShowDialog();

                using (var entity = new DbEntity())
                {
                    if (win.Task.Completed)
                    {
                        entity.StudentTasks.Add(new StudentTasks { ID = entity.StudentTasks.Count(), Task_ID = win.Task.ID, Student_ID = Student.ID });
                    }

                    entity.SaveChanges();
                }

                RefreshList();
            }
        }

        private void ShowLecture_Click(object sender, RoutedEventArgs e)
        {
            new LectureStudentWindow().ShowDialog();
        }
    }
}
