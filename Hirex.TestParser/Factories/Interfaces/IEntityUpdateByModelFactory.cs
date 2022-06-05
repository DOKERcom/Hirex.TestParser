using DataAccessLayer.Entities;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.BLL.Factories.Interfaces
{
    public interface IEntityUpdateByModelFactory
    {
        public DesignerEntity EntityUpdateByModel(DesignerEntity entity, DesignerModel model);
    }
}
