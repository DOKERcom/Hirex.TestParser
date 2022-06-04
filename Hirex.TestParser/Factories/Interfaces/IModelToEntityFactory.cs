using DataAccessLayer.Entities;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.Factories.Interfaces
{
    public interface IModelToEntityFactory
    {
        public DesignerEntity DesignerModelToEntity(DesignerModel designerModel);

        public WorkEntity WorkModelToEntity(WorkModel workModel);
    }
}
