using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PathologResultEntry
{
    public class WrapperRtf
    {   
        public long ResultId;
        public string RtfText;
        public string Name { get; set; }
        public string TestName { get; set; }

        public Patholab_DAL_V1.RESULT Result_ { get; set; }
    }
 
 
    public static class Constants
    {
        public static string MboxCaption = "Nautilus";
        public static string HisMac = "Histology Macro text";
        public static string HisMic = "Histology Micro";
        public static string CytMac = "Cytology Macro Text";
        public static string CytMic = "Citology Micro";

        public static string Diag = "Diagnosis";
        public static string ImpDiagnos = "Imp_Diagnos";

        public static string SnomedT = "Snomed T";
        public static string SnomedM = "Snomed M";

        public static string Sign1St = "Sign by 1st.";
        public static string Sign2Nd = "Sign by 2nd.";

        public static string Malignant = "Malignant";
        public static string Lymphnodespresent = "No of lymph nodes present";
        public static string Lymphnodescarcinoma = "No of lymph nodes infiltrated by carcinoma";

        public static string TumorBehavior = "Tumor behavior";
        public static string PapFreeTxt = "Free Text Result";
    }

    #region combo box Helpers

    public class CustomAutoCompleteSuggestHelper : AutoCompleteSuggestHelper
    {
        public CustomAutoCompleteSuggestHelper ( RadDropDownListElement owner )
            : base ( owner )
        { }

        public override void ApplyFilterToDropDown ( string filter )
        {
            base.ApplyFilterToDropDown ( filter );
            this.DropDownList.ListElement.DataLayer.DataView.Comparer = new CustomComparer ( );
        }
    }

    public class CustomComparer : IComparer<RadListDataItem>
    {
        public int Compare ( RadListDataItem x, RadListDataItem y )
        {
            return x.Text.Length.CompareTo ( y.Text.Length );
        }
    }

    #endregion
}