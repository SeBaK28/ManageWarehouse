using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class GetAllInvoiceViewModel : WszystkieViewModel<FakturaForAllView>
    {
        public GetAllInvoiceViewModel() : base()
        {
            base.DisplayName = "Faktura";
        }

        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>(from faktura in _context.SalesOrders
                                                               select new FakturaForAllView
                                                               {
                                                                   Name = faktura.Customers.Name,
                                                                   Address = faktura.Customers.Address,
                                                                   ContactPerson = faktura.Customers.ContactPerson,
                                                                   Phone = faktura.Customers.Phone,
                                                                   Email = faktura.Customers.Email,
                                                                   OrderDate = faktura.OrderDate,
                                                                   TotalAmount = faktura.TotalAmount,
                                                               });
        }
    }
}
