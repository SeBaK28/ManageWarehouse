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
    public class GetAllSuppliersViewModel:WszystkieViewModel<Suppliers>
    {
        public override void Load()
        {
            List = new ObservableCollection<Suppliers>(_context.Suppliers.ToList());
        }
        public GetAllSuppliersViewModel(): base()
        {
            base.DisplayName = "Dostawcy";
        }

    }
}
