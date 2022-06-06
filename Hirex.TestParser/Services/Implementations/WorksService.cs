using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Hirex.TestParser.BLL.Factories.Interfaces;
using Hirex.TestParser.BLL.Services.Interfaces;
using Hirex.TestParser.Factories.Interfaces;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirex.TestParser.BLL.Services.Implementations
{
    public class WorksService : IWorksService
    {
        private readonly IWorkRepository workRepository;

        private readonly IModelToEntityFactory modelToEntityFactory;

        IEntityUpdateByModelFactory entityUpdateByModelFactory;
        public WorksService(IWorkRepository workRepository, IModelToEntityFactory modelToEntityFactory, IEntityUpdateByModelFactory entityUpdateByModelFactory)
        {
            this.workRepository = workRepository;
            this.modelToEntityFactory = modelToEntityFactory;
            this.entityUpdateByModelFactory = entityUpdateByModelFactory;
        }
        public async Task AddWork(WorkModel work)
        {
            await workRepository.AddWork(modelToEntityFactory.WorkModelToEntity(work));
        }

        public async Task DeleteWork(string link)
        {
           await workRepository.DeleteWork(link);
        }

        public async Task UpdateWork(WorkModel work)
        {
            WorkEntity workEntity = await workRepository.GetWorkByLink(work.WorkLink);

            if (workEntity != null)
                await workRepository.UpdateWork(entityUpdateByModelFactory.EntityUpdateByModel(workEntity, work));
        }

        public async Task<WorkEntity> GetWorkByLink(string workLink)
        {
            return await workRepository.GetWorkByLink(workLink);
        }

        public async Task<WorkEntity> GetWorkById(int workId)
        {
            return await workRepository.GetWorkById(workId);
        }
    }
}
