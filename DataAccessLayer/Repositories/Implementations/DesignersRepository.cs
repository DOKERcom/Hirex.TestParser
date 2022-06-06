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

        public async Task<int> AddWorkToDesignerById(int designerId, int workId)
        {
            DesignerEntity designer = db.Designers.Include(p => p.Works).First(p => p.Id == designerId);
            WorkEntity work = await workRepository.GetWorkById(workId);
            designer.Works.Add(work);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteWorkFromDesignerById(int designerId, int workId)
        {
            WorkEntity work = db.Works.Include(p=>p.Designers).First(p => p.Id == workId);
            DesignerEntity designer = work.Designers.First(p => p.Id == designerId);
            designer.Works.Remove(work);
            return await db.SaveChangesAsync();
        }
    }
}
