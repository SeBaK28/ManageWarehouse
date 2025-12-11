using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class GetAllCustomersViewModel:WszystkieViewModel<Customers>
    {

        //pobiera produkty z DB i zapisze jako ObservableConnection
        public override void Load()
        {
            List = new ObservableCollection<Customers>(_context.Customers.ToList());

        }

        public GetAllCustomersViewModel(): base() 
        {
            base.DisplayName = "Lista Klientow";
        }
    }
}
