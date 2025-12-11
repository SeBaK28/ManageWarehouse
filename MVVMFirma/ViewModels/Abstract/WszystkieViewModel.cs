using MVVMFirma.Helper;
using MVVMFirma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{

    //klasa po której będzą dziedziczyć wszystkie view modele wyświetlające wszystkie modele biznesowe
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {

        protected readonly WarehouseDbEntities _context;
        protected ObservableCollection<T> _List;
        private BaseCommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(Load);
                }
                return _LoadCommand;
            }

        }
        //pobiera produkty z DB i zapisze jako ObservableConnection
        public abstract void Load();

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    Load();
                }
                return _List;
            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }

        }



        public WszystkieViewModel() :base()
        {
            //var connectionStrings = ConfigurationManager.ConnectionStrings["WarehouseDbEntities"].ConnectionString;
            _context = new WarehouseDbEntities("data source=DESKTOP-MJK341H\\SQLEXPRESS;initial catalog=WarehouseDb;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
    }
}
