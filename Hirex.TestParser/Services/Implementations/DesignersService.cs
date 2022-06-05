using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Hirex.TestParser.BLL.Factories.Interfaces;
using Hirex.TestParser.Factories.Interfaces;
using Hirex.TestParser.Models;
using Hirex.TestParser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirex.TestParser.Services.Implementations
{
    public class DesignersService : IDesignersService
    {
        IDesignersRepository designersRepository;

        IModelToEntityFactory modelToEntityFactory;

        IEntityUpdateByModelFactory entityUpdateByModelFactory;

        public DesignersService(
            IEntityUpdateByModelFactory entityUpdateByModelFactory,
            IDesignersRepository designersRepository, 
            IModelToEntityFactory modelToEntityFactory
            
            )
        {
            this.designersRepository = designersRepository;
            this.modelToEntityFactory = modelToEntityFactory;
            this.entityUpdateByModelFactory = entityUpdateByModelFactory;
        }

        public async Task AddDesigner(DesignerModel designer)
        {
            await designersRepository.AddDesigner(modelToEntityFactory.DesignerModelToEntity(designer));
        }

        public async Task DeleteDesigner(string link)

        {
            if (await designersRepository.GetDesignerByLink(link) != null)
                await designersRepository.DeleteDesigner(link);
        }

        public async Task UpdateDesigner(DesignerModel designer)
        {
            DesignerEntity designerEntity = await designersRepository.GetDesignerByLink(designer.Link);

            if (designerEntity != null)
                await designersRepository.UpdateDesigner(entityUpdateByModelFactory.EntityUpdateByModel(designerEntity, designer));
        }
    }
}
