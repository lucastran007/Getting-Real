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
                    tenants.Add(new Tenant(data[0], data[1], data[2], DateTime.Parse(data[3]), DateTime.Parse(data[4]), data[5], int.Parse(data[6]), int.Parse(data[7]), bool.Parse(data[8])));
                }
            }
        }

        public Tenant FindTenant(string Name)
        {
            Tenant tenant = null;
            int i = 0;
            while (i < tenants.Count && tenant == null)
            {
                if (tenants[i].Name == Name)
                    tenant = tenants[i];
                i++;
            }
            return tenant;
        }
    }
}