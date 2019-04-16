using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFlab2
{
    public enum Currency { PLN, USD, EUR, GBP, NOK }
    public enum Role { Worker, SeniorWorker, IT, Manager, Director, CEO }
    public class Employee:INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string sex;
        private DateTime birthDate;
        private string birthCountry;
        private int salary;
        private Currency salaryCurrency;
        private Role companyRole;
        public string FirstName { get { return firstName; } set { SetField(ref firstName, value, "FirstName"); } }
        public string LastName { get { return lastName; } set { SetField(ref lastName, value, "LastName"); } }
        public string Sex { get { return sex; } set { SetField(ref sex, value, "Sex"); } }
        public DateTime BirthDate { get { return birthDate; } set { SetField(ref birthDate, value, "BirthDate"); } }
        public string BirthCountry { get { return birthCountry; } set { SetField(ref birthCountry, value, "BirthCountry"); } }
        public int Salary { get { return salary; } set { SetField(ref salary, value, "Salary"); } }
        public Currency SalaryCurrency { get { return salaryCurrency; } set { SetField(ref salaryCurrency, value, "SalaryCurrency"); } }
        public Role CompanyRole { get { return companyRole; } set { SetField(ref companyRole, value, "CompanyRole"); } }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public Employee(string firstName, string lastName, string sex, DateTime birthDate, string birthCountry, int salary, Currency salaryCurrency, Role companyRole)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            BirthDate = birthDate;
            BirthCountry = birthCountry;
            Salary = salary;
            SalaryCurrency = salaryCurrency;
            CompanyRole = companyRole;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
