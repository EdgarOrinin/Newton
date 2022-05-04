using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Newton
{
    public class TaskModel : INotifyPropertyChanged
    {
        private int _ID;
        public int ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged();
            }
        }

        private string _header;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }


        private string _answer;
        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }


        private Complexity _complexity;
        public Complexity Complexity
        {
            get => _complexity;
            set
            {
                _complexity = value;
                OnPropertyChanged();
            }
        }

        private bool _сompleted;
        public bool Completed
        {
            get => _сompleted;
            set
            {
                _сompleted = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
