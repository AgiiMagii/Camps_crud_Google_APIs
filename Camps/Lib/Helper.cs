
using Google.Apis.Forms.v1.Data;
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

        public void ReloadGrid2<T>(DataGridView gridName, List<T> dataSource, List<GridAction> gridActions, List<int> hideCollIdx = null) where T : class
        {
            try
            {
                gridName.DataSource = null;
                gridName.Columns.Clear();
                gridName.DataSource = dataSource;

                if (hideCollIdx != null && hideCollIdx.Count > 0)
                {
                    foreach (int idx in hideCollIdx)
                    {
                        gridName.Columns[idx].Visible = false;
                    }
                }
                if (gridActions != null)
                {
                    foreach (GridAction action in gridActions)
                    {
                        DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn();
                        btnAction.HeaderText = "";
                        btnAction.Name = action.Name;
                        btnAction.Text = action.Text;
                        btnAction.UseColumnTextForButtonValue = true;
                        gridName.Columns.Add(btnAction);
                        btnAction.DisplayIndex = gridName.Columns.Count - 1;
                    }
                }
                gridName.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch { throw; }

        }

        public TabControl FindTabControl(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TabControl tc)
                    return tc;

                var found = FindTabControl(control);
                if (found != null)
                    return found;
            }
            return null;
        }
    }

    public class GridAction
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }

}
