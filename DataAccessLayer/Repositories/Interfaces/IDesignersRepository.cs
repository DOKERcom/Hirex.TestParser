using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDesignersRepository
    {
        public Task AddDesigner(DesignerEntity designer);

        public Task DeleteDesigner(DesignerEntity designer);

        public Task UpdateDesigner(DesignerEntity designer);

    }
}
