using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class GetAllOrdersViewModel:WszystkieViewModel<SalesOrders>
    {
        public override void Load()
        {
            List = new ObservableCollection<SalesOrders>(_context.SalesOrders.ToList());
        }
        public GetAllOrdersViewModel():base()
        {
            base.DisplayName = "Zamowienia";
        }

    }
}
