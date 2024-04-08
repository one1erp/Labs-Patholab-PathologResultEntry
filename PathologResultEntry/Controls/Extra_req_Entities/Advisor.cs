using Patholab_DAL_V1;

namespace PathologResultEntry.Controls.Extra_req_Entities
{
    public class Advisor
    {
        
        public OPERATOR opAdv { get; set; }
        public string operatorName { get; set; }

        public Advisor(OPERATOR op)
        {
            opAdv = op;
            operatorName = op.FULL_NAME;
        }
        public override string ToString ( )
        {
            return opAdv.OPERATOR_USER.U_DEGREE + " " + opAdv.FULL_NAME;
        }
    }
}