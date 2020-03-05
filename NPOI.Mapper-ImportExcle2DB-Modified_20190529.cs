using System;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using Npoi.Mapper;
using Npoi.Mapper.Attributes;
using MyProject.MyDBContext;

namespace MyProject
{
    public partial class CusOrdForm : Form
    {
        public CusOrdForm()
        {
            InitializeComponent();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Find the Excel File",
                InitialDirectory = @"C:\MyDocuments",
                Filter = "Office07以上版本xlsx文件(*.xlsx)|*.xlsx|Office03 Excel文件(*.xls)|*.xls|xml文件(*.xml)|*.xml|所有文件(*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = false,
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetFullPath(openFileDialog.FileName); 
                lblStatus.Text = filePath;
                Execute(filePath); //驱动sheetIndex，用默认值
            }
            ;
        }

        public void Execute(string localPath)
        {
            IWorkbook workbook;
            using (FileStream file = new FileStream(localPath, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(file);
            }

            var importer = new Mapper(workbook);
            var items = importer.Take<DBContextExcelColumns>(sheetIndex);
            foreach (var item in items)
            {
                var row = item.Value;
                if (string.IsNullOrEmpty(row.Coid))
                    continue;
                Add2CusOrder(row);   
            }
        }

        private void Add2CusOrder(DBContextExcelColumns row)
        {
            lblStatus.Text = "";
            string strCoid = row.Coid, strCusId = row.CusId, strShipTo = row.ShipTo;
            DateTime dtRecDate = row.ReceiveDate.Date; //限定只有Date没有时间

            using (var db = new MyDBContext())
            {
                try
                {
                    db.Customerorder.Add(new Customerorder { Coid = strCoid, CusId = strCusId, ShipTo = strShipTo, ReceiveDate = dtRecDate });
                    db.SaveChanges();                   
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"{ex.Message}";
                }
            }
        }

        private class DBContextExcelColumns
        {
            [Column("Coid")]
            public string Coid { get; set; }

            [Column("CusId")]
            public string CusId {get; set; }

            [Column("ShipTo")]
            public string ShipTo { get; set; }

            [Column("ReceiveDate")]
            public DateTime ReceiveDate { get; set; } 
        }
    }
}
