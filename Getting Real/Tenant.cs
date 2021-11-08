using System;

namespace Getting_Real
{
    public class Tenant
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _MoveInDate;
        public DateTime MoveInDate
        {
            get { return _MoveInDate; }
            set { _MoveInDate = value; }
        }

        private DateTime _MoveOutDate;
        public DateTime MoveOutDate
        {
            get { return _MoveOutDate; }
            set { _MoveOutDate = value; }
        }

        public Tenant(string Name, string Phone, string Email, DateTime MoveInDate, DateTime MoveOutDate)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.MoveInDate = MoveInDate;
            this.MoveOutDate = MoveOutDate;
        }

        public override string ToString()
        {
            return $"{Name},{Phone},{Email},{MoveInDate},{MoveOutDate}";
        }
    }
}