using System.ComponentModel;

namespace PathologResultEntry.Controls.Extra_req_Entities
{
    /// <summary>
    /// For display grid colors
    /// </summary>
    public class ColNum : INotifyPropertyChanged
    {
        private string _name;
        private int _num;
        public string ColorType { get; set; }

        public ColNum ( )
        {
            Quantity = 0;

        }
        public int Quantity
        {
            get
            {
                return this._num;
            }
            set
            {
                if ( this._num != value )
                {
                    this._num = value;
                    OnPropertyChanged ( "Quantity" );
                }
            }
        }
        public string Color
        {
            get
            {
                return this._name;
            }
            set
            {
                if ( this._name != value )
                {
                    this._name = value;
                    OnPropertyChanged ( "Color" );
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ( string propertyName )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged ( this, new PropertyChangedEventArgs ( propertyName ) );
            }
        }

        public override string ToString ( )
        {
            return string.Format ( "{0} # {1}", Color, Quantity );
        }
    }
}