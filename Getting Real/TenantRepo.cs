using System;
using System.IO;
using System.Collections.Generic;

namespace Getting_Real
{
    public class TenantRepo
    {
        private List<Tenant> tenants;

        private string path = "../../../Tenants.txt";

        public TenantRepo()
        {
            Load();
        }

        public List<Tenant> GetListOfTenants()
        {
            return tenants;
        }

        public void Save()
        {
            using (StreamWriter writer = new(path))
            {
                for (int i = 0; i < tenants.Count; i++)
                {
                    writer.WriteLine(tenants[i]);
                }
            }
        }

        public void Load()
        {
            using (StreamReader reader = new(path))
            {
                tenants = new List<Tenant>();

                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] data = line.Split(',');
                    tenants.Add(new Tenant(data[0], data[1], data[2], DateTime.Parse(data[3]), DateTime.Parse(data[4])));
                }
            }
        }
    }
}