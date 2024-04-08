using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patholab_Common;
using Patholab_DAL_V1;
using Telerik.WinControls.UI;

namespace PathologResultEntry
{
   public class ListData
    {
       private DataLayer _dal;

       public ListData(DataLayer _dal)
       {
           // TODO: Complete member initialization
           this._dal = _dal;
       }



       public void SetExistsList2Combo(RadDropDownList comboBox, List<PHRASE_ENTRY> list, bool newCtx = true)
       {
            if (list == null)
                return;
            // Running on the worker thread



            if (newCtx)
            {
                comboBox.BindingContext = new BindingContext();
            }
            comboBox.DisplayMember = "PHRASE_DESCRIPTION";
            comboBox.ValueMember = "PHRASE_NAME";


            comboBox.DataSource = list;



            // Back on the worker thread




        }

       public List<PHRASE_ENTRY> SetPhrase2Combo(RadDropDownList comboBox, string phraseName)
       {
           try
           {
               //todo:change func

               var list = _dal.GetPhraseEntries(phraseName).ToList();

               //    var ph = _dal.GetPhraseByName(phraseName);
               //  var list = ph.PHRASE_ENTRY.ToList();
               SetExistsList2Combo(comboBox, list, false);
               return list;



           }
           catch (Exception e)
           {
               Logger.WriteLogFile(e); MessageBox.Show("Error in load " + phraseName + " Phrase " + e.Message, Constants.MboxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
               return null;
           }

       }

       public List<PHRASE_ENTRY> SetSecondSignCombo(string userName)
       {
           return _dal.FindBy<PHRASE_HEADER>(ph => ph.NAME.ToLower().Equals("sign by")).FirstOrDefault().PHRASE_ENTRY.Where(pe => pe.PHRASE_DESCRIPTION != userName).ToList();
       }
    }
}
