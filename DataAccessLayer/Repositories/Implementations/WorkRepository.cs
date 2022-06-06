using DataAccessLayer.DbContexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task DeleteWork(string link)
        {
            db.Works.Remove(await db.Works.Where(d => d.WorkLink == link).FirstOrDefaultAsync());
            await db.SaveChangesAsync();
        }

        public async Task UpdateWork(WorkEntity work)
        {
            db.Works.Update(work);
            await db.SaveChangesAsync();
        }

        public async Task<WorkEntity> GetWorkByLink(string workLink)
        {
            return await db.Works.Where(d => d.WorkLink == workLink).FirstOrDefaultAsync();
        }

        public async Task<WorkEntity> GetWorkById(int workId)
        {
            return await db.Works.Where(d => d.Id == workId).FirstOrDefaultAsync();
        }
    }
}
