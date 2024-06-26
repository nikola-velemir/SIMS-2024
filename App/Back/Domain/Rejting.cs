namespace App.Back.Domain
{
    public class Rejting
    {
        private int _ocena;
        public int Ocena
        {
            get { return _ocena; }
            set
            {
                if (value <= 0)
                {
                    _ocena = 0;
                }
                else if (value > 10)
                {
                    _ocena = 10;
                }
                else
                {
                    _ocena = value;
                }
            }
        }
        public Rejting()
        {
            Ocena = 0;
        }
        public Rejting(int ocena)
        {
            Ocena = ocena;
        }
    }
}