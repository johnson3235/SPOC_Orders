using DB_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repo_Layer.Repositry;
using Repo_Layer.Repositry.Branch_Repo;
using Repo_Layer.Repositry.Order_Repo;
using Repo_Layer.Repositry.Pharmacy_Repo;

namespace Repo_Layer.UnitOfWork
{
    public interface IUnitOFWork
    {

            IRepository<Country> Country_Repo { get; }

            IOrderRepository Order_Repo { get; }

             IPharmacyRepository Pharmacy_Repo { get; }

            IBranchRepository Branch_Repo { get; }
            IRepository<Product> Product_Repo { get; }
            IRepository<Distributor> Distributor_Repo { get; }
            IRepository<Order_Products> Order_Products_Repo { get; }
            IRepository<Role> Role_Repo { get; }

            public UserManager<CustomUser> User_Repo { get; }
        public int Save();

        Task<int> SaveChangesAsync();
    }
}
