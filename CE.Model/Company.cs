using Prism.Mvvm;
using System.Collections.Generic;

namespace CE.Model
{
    public class Company : BindableBase
    {
        private int _id;
        private string _name;
        private string _description;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
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
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public virtual IEnumerable<CompanyEmployee> CompanyEmployees { get; set; }
    }
}