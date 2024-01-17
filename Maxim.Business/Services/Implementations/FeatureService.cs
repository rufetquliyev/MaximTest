using AutoMapper;
using Maxim.Business.Exceptions.Common;
using Maxim.Business.Services.Interfaces;
using Maxim.Business.ViewModels.Feature;
using Maxim.Core.Entities;
using Maxim.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _repository;
        private readonly IMapper _mapper;

        public FeatureService(IFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateFeatureVm vm)
        {
            Feature feature = _mapper.Map<Feature>(vm);
            await _repository.CreateAsync(feature);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            Feature feature = await _repository.GetByIdAsync(id);
            await _repository.Delete(feature);
            await _repository.SaveChangesAsync();
        }

        public async Task<IQueryable<Feature>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Feature> GetByIdAsync(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            Feature feature = await _repository.GetByIdAsync(id);
            return feature;
        }

        public async Task UpdateAsync(UpdateFeatureVm vm)
        {
            Feature feature = _mapper.Map<Feature>(vm);
            await _repository.UpdateAsync(feature);
            await _repository.SaveChangesAsync();
        }
    }
}
