using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFlab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>();
            this.DataContext = this;
            changed = false;
        }

        public ObservableCollection<Employee> Employees { get; set; }
        string FileName { get; set; }
        public static bool changed;
        TopmostWindow tw;

        public static void EmployeeChanged(Object sender, PropertyChangedEventArgs e)
        {
            changed = true;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (changed)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Do you want to save changes before opening new file?", "Save changes", MessageBoxButton.YesNoCancel);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    Save_Click(sender, e);
                }
                else if (dialogResult == MessageBoxResult.No) { }
                else return;
            }
            Employees.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            int i = 0;
            if (openFileDialog.ShowDialog() == true)
            {
                //Employees= new ObservableCollection<Employee>();
                FileName = openFileDialog.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            if (i == 0)
                            {
                                i++;
                            }
                            else
                            {
                                var a = line.Split(';');
                                string FirstName = a[0];
                                string LastName = a[1];
                                string Sex = a[2];
                                DateTime BirthDate = DateTime.ParseExact(a[3], "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                                string BirthCountry = a[4];
                                int Salary;
                                int.TryParse(a[5], out Salary);
                                Currency SalaryCurrency = (Currency)int.Parse(a[6]);
                                Role CompanyRole = (Role)int.Parse(a[7]);
                                Employee emp = new Employee(FirstName, LastName, Sex, BirthDate, BirthCountry, Salary, SalaryCurrency, CompanyRole);
                                emp.PropertyChanged += EmployeeChanged;
                                Employees.Add(emp);
                                i++;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //OutputConsole.Text = " ";
                    //OutputConsole.Text = ex.Message;
                }
            }
            //txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
            changed = false;
        }

        private void GoUp_Click(object sender, RoutedEventArgs e)
        {
            int i = Lista.SelectedIndex;
            if (i > 0)
            {
                var tmp = Employees[i];
                Employees[i] = Employees[i - 1];
                Employees[i - 1] = tmp;
                Lista.SelectedIndex = i - 1;
                changed = true;
            }
        }

        private void GoDown_Click(object sender, RoutedEventArgs e)
        {
            int i = Lista.SelectedIndex;
            if (i < Employees.Count - 1)
            {
                var tmp = Employees[i];
                Employees[i] = Employees[i + 1];
                Employees[i + 1] = tmp;
                Lista.SelectedIndex = i + 1;
                changed = true;
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            int i = 0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                try
                {
                    using (StreamWriter sr = new StreamWriter(fileName))
                    {
                        sr.WriteLine("First Name;Last Name;Sex;Birth Date;Birth Country;Salary;SalaryCurrency;CompanyRole;");
                        foreach (Employee emp in Employees)
                        {
                            sr.WriteLine($"{emp.FirstName};{emp.LastName};{emp.Sex};{emp.BirthDate.ToShortDateString()};{emp.BirthCountry};{emp.Salary};{(int)emp.SalaryCurrency};{(int)emp.CompanyRole};");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //OutputConsole.Text = " ";
                    //OutputConsole.Text = ex.Message;
                }
            }
            changed = false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(FileName))
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                    sr.WriteLine("First Name;Last Name;Sex;Birth Date;Birth Country;Salary;SalaryCurrency;CompanyRole;");
                    foreach (Employee emp in Employees)
                    {
                        sr.WriteLine($"{emp.FirstName};{emp.LastName};{emp.Sex};{emp.BirthDate.ToShortDateString()};{emp.BirthCountry};{emp.Salary};{(int)emp.SalaryCurrency};{(int)emp.CompanyRole};");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //OutputConsole.Text = " ";
                //OutputConsole.Text = ex.Message;
            }
            changed = false;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (changed)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Do you want to save changes before closing?", "Save changes", MessageBoxButton.YesNoCancel);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    Save_Click(sender, e);
                    if (tw != null) tw.Close();
                    Close();
                }
                if (dialogResult == MessageBoxResult.Cancel || dialogResult == MessageBoxResult.None) return;
            }
            if (tw != null) tw.Close();
            Close();
        }

        private void CloseEvent(object sender, EventArgs e)
        {
            tw=null;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (tw != null) { tw.WindowState = WindowState.Normal; return; }
            tw = new TopmostWindow(Employees);
            tw.Closed += CloseEvent;
            tw.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Employees.Count == 0) return;
            if (Lista.SelectedItems.Count>0)
            {
                int i = Lista.SelectedIndex;
                Employees.RemoveAt(i);
                Lista.SelectedIndex = i-1;
                changed = true;
            }
        }
    }
}
