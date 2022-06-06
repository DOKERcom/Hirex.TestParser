using DataAccessLayer.Entities;
using Hirex.TestParser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirex.TestParser.Services.Interfaces
{
    public interface IDesignersService
    {
        public Task AddDesigner(DesignerModel designer);

        public Task DeleteDesigner(string link);

        public Task UpdateDesigner(DesignerModel designer);

        public Task<DesignerEntity> GetDesignerByLink(string link);

        public Task DeleteAllDesignerWorks(string link);

        public Task<int> AddWorkToDesignerById(int designerId, int workId);

        public Task<int> DeleteWorkFromDesignerById(int designerId, int workId);
    }
}
