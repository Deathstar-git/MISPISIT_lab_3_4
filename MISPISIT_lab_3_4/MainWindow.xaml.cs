using MISPISIT_lab_3_4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MISPISIT_lab_3_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _file = $"{Environment.CurrentDirectory}\\EmployeeData.json";
        private BindingList<Employee> EmployeeData;
        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(_file);
            try
            {
                EmployeeData = _fileIOService.LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            dgEmployee.ItemsSource = EmployeeData;
            EmployeeData.ListChanged += EmployeeData_ListChanged;
        }

        private void EmployeeData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void NameSorting_Checked(object sender, RoutedEventArgs e)
        {
            var SortedEmployeeData = new BindingList<Employee>(EmployeeData.OrderBy(x => x.Name).ToList());
            dgEmployee.ItemsSource = SortedEmployeeData;
            dgEmployee.Items.Refresh();
        }

        private void NameSorting_Unchecked(object sender, RoutedEventArgs e)
        {
            dgEmployee.ItemsSource = EmployeeData;
            dgEmployee.Items.Refresh();
        }
        private void SalarySorting_Unchecked(object sender, RoutedEventArgs e)
        {
            dgEmployee.ItemsSource = EmployeeData;
            dgEmployee.Items.Refresh();
        }

        private void SalarySorting_Checked(object sender, RoutedEventArgs e)
        {
            var SortedEmployeeData = new BindingList<Employee>(EmployeeData.OrderBy(x => x.Salary).ToList());
            dgEmployee.ItemsSource = SortedEmployeeData;
            dgEmployee.Items.Refresh();
        }
    }
}
