using Patholab_Common;
using Patholab_DAL_V1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PathologResultEntry.Controls.PAP
{
    internal class PapManger
    {

        #region Private fields

        public List<TabPage> RelevantTabs { get; private set; }
        Dictionary<IPapResults,TabPage> _pagesDic;
        private   Dictionary<IPapResults,TabPage> pagesDic;
        private   TabPage tabFreeTxt;
        private   TabPage tab_HPV;



        #endregion
      
        #region Loading


        public PapManger ( Dictionary<IPapResults, TabPage> pagesDic, TabPage tabFreeTxt, TabPage tab_HPV )
        {


            _pagesDic = pagesDic;
            // pages.ForEach ( x => x.LoadResultList ( ) );
            _pagesDic.Foreach ( x => x.Key.LoadResultList ( ) );
            this.tabFreeTxt = tabFreeTxt;
            this.tab_HPV = tab_HPV;
        
            InitCombo ( );
        }




        internal async Task InitilaizeData ( ListData listData )
        {

            //  pages.ForEach ( x => x.InitilaizeData ( listData ) );
            _pagesDic.Foreach ( x => x.Key.InitilaizeData ( listData ) );
            ClearScreen ( );
        }

        #endregion
      
        #region Data
        internal bool ContainsResult ( string str )
        {
            //return pages.Any ( X => X.GetReultsControls ( ).ContainsKey ( str ) );
            return _pagesDic.Any ( X => X.Key.GetReultsControls ( ).ContainsKey ( str ) );
        }

        internal void LoadResults ( List<WrapperRtf> currentResults, bool isHpv )
        {
            RelevantTabs = new List<TabPage> ( );

            foreach ( var item in _pagesDic.Keys )
            {


                var results4page = from res in currentResults
                                   where res.TestName == item.TestName
                                   select res;
                if ( results4page.Count ( ) == 0 )
                {
                    continue;
                }
                else
                {
                    RelevantTabs.Add ( _pagesDic [ item ] );
                }


                var resultControls = item.GetReultsControls ( );

                //visible/hide HPV controls if they appear on other tab
                ShowHpvControls ( isHpv, resultControls );



                foreach ( var res in results4page )
                {
                    if ( !resultControls.ContainsKey ( res.Name ) ) continue;


                    var ctl = resultControls [ res.Name ];

                    //SHOW CONTROL ONLY FOR HPV REQUEST
                    if ( ctl.Tag != null && ctl.Tag.ToString ( ) == PapConstants.HPV_TAG )
                    {
                        ctl.Visible = isHpv;
                    }

                    RadDropDownList cmb = ctl as RadDropDownList;
                    if ( cmb != null )
                    {


                        PHRASE_ENTRY pe_res = null;

                        var listEntry = cmb.DataSource as List<PHRASE_ENTRY>;
                        //Check if result is phrase name or description
                        pe_res = listEntry.SingleOrDefault ( x => x.PHRASE_NAME == res.Result_.FORMATTED_RESULT
                                                           || x.PHRASE_DESCRIPTION == res.Result_.FORMATTED_RESULT );

                        if ( pe_res != null )

                            cmb.SelectedValue = pe_res.PHRASE_NAME;

                        else
                            cmb.Text = res.Result_.FORMATTED_RESULT;
                    }
                    else if ( ctl as RadCheckBox != null )
                    {
                        RadCheckBox cb = ctl as RadCheckBox;
                        cb.IsChecked = ( res.Result_.FORMATTED_RESULT == "True" || res.Result_.FORMATTED_RESULT == "T" );
                        continue;
                    }
                }

            }
            RelevantTabs.Add ( tabFreeTxt );
            if ( isHpv )
                RelevantTabs.Add ( tab_HPV );

        }

        private static void ShowHpvControls ( bool isHpv, Dictionary<string, Telerik.WinControls.RadControl> resultControls )
        {
            resultControls.Where ( x => x.Value.Tag != null && x.Value.Tag.ToString ( ) == PapConstants.HPV_TAG )
                .Foreach ( a => a.Value.Visible = isHpv );
        }
        internal void SaveResults ( List<WrapperRtf> currentResults )
        {

            foreach ( var page in _pagesDic.Keys )
            {
                var results4page = from res in currentResults
                                   where res.TestName == page.TestName
                                   select res;
                var resultControls = page.GetReultsControls ( );

                foreach ( var res in results4page )
                {

                    if ( !resultControls.ContainsKey ( res.Name ) ) continue;

                    string val = "";
                    RadDropDownList cmb = resultControls [ res.Name ] as RadDropDownList; //.se.Text;
                    if ( cmb != null )
                    {

                        var entries = cmb.DataSource as List<PHRASE_ENTRY>;
                        if ( entries != null )
                        {
                            PHRASE_ENTRY cmbVal = entries.FirstOrDefault ( x => x.PHRASE_DESCRIPTION == cmb.Text );

                            if ( cmbVal != null )
                                val = cmbVal.PHRASE_NAME;
                            else
                            {
                                val = cmb.Text;
                            }
                            RESULT res2Update = currentResults.Select ( x => x.Result_ ).Where ( x => x.RESULT_ID == res.ResultId ).SingleOrDefault ( );
                            if ( res2Update != null )
                            {
                                res2Update.FORMATTED_RESULT = val;
                                res2Update.ORIGINAL_RESULT = val;
                            }

                        }
                    }



                }
            }
     
        }
        #endregion

        #region UI
        internal void EnableControls ( bool p )
        {
            foreach ( var item in _pagesDic.Keys )
            //    foreach ( var item in pages )
            {
                UserControl uc = item as UserControl;
                uc.Enabled = p;
            }
        }
        internal void ClearScreen ( )
        {
            //   foreach ( var item in pages )
            foreach ( var item in _pagesDic.Keys )
            {
                UserControl uc = item as UserControl;

                foreach ( var rd in uc.Controls.OfType<GroupBox> ( ) )
                {
                    foreach ( var cmb in rd.Controls.OfType<RadDropDownList> ( ) )
                    {

                        cmb.Text = "";
                    }
                }
            }
        }
        //papmanger
        void InitCombo ( )
        {
            //   foreach ( var item in pages )
            foreach ( var item in _pagesDic.Keys )
            {
                UserControl uc = item as UserControl;

                foreach ( var rd in uc.Controls.OfType<GroupBox> ( ) )
                {
                    foreach ( var cmb in rd.Controls.OfType<RadDropDownList> ( ) )
                    {
                        cmb.ListElement.Font = new Font ( "Arial", 11f, FontStyle.Bold );
                        AutoCompleteModE ( cmb );
                        rd.GotFocus += ( s, e ) => zLang.English ( );
                        cmb.DropDownMinSize = new Size(cmb.Width,330);
                    }
                }
            }
        }
        private void AutoCompleteModE ( RadDropDownList rd )
        {
            rd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    rd.AutoCompleteMode = AutoCompleteMode.Suggest;
            rd.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper ( rd.DropDownListElement );
            rd.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
        }



        #endregion



        internal void SetFocus ( )
        {

        }


    }
}
