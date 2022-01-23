using Prism.Mvvm;

namespace CE.Model
{
    public class CompanyEmployee : BindableBase
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
    }
}