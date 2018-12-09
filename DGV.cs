private static void AppendDataToGrid(DataGridView grid, IList<object> source)
        {
            int rowCount = grid.Rows.Count;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            Type t = source[0].GetType();
            int rowIndex = grid.Rows.Add();
            var girdCells = grid.Rows[rowIndex].Cells;
            //Common.ShowProcessing("正在加载数据，请稍候...", Common.MainForm, (o) =>
            //{
                foreach (object item in source)
                {

                    var row = new DataGridViewRow();
                    foreach (DataGridViewCell cell in girdCells)
                    {
                        var p = t.GetProperty(cell.OwningColumn.DataPropertyName);
                        object pValue = p.GetValue(item, null);
                        var newCell = (DataGridViewCell)cell.Clone();
                        newCell.Value = pValue;
                        row.Cells.Add(newCell);
                    }
                    rows.Add(row);
                }
            //});

            grid.Rows.RemoveAt(rowIndex);
            grid.Rows.AddRange(rows.ToArray());

        }