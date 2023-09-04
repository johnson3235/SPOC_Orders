using DB_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repo_Layer.Repositry;
using Repo_Layer.Repositry.Branch_Repo;
using Repo_Layer.Repositry.Order_Repo;
using Repo_Layer.Repositry.Pharmacy_Repo;

namespace Repo_Layer.UnitOfWork
{
    public class UnitOFWork : IUnitOFWork
    {
        private readonly DataDbContext _context;

        public IRepository<Country> Country_Repo { get; private set; }
        public IOrderRepository Order_Repo { get; private set; }
        public IPharmacyRepository Pharmacy_Repo { get; private set; }
        public IBranchRepository Branch_Repo { get; private set; }
        public IRepository<Product> Product_Repo { get; private set; }
        public IRepository<Distributor> Distributor_Repo { get; private set; }
        public IRepository<Order_Products> Order_Products_Repo { get; private set; }
        public IRepository<Role> Role_Repo { get; private set; }
        
        public UserManager<CustomUser> User_Repo { get; private set; }

        public UnitOFWork(DataDbContext context, IRepository<Country> Country_Repo, IOrderRepository Order_Repo,
            IPharmacyRepository Pharmacy_Repo, IBranchRepository Branch_Repo , IRepository<Product> Product_Repo, IRepository<Distributor> Distributor_Repo,
            IRepository<Order_Products> Order_Products_Repo, IRepository<Role> Role_Repo, UserManager<CustomUser> User_Repo)
        {
            this._context = context;
            this.Country_Repo = Country_Repo;
            this.Order_Repo = Order_Repo;
            this.Pharmacy_Repo = Pharmacy_Repo;
            this.Branch_Repo = Branch_Repo;
            this.Product_Repo = Product_Repo;
            this.Distributor_Repo = Distributor_Repo;
            this.Order_Products_Repo = Order_Products_Repo;
            this.Role_Repo = Role_Repo;
            this.User_Repo = User_Repo;
     

        }


        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }



    }
}
