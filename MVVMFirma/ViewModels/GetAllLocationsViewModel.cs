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
    public class GetAllLocationsViewModel: WszystkieViewModel<Locations>
    {
        public override void Load()
        {
            List = new ObservableCollection<Locations>(_context.Locations.ToList());
        }

        public GetAllLocationsViewModel(): base()
        {
             base.DisplayName = "Lokalizacje";
        }
    }
}
