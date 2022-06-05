using DataAccessLayer.DbContexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class WorkRepository : IWorkRepository
    {
        HirexDbContext db;
        public WorkRepository(HirexDbContext db)
        {
            this.db = db;
        }
        public async Task AddWork(WorkEntity work)
        {
            await db.Works.AddAsync(work);
            await db.SaveChangesAsync();
        }

        public async Task DeleteWork(WorkEntity work)
        {
            db.Works.Remove(work);
            await db.SaveChangesAsync();
        }

        public async Task UpdateWork(WorkEntity work)
        {
            db.Works.Update(work);
            await db.SaveChangesAsync();
        }
    }
}
