using System;
using System.Text.RegularExpressions;

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

        private string _CprNO;

        public string CprNO
        {
            get { return _CprNO; }
            set { _CprNO = value; }
        }

        private int _ApartmentNO;

        public int ApartmentNO
        {
            get { return _ApartmentNO; }
            set { _ApartmentNO = value; }
        }

        private int _RoomNO;

        public int RoomNO
        {
            get { return _RoomNO; }
            set { _RoomNO = value; }
        }

        private bool _Deposit;

        public bool Deposit
        {
            get { return _Deposit; }
            set { _Deposit = value; }
        }


        public Tenant(string Name, string Phone, string Email, DateTime MoveInDate, DateTime MoveOutDate, string CprNO, int ApartmentNO, int RoomNO, bool Deposit)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.MoveInDate = MoveInDate;
            this.MoveOutDate = MoveOutDate;
            this.CprNO = CprNO;
            this.ApartmentNO = ApartmentNO;
            this.RoomNO = RoomNO;
            this.Deposit = Deposit;
        }

        public override string ToString()
        {
            return $"{Name},{Phone},{Email},{MoveInDate},{MoveOutDate},{CprNO},{ApartmentNO},{RoomNO},{Deposit}";
        }

        public static Tenant Register()
        {

            Tenant tenant;
            string Name;
            int Phone;
            string Email;
            string CprNO;
            int ApartmentNO;
            int RoomNO;
            bool Deposit;

            string pattern = @"\A(?:[a-z0-9A-Z]+(?:\.[a-z0-9A-Z]+)*@(?:[a-z](?:[a-z-]*[a-z]))+[a-z]*.(?:[a-z]*[a-z])?)\Z";


            Console.Write("Full Name: ");
            Name = Console.ReadLine();
                tenant = TenantRepo.FindTenant(Name); //Hvor kan vi finde tenant så jeg kan tjekke om de allerede eksistere. Har lavet en metode til det men måske mangler der noget.
                if (tenant != null)
                    Console.WriteLine("Tenant already exist");
            //} while (tenant != null);


            //Usikker om loopen er skrevet rigtigt, men det virker som den skal
            Console.Write("Email: ");
            do
            {
                Email = Console.ReadLine();


                if (Regex.IsMatch(Email, pattern) == false)
                    Console.WriteLine("Invalid Email try again");
            }
            while (Regex.IsMatch(Email, pattern) == false); //Forstår ikke rigtigt hvorfor den skal være false og ikke true

            Console.Write("Phone Number: ");
            Phone = int.Parse(Console.ReadLine());
            Console.Write("CprNO: "); //Skal den være der og hvad nu hvis det er udlændingerdet lejer
            CprNO = Console.ReadLine();
            Console.Write("ApartmentNO: ");
            ApartmentNO = int.Parse(Console.ReadLine());
            Console.Write("RoomNO: ");
            RoomNO = int.Parse(Console.ReadLine());

            //Console.Write("Move in date: ");
            //DateTime MoveInDate = Console.ReadLine(); //Skal man spørge efter det?
            //Console.Write("Move out date: ");
            //DateTime MoveOutDate = Console.ReadLine(); //Skal man spørge efter det?

            int recieved = 0;
            do
            {
                Console.Write("Recived Deposit: yes/no:  ");
                string input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "yes":
                        recieved = 1;
                        break;
                    case "no":
                        recieved = 2;
                        break;
                }
                if (recieved == 0)
                    Console.WriteLine("Invalid input. Write yes or no");
            } while (recieved == 0);
            Deposit = (recieved == 1);
            Console.ReadLine();
        }
    }
}