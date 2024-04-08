using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Patholab_DAL_V1;
using System.IO;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Patholab_XmlService;
using LSSERVICEPROVIDERLib;
using System.Text.RegularExpressions;
using PathologResultEntry.Controls.Extra_req_Entities;
using System.Windows.Data;

namespace PathologResultEntry.Controls
{
    public partial class FrmColor : Form
    {


        #region Fields

        private List<string> listPart_I, listPart_H, listPart_O;
        private DataLayer _dal;
        public List<int> QuantityColList { get; set; }
        private const int TreeItemHeight = 19;

        private List<ColNum> _table1_I, _table1_H, _table1_O
            , _table2_O, _table2_I, _table2_H,
            _table3_O, _table3_I, _table3_H,
        _table4_O, _table4_I, _table4_H;

        public List<ColNum> SelectedColors { get; private set; }
        public string colorType { get; set; }
        public bool approved { get; private set; }

        private SDG _sdg;
        private List<RadGridView> gridViews;
        private List<List<ColNum>> tables;
        #endregion

        public FrmColor(DataLayer dal, SDG sdg)
        {
            this.Load += FrmColor_Load;

            QuantityColList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this._dal = dal;
            this._sdg = sdg;
            this.WindowState = FormWindowState.Maximized;

            SelectedColors = new List<ColNum>();

            tables = new List<List<ColNum>> { 
                (_table1_I = new List<ColNum> ( ))
              ,(  _table2_I = new List<ColNum> ( ))
              ,(  _table3_I = new List<ColNum> ( ))
              ,(  _table4_I = new List<ColNum> ( ))
              ,(  _table1_H = new List<ColNum> ( ))
              ,(  _table2_H = new List<ColNum> ( ))
              ,(  _table3_H = new List<ColNum> ( ))
              ,(  _table4_H = new List<ColNum> ( ))
              ,(  _table1_O = new List<ColNum> ( ))
              ,(  _table2_O = new List<ColNum> ( ))
              ,(  _table3_O = new List<ColNum> ( ))
              ,(  _table4_O = new List<ColNum> ( ))
            };

            InitializeComponent();

            listPart_I = this._dal.FindBy<U_PARTS_USER>
                (x => x.U_PART_TYPE == "I").OrderBy(d => d.U_ORDER).Select(x => x.U_STAIN).ToList();

            listPart_H = this._dal.FindBy<U_PARTS_USER>
                (x => x.U_PART_TYPE == "H").OrderBy(d => d.U_ORDER).Select(x => x.U_STAIN).ToList();

            listPart_O = this._dal.FindBy<U_PARTS_USER>
                    (x => x.U_PART_TYPE == "O").OrderBy(d => d.U_ORDER).Select(x => x.U_STAIN).ToList();


            gridViews = new List<RadGridView>()
            {
                gridColors, gridColors2, gridColors3,gridColors4
            };

            gridViews.ForEach(BuildGrid);

            BuildData(listPart_I, _table1_I, _table2_I, _table3_I, _table4_I, "I");
            BuildData(listPart_H, _table1_H, _table2_H, _table3_H, _table4_H, "H");
            BuildData(listPart_O, _table1_O, _table2_O, _table3_O, _table4_O, "O");
        }

        private void FrmColor_Load(object sender, EventArgs e)
        {
            lbox_ColorType.SelectedIndex = 0;
        }

        private void BuildGrid(RadGridView grid)
        {
            grid.AutoGenerateColumns = false;

            GridViewTextBoxColumn gvtc = new GridViewTextBoxColumn("Color");
            gvtc.FieldName = "Color";
            gvtc.Width = 150;
            gvtc.ReadOnly = true;
            grid.Columns.Add(gvtc);

            GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Quantity");
            comboColumn.Width = 80;
            comboColumn.FieldName = "Quantity";

            comboColumn.DataSource = QuantityColList;
            grid.Columns.Add(comboColumn);

            grid.RowFormatting += gridColors_RowFormatting;
            grid.CellClick += (this.gridColors_CellClick);
        }

        private void BuildData(List<string> fullList, List<ColNum> t1, List<ColNum> t2, List<ColNum> t3, List<ColNum> t4, string colorType)
        {
            int tablesN = gridViews.Count > 0 ? gridViews.Count : 1;
            var div = fullList.Count / tablesN;
            for (var i = 0; i < div; i++)
                t1.Add(new ColNum { Color = fullList[i], Quantity = 0, ColorType = colorType });
            for (var i = div; i < div * 2; i++)
                t2.Add(new ColNum { Color = fullList[i], Quantity = 0, ColorType = colorType });
            for (var i = div * 2; i < div * 3; i++)
                t3.Add(new ColNum { Color = fullList[i], Quantity = 0, ColorType = colorType });
            for (var i = div * 3; i < fullList.Count; i++)
                t4.Add(new ColNum { Color = fullList[i], Quantity = 0, ColorType = colorType });
        }

