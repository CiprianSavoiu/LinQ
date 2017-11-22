using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.BL;

namespace ACM.WPF.ViewModels
{
    public class CustomerListViewModel: ViewModelBase
    {
        public ObservableCollection<Customer> _Customers;

        public ObservableCollection<Customer> Customers
        {
            get { return _Customers; }
            set
            {
                if (_Customers != value)
                {
                    _Customers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        CustomerRepository customerRepository = new CustomerRepository();

        public CustomerListViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            _Customers = new ObservableCollection<Customer>();
            var customerList = customerRepository.Retrieve();
            foreach (var customerInstance in customerList)
            {
                _Customers.Add(customerInstance);
            }
        }
    }
}
