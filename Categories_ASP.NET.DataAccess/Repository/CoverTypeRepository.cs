using Categories_ASP.NET.DataAccess.Data;
using Categories_ASP.NET.DataAccess.Repository.IRepository;
using Categories_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories_ASP.NET.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
