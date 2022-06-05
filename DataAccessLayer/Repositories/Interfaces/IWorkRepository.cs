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

        public Task DeleteWork(WorkEntity work);

        public Task UpdateWork(WorkEntity work);
    }
}
