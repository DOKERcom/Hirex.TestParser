using DataAccessLayer.Entities;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirex.TestParser.BLL.Services.Interfaces
{
    public interface IWorksService
    {
        public Task AddWork(WorkModel work);

        public Task DeleteWork(string link);

        public Task UpdateWork(WorkModel work);

        public Task<WorkEntity> GetWorkByLink(string workLink);

        public Task<WorkEntity> GetWorkById(int workId);
    }
}
