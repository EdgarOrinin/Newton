using System.Windows;

namespace Newton
{
    public partial class TakeTestWindow : Window
    {
        public TaskModel Task { get; set; }


        public TakeTestWindow()
        {
            InitializeComponent();
        }

        public TakeTestWindow(TaskModel task)
        {
            InitializeComponent();

            Task = task;

            header.Text = task.Header;
            answer.Text = task.Answer;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Text.ToLower() == Task.Answer.ToLower())
            {
                MessageBox.Show($"Вы ответили правильно.");

                Task.Completed = true;

                Close();
            }
            else
            {
                MessageBox.Show($"Вы ответили не правильно. Повторите попытку.");
            }
        }
    }
}
