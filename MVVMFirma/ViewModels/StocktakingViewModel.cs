using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClosedXML.Excel;
using MVVMFirma.Helper;
using Microsoft.Win32;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models;
using System.Data.Entity;
using MVVMFirma.Views;
using MVVMFirma.ViewModels.Abstract;
using System.Reflection.Emit;
using System.Windows.Controls;

namespace MVVMFirma.ViewModels
{
    public class StocktakingViewModel : WorkspaceViewModel
    {

        public ObservableCollection<InwentaryzacjaModel> Items { get; set; } = new ObservableCollection<InwentaryzacjaModel>();
        public ObservableCollection<PorownanieModel> Comparison { get; set; } = new ObservableCollection<PorownanieModel>();

        #region String
        private String connectionString = "data source=DESKTOP-MJK341H\\SQLEXPRESS;initial catalog=WarehouseDb;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        #endregion

        public ICommand LoadExcelCommand { get; }

        public StocktakingViewModel()
        {
            LoadExcelCommand = new BaseCommand(LoadExcel);
            base.DisplayName = "Inwentaryzacja";
        }

        private void LoadExcel()
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Excel Files|*.xlsx;*.xls";

            if (openFile.ShowDialog() == true)
            {
                using (var workbook = new XLWorkbook(openFile.FileName))
                {

                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); //Pomijanie pierwszego wiersza w arkuszu, będzie tam "nazwa"; "wartosc"

                    Items.Clear();

                    foreach (var row in rows)
                    {
                        Items.Add(new InwentaryzacjaModel
                        {
                            Nazwa = row.Cell(1).GetString().Trim(),
                            Wartosc = row.Cell(2).GetValue<decimal>()
                        });
                    }
                }
            }

            CompareWithStock();
        }
   

        private void CompareWithStock()
        {
            if (Items.Count == 0) return;

            Comparison.Clear();

            using (var _context = new WarehouseDbEntities(connectionString))
            {

                foreach (var item in Items)
                {

                    var dbItem = _context.Products.FirstOrDefault(x => x.Name == item.Nazwa);
                    var element = _context.Stock.FirstOrDefault(x => x.ProductID == dbItem.ProductID);


                        Comparison.Add(new PorownanieModel
                        {
                            Nazwa = item.Nazwa,
                            Wartosc = item.Wartosc,
                            QuantityInStock = element.Quantity,
                        });

                }
            }

        }
    }
}
