using System.Linq;
using System.Windows;

namespace Newton
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            using (var entity = new DbEntity())
            {
                if (entity.Student.Any(s => s.Username == username.Text && s.Password == password.Password))
                {
                    new StudentWindow(entity.Student.FirstOrDefault(s => s.Username == username.Text && s.Password == password.Password)).Show();

                    Close();
                }
                else if (entity.Teacher.Any(t => t.Username == username.Text && t.Password == password.Password))
                {
                    new TeacherWindow(entity.Teacher.FirstOrDefault(t => t.Username == username.Text && t.Password == password.Password)).Show();

                    Close();
                }
                else
                {
                    MessageBox.Show($"Пользователь не найден. Проверьте имя пользователя и повторите попытку");
                }
            }
        }
    }
}
