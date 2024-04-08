using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patholab_Common;
using Patholab_DAL_V1;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace PathologResultEntry.Controls
{
    public partial class MoreActionsCtrl : UserControl
    {
        private DataLayer dal;
        private   SDG sdg;
        public List<PHRASE_ENTRY> ListActionType { get; set; }
        public List<PHRASE_ENTRY> ListAgree { get; set; }
        public List<PHRASE_ENTRY> ListHandedTo { get; set; }
        public List<U_MORE_ACTION_USER> ListMore_Action { get; set; }

        public MoreActionsCtrl ( DataLayer dal, SDG sdg )
        {

            InitializeComponent ( );


            this.dal = dal;
            this.sdg = sdg;

            //Get data 
            ListActionType = dal.GetPhraseEntries ( "Action Type" ).ToList ( );
            ListAgree = dal.GetPhraseEntries ( "Agree" ).ToList ( );
            ListHandedTo = dal.GetPhraseEntries ( "Handed to" ).ToList ( );

            buidGrid ( grid );

            LoadList ( );




        }

        private void LoadList ( )
        {
            //        dal.RefreshAll ( );

            ListMore_Action = dal.FindBy<U_MORE_ACTION_USER> ( x => x.U_SDG_ID == sdg.SDG_ID ).OrderBy ( MA => MA.U_DATE ).ToList ( );
            ;
            this.grid.DataSource = ListMore_Action;
        }


        private void buidGrid ( RadGridView grid )
        {


            grid.GridBehavior = new MyBehavior ( );
            grid.AutoGenerateColumns = false;




            var id = new GridViewTextBoxColumn ( );
            id.Name = "U_MORE_ACTION_ID";
            id.FieldName = id.Name;
            id.HeaderText = "id";
            id.IsVisible = false;
            id.AllowResize = false;

            id.ReadOnly = true;
            id.IsPinned = true;
            //   id.Width = 44;
            grid.Columns.Add ( id );

            var Send_On = new GridViewDateTimeColumn ( );
            Send_On.Name = "U_DATE";
            Send_On.FieldName = "U_DATE";
            Send_On.HeaderText = "נשלח בתאריך";
            //   Send_On.Width = 129;
            Send_On.FormatString = "{0:dd/MM/yyyy}";
            grid.Columns.Add ( Send_On );


            var actionTypeColumn = new GridViewComboBoxColumn ( );
            actionTypeColumn.Name = "פעולה";
            actionTypeColumn.FieldName = "U_ACTION_TYPE";
            actionTypeColumn.HeaderText = "פעולה";
            actionTypeColumn.DisplayMember = "PHRASE_DESCRIPTION";
            actionTypeColumn.ValueMember = "PHRASE_NAME";
            actionTypeColumn.AutoCompleteMode = AutoCompleteMode.Suggest;
            actionTypeColumn.DataSource = ListActionType;
            //     actionTypeColumn.Width = 105;

            actionTypeColumn.AllowHide = false;

            grid.Columns.Add ( actionTypeColumn );


            var handedTocColumn = new GridViewComboBoxColumn ( );
            handedTocColumn.Name = "handedTocColumn";
            handedTocColumn.FieldName = "U_HANDED_TO";
            handedTocColumn.HeaderText = "נמסר ל";
            handedTocColumn.DisplayMember = "PHRASE_DESCRIPTION";
            handedTocColumn.ValueMember = "PHRASE_NAME";
            //   handedTocColumn.Width = 120;
            handedTocColumn.AutoCompleteMode = AutoCompleteMode.Suggest;
            handedTocColumn.DataSource = ListHandedTo;
            handedTocColumn.AllowHide = false;

            grid.Columns.Add ( handedTocColumn );

            var slidesNumColumn = new GridViewDecimalColumn ( );
            slidesNumColumn.Minimum = 0;
            slidesNumColumn.Maximum = 100;
            slidesNumColumn.Name = "slidesNumColumn";
            slidesNumColumn.FieldName = "U_NUMBER_OF_SLIDE";
            //       slidesNumColumn.Width = 38;
            slidesNumColumn.TextAlignment = ContentAlignment.MiddleCenter;
            slidesNumColumn.DecimalPlaces = 0;
            slidesNumColumn.HeaderText = "מספר סליידים";

            grid.Columns.Add ( slidesNumColumn );

            var agreeColumn = new GridViewComboBoxColumn ( );
            agreeColumn.Name = "agreeColumn";
            agreeColumn.FieldName = "U_AGREE";
            agreeColumn.HeaderText = "הסכמה בתשובה";
            agreeColumn.DisplayMember = "PHRASE_DESCRIPTION";
            agreeColumn.ValueMember = "PHRASE_NAME";
            //       agreeColumn.Width = 50;
            agreeColumn.AutoCompleteMode = AutoCompleteMode.Suggest;
            agreeColumn.DataSource = ListAgree;
            agreeColumn.AllowHide = false;

            grid.Columns.Add ( agreeColumn );


            var comments = new GridViewTextBoxColumn ( );
            comments.Name = "סטטוס";
            comments.HeaderText = "הסטוריית פעולות";
            comments.FieldName = "StatusHistory";
            comments.ReadOnly = true;
            comments.AllowReorder = false;
            grid.Columns.Add ( comments );




            //       radGridView1.CommandCellClick += new CommandCellClickEventHandler ( radGridView1_CommandCellClick );

        }



        private void grid_CellEditorInitialized ( object sender, GridViewCellEventArgs e )
        {
            RadDropDownListEditor dropDownEditor = this.grid.ActiveEditor as RadDropDownListEditor;
            if ( dropDownEditor != null )
            {
                RadDropDownListEditorElement dropDownEditorElement =
                    ( RadDropDownListEditorElement ) dropDownEditor.EditorElement;

                dropDownEditorElement.AutoCompleteMode = AutoCompleteMode.Suggest;
                dropDownEditorElement.AutoCompleteSuggest = new CustomAutoSuggestHelper ( dropDownEditorElement );
                dropDownEditorElement.DropDownStyle = RadDropDownStyle.DropDown;
                dropDownEditorElement.Font = grid.Font; // a font
                dropDownEditorElement.ListElement.Font = grid.Font; // a font
            }
        }

        private void grid_DefaultValuesNeeded ( object sender, GridViewRowEventArgs e )
        {
            lblMsgV.Visible = false;

            if ( this.grid.CurrentRow is GridViewNewRowInfo )
            {
                e.Row.Cells [ "U_DATE" ].Value = DateTime.Now;
            }

        }

        private void btn_save_Click ( object sender, EventArgs e )
        {
            grid.EndEdit ( );
            var toAdd=ListMore_Action.Where ( x => x.U_MORE_ACTION_ID == 0 );
            foreach ( U_MORE_ACTION_USER uMoreActionUser in toAdd )
            {
                EnterNewACTION ( uMoreActionUser );
            }

            dal.SaveChanges ( );
            lblMsgV.Visible = true;

            //Reload
            ListMore_Action = dal.FindBy<U_MORE_ACTION_USER> ( x => x.U_SDG_ID == sdg.SDG_ID ).OrderBy ( MA => MA.U_DATE ).ToList ( );
            foreach ( U_MORE_ACTION_USER uMoreActionUser in ListMore_Action )
            {
                dal.ReloadEntity ( uMoreActionUser );
            }
            this.grid.DataSource = ListMore_Action;




        }

        private void EnterNewACTION ( U_MORE_ACTION_USER uMoreActionUser )
        {




            var id = dal.GetNewId ( "SQ_U_MORE_ACTION" );
            long lid = Convert.ToInt64 ( id );
            U_MORE_ACTION req = new U_MORE_ACTION ( )
                    {
                        NAME = id.ToString ( ),
                        U_MORE_ACTION_ID = lid,
                        VERSION = "1",
                        VERSION_STATUS = "A",
                        U_MORE_ACTION_USER = uMoreActionUser
                    };


            uMoreActionUser.U_MORE_ACTION_ID = lid;
            uMoreActionUser.U_SDG_ID = sdg.SDG_ID;
            dal.Add ( req );

        }

        private void btn_cancel_Click ( object sender, EventArgs e )
        {
            grid.EndEdit ( );

            //var toRemove = ListMore_Action.Where(x => x.U_MORE_ACTION_ID == 0);
            //  ListMore_Action.RemoveAll ( x => x.U_MORE_ACTION_ID == 0 );

            LoadList ( );

            lblMsgV.Visible = false;
        }

        private void grid_UserDeletingRow ( object sender, GridViewRowCancelEventArgs e )
        {
            U_MORE_ACTION_USER mac=    e.Rows [ 0 ].DataBoundItem as U_MORE_ACTION_USER;


            if ( mac != null && mac.U_MORE_ACTION_ID != 0 )
            {
                // Do not allow the user to delete the Starting Balance row.
                MessageBox.Show ( "לא ניתן למחוק שורה קיימת!" );

                // Cancel the deletion if the Starting Balance row is included.
                e.Cancel = true;
            }
        }

        internal void HideLabels ( )
        {
            lblMsgV.Visible = false;
        }


    }





    public class MyBehavior : BaseGridBehavior
    {
        public override bool ProcessKeyDown ( KeyEventArgs keys )
        {
            if ( keys.KeyData == Keys.Enter && this.GridControl.IsInEditMode )
            {
                this.GridControl.GridNavigator.SelectNextColumn ( );
            }
            return true;
        }
    }

    public class CustomAutoSuggestHelper : AutoCompleteSuggestHelper
    {
        public CustomAutoSuggestHelper ( RadDropDownListElement owner )
            : base ( owner )
        {
        }

        protected override bool DefaultFilter ( RadListDataItem item )
        {
            return item.Text.Contains ( this.Filter );
        }
    }

}
