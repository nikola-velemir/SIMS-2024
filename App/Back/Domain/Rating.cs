namespace App.Back.Domain
{
    public class Rating
    {
        private int _starCount;
        public int StarCount
        {
            get { return _starCount; }
            set
            {
                if (value <= 0)
                {
                    _starCount = 0;
                }
                else if (value > 10)
                {
                    _starCount = 10;
                }
                else
                {
                    _starCount = value;
                }
            }
        }
        public Rating()
        {
            StarCount = 0;
        }
        public Rating(int ocena)
        {
            StarCount = ocena;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Rating other = (Rating)obj;
            return StarCount == other.StarCount;
        }

        public override int GetHashCode()
        {
            return StarCount.GetHashCode();
        }
    }
}