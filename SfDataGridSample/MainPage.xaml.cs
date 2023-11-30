using SfDataGridSample.Services;
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Exporting;
using Syncfusion.Maui.DataGrid.Helper;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            DataGridExcelExportingOption exportOption = new DataGridExcelExportingOption();
            var list = new List<string>();
            list.Add("EmployeeID");
            exportOption.ExcludedColumns = list;
            var excelEngine = excelExport.ExportToExcel(this.dataGrid, exportOption);
            var workbook = excelEngine.Excel.Workbooks[0];
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            string OutputFilename = "DefaultDataGrid.xlsx";
            SaveService saveService = new();
            saveService.SaveAndView(OutputFilename, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", stream);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            DataGridPdfExportingOption option = new DataGridPdfExportingOption();
            var list = new List<string>();
            list.Add("EmployeeID");
            option.ExcludedColumns = list;
            var pdfDoc = pdfExport.ExportToPdf(this.dataGrid, option);
            pdfDoc.Save(stream);
            pdfDoc.Close(true);
            SaveService saveService = new();
            saveService.SaveAndView("ExportFeature.pdf", "application/pdf", stream);
        }
    }
}
