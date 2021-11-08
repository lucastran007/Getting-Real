using System;
using System.IO;
using System.Collections.Generic;

namespace Getting_Real
{
    public class TenantRepo
    {
        private List<Tenant> _Tenants;
        public List<Tenant> Tenants
        {
            get { return _Tenants; }
            set { _Tenants = value; }
        }

        private string path = "../../../Tenants.txt";

        public TenantRepo()
        {
            Load();
        }

        public void Save()
        {
            using (StreamWriter writer = new(path))
            {
                for (int i = 0; i < Tenants.Count; i++)
                {
                    writer.WriteLine(Tenants[i]);
                }
            }
        }

        public void Load()
        {
            using (StreamReader reader = new(path))
            {
                Tenants = new List<Tenant>();

                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] data = line.Split(',');
                    Tenants.Add(new Tenant(data[0], data[1], data[2], DateTime.Parse(data[3]), DateTime.Parse(data[4])));
                }
            }
        }
    }
}