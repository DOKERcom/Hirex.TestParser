using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDesignersRepository
    {
        public Task AddDesigner(DesignerEntity designer);

        public Task DeleteDesigner(string link);

        public Task UpdateDesigner(DesignerEntity designer);

        public Task<DesignerEntity> GetDesignerByLink(string link);

        public Task DeleteAllDesignerWorks(string link);

        public Task<int> AddWorkToDesignerById(int designerId, int workId);

        public Task<int> DeleteWorkFromDesignerById(int designerId, int workId);

    }
}
