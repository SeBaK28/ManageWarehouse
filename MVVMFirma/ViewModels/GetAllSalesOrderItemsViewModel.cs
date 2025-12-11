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
    public class GetAllSalesOrderItemsViewModel : WszystkieViewModel<SalesOrderItems>
    {
        public override void Load()
        {
            List = new ObservableCollection<SalesOrderItems>(_context.SalesOrderItems.ToList());
        }
        public GetAllSalesOrderItemsViewModel() :base()
        {
            base.DisplayName = "Elementy Wyprzedazy";
        }

    }
}
