using Maxim.Business.ViewModels.Feature;
using Maxim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        public Task<IQueryable<Feature>> GetAllAsync();
        public Task<Feature> GetByIdAsync(int id);
        public Task CreateAsync(CreateFeatureVm vm);
        public Task UpdateAsync(UpdateFeatureVm vm);
        public Task Delete(int id);
    }
}
