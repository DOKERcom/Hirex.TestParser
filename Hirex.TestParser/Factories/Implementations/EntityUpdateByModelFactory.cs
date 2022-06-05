using DataAccessLayer.Entities;
using Hirex.TestParser.BLL.Factories.Interfaces;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.BLL.Factories.Implementations
{
    public class EntityUpdateByModelFactory : IEntityUpdateByModelFactory
    {
        public DesignerEntity EntityUpdateByModel(DesignerEntity entity, DesignerModel model)
        {
            return new DesignerEntity();
            //TODO Factory Entity+Model
        }
    }
}
