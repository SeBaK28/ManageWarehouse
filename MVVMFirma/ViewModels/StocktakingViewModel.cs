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

namespace MVVMFirma.ViewModels
{
    public class StocktakingViewModel : WorkspaceViewModel
    {

        public ObservableCollection<InwentaryzacjaModel> Items { get; set; } = new ObservableCollection<InwentaryzacjaModel>();
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
                            Nazwa = row.Cell(1).GetValue<string>(),
                            Wartosc = row.Cell(2).GetValue<int>()
                        });
                    }
                }
            }
        }
    }
}
