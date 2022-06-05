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
    public class DesignersRepository : IDesignersRepository
    {
        HirexDbContext db;

        IWorkRepository workRepository;
        public DesignersRepository(HirexDbContext db, IWorkRepository workRepository)
        {
            this.db = db;
            this.workRepository = workRepository;
        }
        public async Task AddDesigner(DesignerEntity designer)
        {
            await db.Designers.AddAsync(designer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteDesigner(string link)
        {
            db.Designers.Remove(await db.Designers.Where(d => d.Link == link).FirstOrDefaultAsync());
            await db.SaveChangesAsync();
        }

        public async Task UpdateDesigner(DesignerEntity designer)
        {
            db.Designers.Update(designer);
            await db.SaveChangesAsync();
        }

        public async Task<DesignerEntity> GetDesignerByLink(string link)
        {
           return await db.Designers.Where(d => d.Link == link).Include(d=>d.Works).FirstOrDefaultAsync();
        }

        public async Task DeleteAllDesignerWorks(string link)
        {
            DesignerEntity designer = await db.Designers.Where(d=>d.Link == link).Include(p => p.Works).FirstOrDefaultAsync();
            designer.Works.Clear();
            await db.SaveChangesAsync();
        }
    }
}
