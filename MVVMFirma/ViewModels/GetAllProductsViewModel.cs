using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class GetAllProductsViewModel : WszystkieViewModel<Products>
    {

        public override void Load()
        {
            //var list1 = _context.Products.ToList();
            List = new ObservableCollection<Products>(_context.Products.ToList());
           
        }



        public GetAllProductsViewModel():base()
        {
            //var connectionStrings = ConfigurationManager.ConnectionStrings["WarehouseDbEntities"].ConnectionString;
            base.DisplayName = "Produkty";
            //base._context = new WarehouseDbEntities("data source=DESKTOP-MJK341H\\SQLEXPRESS;initial catalog=WarehouseDb;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework");
        }



    }
}
//using MVVMFirma.Helper;
//using MVVMFirma.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace MVVMFirma.ViewModels
//{
//    public class GetAllProductsViewModel : WorkspaceViewModel
//    {

//        private readonly WarehouseDbEntities _context;
//        private ObservableCollection<Products> _List;
//        private BaseCommand _LoadCommand;

//        public ICommand LoadCommand
//        {
//            get
//            {
//                if (_LoadCommand == null)
//                {
//                    _LoadCommand = new BaseCommand(load);
//                }
//                return _LoadCommand;
//            }

//        }
//        //pobiera produkty z DB i zapisze jako ObservableConnection
//        private void load()
//        {
//            var list1 = _context.Products.ToList();
//            List = new ObservableCollection<Products>(_context.Products.ToList());

//        }

//        public ObservableCollection<Products> List
//        {
//            get
//            {
//                if (_List == null)
//                {
//                    load();
//                }
//                return _List;
//            }
//            set
//            {
//                if (_List != value)
//                {
//                    _List = value;
//                    OnPropertyChanged(() => List);
//                }
//            }

//        }



//        public GetAllProductsViewModel()
//        {
//            //var connectionStrings = ConfigurationManager.ConnectionStrings["WarehouseDbEntities"].ConnectionString;
//            base.DisplayName = "Produkty";
//            _context = new WarehouseDbEntities("data source=DESKTOP-MJK341H\\SQLEXPRESS;initial catalog=WarehouseDb;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework");
//        }



//    }
//}
