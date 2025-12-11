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
    public class GetAllWarehousesViewModel : WszystkieViewModel<Warehouses>
    {
        public override void Load()
        {
            List = new ObservableCollection<Warehouses>(_context.Warehouses.ToList());
        }
        public GetAllWarehousesViewModel() : base()
        {
            base.DisplayName = "Magazyny";
        }

    }
}