        private void lbox_ColorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbox_ColorType.SelectedIndex == 0)
            {
                this.gridColors.DataSource = _table1_I;
                this.gridColors2.DataSource = _table2_I;
                this.gridColors3.DataSource = _table3_I;
                this.gridColors4.DataSource = _table4_I;

                colorType = "I";
            }

            if (lbox_ColorType.SelectedIndex == 1)
            {
                this.gridColors.DataSource = _table1_H;
                this.gridColors2.DataSource = _table2_H;
                this.gridColors3.DataSource = _table3_H;
                this.gridColors4.DataSource = _table4_H;

                colorType = "H";

            }
            if (lbox_ColorType.SelectedIndex == 2)
            {
                this.gridColors.DataSource = _table1_O;
                this.gridColors2.DataSource = _table2_O;
                this.gridColors3.DataSource = _table3_O;
                this.gridColors4.DataSource = _table4_O;

                colorType = "O";
            }

            radButtonFilter.Text = "Filter";
            radTextBoxFilter.Text = string.Empty;
            isFiltered = false;
            radTextBoxFilter.Enabled = true;
        }

        private void btn_addColors_Click(object sender, EventArgs e)
        {
            SelectedColors.Clear();
            List<ColNum> list = new List<ColNum>();

            foreach (List<ColNum> colNums in tables)
            {
                list.AddRange(colNums.Where(x => x.Quantity > 0).ToList());
            }

            SelectedColors = list;

            approved = true;
            this.Close();
        }

        private void gridColors_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((ColNum)e.RowElement.Data.DataBoundItem != null && ((ColNum)e.RowElement.Data.DataBoundItem).Quantity > 0)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = Color.Aqua;
            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            }
        }

        private void gridColors_CellClick(object sender, GridViewCellEventArgs e)
        {
            var col = e.Row.DataBoundItem as ColNum;

            if (col != null)
            {
                int val = col.Quantity;
                if (val == 0)
                {
                    e.Row.Cells[1].Value = val + 1;
                }
                else
                {
                    e.Row.Cells[1].Value = 0;
                }
            }
        }

        internal void LoadBlockData(Dictionary<string, int> colorsDictionary)
        {
            approved = false;

            //Init prev List
            SelectedColors.Clear();

            //Init grids
            gridViews.ForEach(x => x.DataSource = null);

            tables.ForEach(tbl => tbl.ForEach(x => x.Quantity = 0));

            if (colorsDictionary != null)
            {
                foreach (var item in colorsDictionary)
                {
                    foreach (List<ColNum> colNums in tables)
                    {
                        var record = colNums.FirstOrDefault(x => x.Color == item.Key);
                        if (record != null)
                        {
                            record.Quantity = item.Value;

                        }
                    }
                }
            }

            lbox_ColorType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            approved = false;

            this.Close();
        }

        #region filter methods

        CollectionView view;
        string textFilter = string.Empty;
        bool isFiltered = false;

        private void radButtonFilter_Click(object sender, EventArgs e)
        {
            if (!isFiltered)
            {
                addFilter();
                radButtonFilter.Text = "Remove Filter";
            }
            else
            {
                removeFilter();
                radButtonFilter.Text = "Filter";
                radTextBoxFilter.Text = string.Empty;
            }

            radTextBoxFilter.Enabled = !isFiltered;
        }

        private void addFilter()
        {
            try
            {
                textFilter = radTextBoxFilter.Text;
                apllyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering." + Environment.NewLine + ex.Message);
            }
            finally
            {
                isFiltered = !isFiltered;
            }
        }

        private void apllyFilter()
        {
            apllyFilterColumn(gridColors);
            apllyFilterColumn(gridColors2);
            apllyFilterColumn(gridColors3);
            apllyFilterColumn(gridColors4);
        }

        private void apllyFilterColumn(RadGridView radGrid)
        {
            view = (CollectionView)CollectionViewSource.GetDefaultView(radGrid.DataSource);

            view.Filter = UserFilter;

            radGrid.DataSource = view;
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(textFilter))
                return true;

            ColNum col = item as ColNum;

            try
            {
                return col.Color.StartsWith(textFilter, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception)
            {
                return true;
            }
        }

        private void removeFilter()
        {
            lbox_ColorType_SelectedIndexChanged(null, null);
        }

        private void removeFilterFromColumn(RadGridView radGrid)
        {
            view = (CollectionView)CollectionViewSource.GetDefaultView(radGrid.DataSource);
            view.Filter = clearFilter;
        }

        // this function will iterate on all rows of the listview and because it is returning true - all rows will be visible.
        private bool clearFilter(object item)
        {
            return true;
        }

        #endregion

        private void radTextBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radButtonFilter_Click(null, null);
            }
        }

        private void gridColors_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            var grid = sender as RadGridView;
            grid.CurrentRow = null;
        }

        private void FrmColor_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {

                lbox_ColorType.SelectedIndex = 0;
                lbox_ColorType_SelectedIndexChanged(null, null);
            }
        }
    }
}