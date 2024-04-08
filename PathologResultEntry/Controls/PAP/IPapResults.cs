using Patholab_DAL_V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;

namespace PathologResultEntry.Controls.PAP
{
    interface ITest
    {
        string TestName { get; }
        bool CanSave();
    }
    interface IPapResults// : ITest
    {

        //   Dictionary<string, RadControl> Results { get; set; }
        void InitilaizeData(ListData listData);
        //     void Load(SDG sdg);
        string TestName { get; }

        Dictionary<string, RadControl> GetReultsControls();
    //    void Save();
      //  void EnableControls(bool p);
        void LoadResultList ( );

    }


    interface IManager
    {

    }
}
