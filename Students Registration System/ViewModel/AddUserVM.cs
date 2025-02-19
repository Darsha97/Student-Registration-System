﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Students_Registration_System.ViewModel
{
    public partial class AddUserVM : ObservableObject

    {


        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;



        //To change the tile



        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;



        public AddUserVM(User u)
        {
            Student = u;

            firstname = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.Gpa;
            dateofbirth = Student.DateOfBirth;
            selectedImage = Student.Image;

        }
        public AddUserVM()
        {

        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly Uploded!", "successfull");
            }
        }






        public User Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0.0 || gpa > 4.0)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (Student == null)
            {

                Student = new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,

                    Gpa = gpa,

                };


            }
            else
            {

                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.Gpa = gpa;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateofbirth;



            }

            if (Student.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }
    }
}
