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
    public class GetAllStocksViewModel:WszystkieViewModel<Stock>
    {
        public override void Load()
        {
            List = new ObservableCollection<Stock>(_context.Stock.ToList());
        }
        public GetAllStocksViewModel() :base()
        {
            base.DisplayName = "Stan Magazynu";
        }

    }
}
