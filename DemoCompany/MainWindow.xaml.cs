using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoCompany;
using System.Windows.Controls.Primitives;


namespace DemoCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    
    {
        PersonalContext db = new PersonalContext();
        
            public MainWindow()

        {
            InitializeComponent();

            MainList1.ItemsSource = db.Employes.Include(s => s.Department).ToList();
            Position.ItemsSource = db.Employes.ToList();
            Department.ItemsSource = db.Departments.ToList();
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {
            if(MainList1.SelectedItem != null)
            {
                Employes selectedEmploye = MainList1.SelectedItem as Employes;
                Name.Text = selectedEmploye.Name;
                Sername.Text = selectedEmploye.Sername;
                Position.Text = selectedEmploye.Position;
                Department.SelectedValue = selectedEmploye.DepartmentId;
                Salary.Value = selectedEmploye.Salary;
                HiringDate.SelectedDate = selectedEmploye.HiringDate;
            }
        }

        private void Slider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Employes newEmploye = new Employes
            {
                Name = Name.Text,
                Sername = Sername.Text, 
                Position = Position.Text,
                DepartmentId = (int)Department.SelectedValue,
                Salary = Salary.Value,
                HiringDate = HiringDate.SelectedDate,
            };
            db.Employes.Add(newEmploye);
            db.SaveChanges();
            MainList1.ItemsSource = db.Employes.Include(s => s.Department).ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Employes selected = MainList1.SelectedItem as Employes;
            selected.Name = Name.Text;
            selected.Sername = Sername.Text; 
            selected.Position = Position.Text;
            selected.DepartmentId = (int)Department.SelectedValue;
            selected.Salary = Salary.Value;
            selected.HiringDate = HiringDate.SelectedDate;
            db.Employes.Update(selected);
            db.SaveChanges();
            MainList1.ItemsSource = db.Employes.Include (s => s.Department).ToList();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Employes selected1 = MainList1.SelectedItem as Employes;
            db.Employes.Remove(selected1);
            db.SaveChanges();
            MainList1.ItemsSource = db.Employes.Include (s => s.Department).ToList();   
        }

        private void Searсh_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainList1.ItemsSource = db.Employes.Where(s => s.Name == Search.Text || s.Name.Contains(Search.Text) ||
            s.Department.Name == Search.Text || s.Department.Name.Contains(Search.Text)).Include(s => s.Department).ToList();
        }
    }
}
