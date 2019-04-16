using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WPFlab2
{
    /// <summary>
    /// Interaction logic for TopmostWindow.xaml
    /// </summary>
    public partial class TopmostWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public TopmostWindow()
        {
            InitializeComponent();
        }
        
        public TopmostWindow(ObservableCollection<Employee> employees)
        {
            InitializeComponent();
            DateTime now = DateTime.Now.Date;
            MyDate.SelectedDate = new DateTime(now.Year-30, now.Month, now.Day);
            Employees = employees;
            self = "5000";
            this.DataContext=this;
        }

        private string self;
        public string Self { get { return self; } set { self=value; } }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Employees != null)
            {
                Employee emp = new Employee(FirstName.Text, LastName.Text, (bool)Male.IsChecked?"Male":"Female", (DateTime)MyDate.SelectedDate, BirthCountry.Text, int.Parse(Salary.Text), (Currency)SalaryCurrency.SelectedIndex, (Role)CompanyRole.SelectedIndex);
                emp.PropertyChanged += MainWindow.EmployeeChanged;
                Employees.Add(emp);
            }
        }
    }
}
