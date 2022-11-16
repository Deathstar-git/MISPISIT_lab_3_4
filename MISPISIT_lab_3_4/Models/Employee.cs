using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISPISIT_lab_3_4.Models
{
    internal class Employee : INotifyPropertyChanged
    {
        private int _salary;
        private string _name;
        private string _position;
        public DateTime HireDate { get; set; } = DateTime.Now;
        public string Name
        {
            get { return _name; }
            set
            {
                if(_name == value)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Salary
        {
            get { return _salary; }
            set
            {
                if (_salary == value)
                {
                    return;
                }
                _salary = value;
                OnPropertyChanged("Salary");
            }
        }
        public string Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                {
                    return;
                }
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName = "")
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
