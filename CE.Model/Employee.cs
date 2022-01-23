using Prism.Mvvm;
using System.Collections.Generic;

namespace CE.Model
{
    public class Employee : BindableBase
    {
        private int _id;
        private string _surname;
        private string _name;
        private string _patronymic;
        private string _address;
        private string _phone;
        private string _post;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                RaisePropertyChanged("Surname");
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                RaisePropertyChanged("Patronymic");
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }
        public string Post
        {
            get => _post;
            set
            {
                _post = value;
                RaisePropertyChanged("Post");
            }
        }

        public virtual IEnumerable<CompanyEmployee> CompanyEmployees { get; set; }
    }
}