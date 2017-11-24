using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.BL;
using ACM.WPF.Models;

namespace ACM.WPF.ViewModels
{
    public class CustomerListViewModel: ViewModelBase
    {
        public ObservableCollection<CustomerModel> _Customers;

        public ObservableCollection<CustomerModel> Customers
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
            _Customers = new ObservableCollection<CustomerModel>();
            var customerList = customerRepository.Retrieve();

            var customerTypeRepository = new CustomerTypeRepository();
            var customerTypeList = customerTypeRepository.Retrieve();

            //var sortedList = customerRepository.SortByName(customerList);
            //var itemList = customerRepository.GetNamesAndId(customerList);
            //var itemsList = customerRepository.GetNamesAndType(customerList, customerTypeList);

            var query = customerList.Join(customerTypeList,
                c => c.CustomerTypeId,
                ct => ct.CustomerTypeId,
                (c, ct) => new CustomerModel()
                {
                    Name = c.LastName + ", " + c.FirstName,
                    CustomerTypeName = ct.TypeName
                });

            foreach (var customerInstance in query.OrderBy(c => c.Name))
            {
                _Customers.Add(customerInstance);
            }
        }
    }
}
