using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IWorkRepository
    {
        public Task AddWork(WorkEntity work);

        public Task DeleteWork(string link);

        public Task UpdateWork(WorkEntity work);

        public Task<WorkEntity> GetWorkByLink(string workLink);

        public Task<WorkEntity> GetWorkById(int workId);
    }
}
