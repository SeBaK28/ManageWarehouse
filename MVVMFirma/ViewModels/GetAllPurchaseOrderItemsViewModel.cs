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
    public class GetAllPurchaseOrderItemsViewModel: WszystkieViewModel<PurchaseOrderItems>
    {
        public override void Load()
        {
            List = new ObservableCollection<PurchaseOrderItems>(_context.PurchaseOrderItems.ToList());
        }
        public GetAllPurchaseOrderItemsViewModel() : base()
        {
            base.DisplayName = "Elementy Zamowienia";
        }
    }
}
