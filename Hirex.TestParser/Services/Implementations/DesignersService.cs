using DataAccessLayer.Repositories.Interfaces;
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

        public DesignersService(
            IDesignersRepository designersRepository, 
            IModelToEntityFactory modelToEntityFactory
            )
        {
            this.designersRepository = designersRepository;
            this.modelToEntityFactory = modelToEntityFactory;
        }

        public async Task AddDesigner(DesignerModel designer)
        {
            await designersRepository.AddDesigner(modelToEntityFactory.DesignerModelToEntity(designer));
        }

        public async Task DeleteDesigner(DesignerModel designer)
        {
            await designersRepository.DeleteDesigner(modelToEntityFactory.DesignerModelToEntity(designer));
        }

        public async Task UpdateDesigner(DesignerModel designer)
        {
            await designersRepository.UpdateDesigner(modelToEntityFactory.DesignerModelToEntity(designer));
        }
    }
}
