using DataAccessLayer.DbContexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class DesignersRepository : IDesignersRepository
    {
        HirexDbContext db;
        public DesignersRepository(HirexDbContext db) 
        {
            this.db = db;
        }
        public async Task AddDesigner(DesignerEntity designer)
        {
            await db.AddAsync(designer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteDesigner(DesignerEntity designer)
        {
            db.Remove(designer);
            await db.SaveChangesAsync();
        }

        public async Task UpdateDesigner(DesignerEntity designer)
        {
            db.Update(designer);
            await db.SaveChangesAsync();
        }
    }
}
