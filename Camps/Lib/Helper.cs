using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camps.Lib
{
    public class Helper
    {
        public void ReloadGrid<T>(DataGridView grid, List<T> items, bool IsDelete = false, bool IsUpdate = false) where T : class
        {
            grid.DataSource = null;
            grid.DataSource = items;

            if (IsDelete)
            {
                if (grid.Columns.Contains("Delete"))
                {
                    grid.Columns.Remove("Delete");
                }

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Action",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };

                grid.Columns.Add(btn);
                btn.DisplayIndex = grid.Columns.Count - 1;
            }
            if (IsUpdate)
            {
                if (grid.Columns.Contains("Update"))
                {
                    grid.Columns.Remove("Update");
                }
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    Name = "Update",
                    HeaderText = "Action",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                grid.Columns.Add(btn);
                btn.DisplayIndex = grid.Columns.Count - 1;
            }
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        public List<T> Paging<T>(List<T> items, int pageNr, int pageSize) where T : class
        {
            int startIndex = (pageNr - 1) * pageSize;
            List<T> pagedItems = items.Skip(startIndex).Take(pageSize).ToList();
            return pagedItems;
        }

        public void ClearForm(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox box)
                {
                    box.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.Value = 0;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.Clear();
                }
                if (control.HasChildren)
                {
                    ClearForm(control.Controls);
                }
            }
        }

        public List<T> ReadCsvFile<T>(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    IEnumerable<T> records = csv.GetRecords<T>();
                    return new List<T>(records);
                }
            }
        }

        public void GenerateCsv<T>(string filePath, List<T> items) where T : class
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(items);
                }
            }
        }

        public void GenerateCsv2(string path, IEnumerable data)
        {
            var enumerator = data.GetEnumerator();
            if (!enumerator.MoveNext()) return;

            var type = enumerator.Current.GetType();
            var properties = type.GetProperties();

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(",", properties.Select(p => p.Name)));

                foreach (var item in data)
                {
                    var values = properties.Select(p =>
                    {
                        var value = p.GetValue(item, null);
                        return value?.ToString();
                    });

                    writer.WriteLine(string.Join(",", values));
                }
            }
        }
    }
}
