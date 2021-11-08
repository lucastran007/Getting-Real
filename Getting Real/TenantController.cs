using System;
using System.Collections.Generic;

namespace Getting_Real
{
    public class TenantController
    {
        private TenantRepo tenantRepo;

        public TenantController()
        {
            tenantRepo = new TenantRepo();
        }

        public void PrintTenants()
        {
            List<Tenant> tenants = tenantRepo.GetListOfTenants();
            for (int i = 0; i < tenants.Count; i++)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Navn: " + tenants[i].Name);
                Console.WriteLine("Telefon nummer: " + tenants[i].Phone);
                Console.WriteLine("E-mail: " + tenants[i].Email);
                Console.WriteLine("");
                Console.WriteLine("Indflytnings dag: " + tenants[i].MoveInDate);
                Console.WriteLine("Udflytnings dag: " + tenants[i].MoveOutDate);
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}