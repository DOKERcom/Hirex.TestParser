using DataAccessLayer.Entities;
using Hirex.TestParser.Factories.Interfaces;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.Factories.Implementations
{
    public class ModelToEntityFactory : IModelToEntityFactory
    {
        public DesignerEntity DesignerModelToEntity(DesignerModel designerModel)
        {
            List<WorkEntity> works = new List<WorkEntity>();

            if (designerModel.Works.Count > 0)
                foreach (var work in designerModel.Works)
                    works.Add(WorkModelToEntity(work));

            return new DesignerEntity 
            { 
                Link = designerModel.Link,
                Name = designerModel.Name,
                Works = works,
            };
        }

        public WorkEntity WorkModelToEntity(WorkModel workModel)
        {
            List<DesignerEntity> designers = new List<DesignerEntity>();

            if (workModel.Designers.Count > 0)
                foreach (var desinger in workModel.Designers)
                    designers.Add(DesignerModelToEntity(desinger));

            return new WorkEntity
            {
                WorkLink = workModel.WorkLink,
                WorkName = workModel.WorkName,
                Designers = designers,
            };
        }
    }
}
