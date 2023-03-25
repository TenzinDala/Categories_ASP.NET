using Categories_ASP.NET.DataAccess.Data;
using Categories_ASP.NET.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories_ASP.NET.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(db);
            CoverType = new CoverTypeRepository(db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
