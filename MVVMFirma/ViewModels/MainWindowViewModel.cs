using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.Views;
using System.ComponentModel.Design;
using MVVMFirma.Models;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        public ObservableCollection<WorkspaceViewModel> _Workspaces;
        private ReadOnlyCollection<MenuItemViewModel> _MenuItems;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }

        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "",
                    "Produkty",
                    new BaseCommand(() => this.CreateView<GetAllProductsViewModel>())),
                new CommandViewModel(
                    "",
                    "Lista Magazynow",
                    new BaseCommand(() => this.CreateView<GetAllWarehousesViewModel>())),
                new CommandViewModel(
                    "",
                    "Lokalizacje",
                    new BaseCommand(() => this.CreateView<GetAllLocationsViewModel>())),
                new CommandViewModel(
                    "",
                    "Magazyn",
                    new BaseCommand(() => this.CreateView<GetAllStocksViewModel>())),
                new CommandViewModel(
                    "",
                    "Dostawcy",
                    new BaseCommand(() => this.CreateView<GetAllSuppliersViewModel>())),
                new CommandViewModel(
                    "",
                    "Lista Klientow",
                    new BaseCommand(() => this.CreateView<GetAllCustomersViewModel>())),
                new CommandViewModel(
                    "",
                    "Zamowienia",
                    new BaseCommand(() => this.CreateView<GetAllOrdersViewModel>())),
                new CommandViewModel(
                    "",
                    "Elementy Zamowienia",
                    new BaseCommand(() => this.CreateView<GetAllPurchaseOrderItemsViewModel>())),
                new CommandViewModel(
                    "",
                    "Wyprzedaz",
                    new BaseCommand(() => this.CreateView<GetAllSalesOrdersViewModel>())),
                new CommandViewModel(
                    "",
                    "Elementy Wyprzedazy",
                    new BaseCommand(() => this.CreateView<GetAllSalesOrderItemsViewModel>())),
                new CommandViewModel(
                    "",
                    "Dostawy",
                    new BaseCommand(() => this.CreateView<GetAllReciptsViewModel>())),
                new CommandViewModel(
                    "",
                    "Problemy",
                    new BaseCommand(() => this.CreateView<GetAllOrdersIssuesViewModel>())),
                new CommandViewModel(
                    "",
                    "Faktura",
                    new BaseCommand(() => this.CreateView<GetAllInvoiceViewModel>())),
                new CommandViewModel(
                    "",
                    "Inwentaryzacja",
                    new BaseCommand(() => this.CreateView<StocktakingViewModel>())),
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        private void CreateView<T>() where T:WorkspaceViewModel, new()
        {
            var workspace = this.Workspaces.FirstOrDefault(x => x is T) as T;
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion

        #region MenuCommands

        public ReadOnlyCollection<MenuItemViewModel> MenuCommand
        {
            get
            {
                if (_MenuItems == null)
                {
                    List<MenuItemViewModel> cmds = this.CreateMenuItem();
                    _MenuItems = new ReadOnlyCollection<MenuItemViewModel>(cmds);
                }
                return _MenuItems;
            }
        }

        private List<MenuItemViewModel> CreateMenuItem()
        {
            return new List<MenuItemViewModel>
            {
                new MenuItemViewModel(
                    "Faktura",
                    new BaseCommand(() => this.CreateView<GetAllInvoiceViewModel>())),

            };
        }
        #endregion
    }
}
