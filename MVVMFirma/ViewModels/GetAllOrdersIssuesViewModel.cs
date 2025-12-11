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
    public class GetAllOrdersIssuesViewModel: WszystkieViewModel<GoodsIssues>
    {
        public override void Load()
        {
            List = new ObservableCollection<GoodsIssues>(_context.GoodsIssues.ToList());
        }
        public GetAllOrdersIssuesViewModel():base()
        {
            base.DisplayName = "Problemy";
        }
    }
}
