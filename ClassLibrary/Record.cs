using System;

namespace ClassLibrary
{
    public class Record
    {
		private int _id = 0;
		private string _title;
		private string _artist;
		private int _durationInSeconds;
		private int _yearOfPublication;

        public Record()
        {
            
        }

        public Record(string title, string artist, int durationInSeconds, int yearOfPublication)
        {
            Id = 0;
            Title = title;
            Artist = artist;
            DurationInSeconds = durationInSeconds;
            YearOfPublication = yearOfPublication;
        }

		public int YearOfPublication //over år 0
		{
			get { return _yearOfPublication; }
            set
            {
                if (value > 0) _yearOfPublication = value;
                else throw new ArgumentOutOfRangeException();
            }
		}


		public int DurationInSeconds //over 5 sec
		{
			get { return _durationInSeconds; }
			set
            {
                if (value > 5) _durationInSeconds = value;
                else throw new ArgumentOutOfRangeException();
            }
		}


		public string Artist //min 3 tegn - NOT NULL
		{
			get { return _artist; }
            set
            {
                if (value == null) throw new ArgumentNullException();
				if (value.Length >= 3) _artist = value;
                else throw new ArgumentException("Length must be more than 2 characters");
            }
		}


		public string Title //min 1 tegn - NOT NULL
		{
			get { return _title; }
			set
            {
                if (value == null) throw new ArgumentNullException();
				if (value.Length >= 1) _title = value;
                else throw new ArgumentException("Length must be at least one character");
            }
		}


		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

	}
}
