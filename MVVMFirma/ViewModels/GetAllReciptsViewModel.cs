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
    public class GetAllReciptsViewModel: WszystkieViewModel<GoodsReceipts>
    {
        public override void Load()
        {
            List = new ObservableCollection<GoodsReceipts>(_context.GoodsReceipts.ToList());

        }
        public GetAllReciptsViewModel() :base()
        {
            base.DisplayName = "Dostawy";
        }

    }
}
