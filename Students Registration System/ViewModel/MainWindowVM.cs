using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registration_System.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<Student> students;
        private Student selectedStudent;
        private RelayCommand addCommand;
        private RelayCommand updateCommand;
        private RelayCommand deleteCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(() =>
                {
                    Student newStudent = new Student();
                    Students.Add(newStudent);
                    SelectedStudent = newStudent;
                }));
            }
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new RelayCommand(() =>
                {
                    // Handle update logic here
                }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(() =>
                {
                    if (SelectedStudent != null)
                    {
                        Students.Remove(SelectedStudent);
                        SelectedStudent = null;
                    }
                }));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
