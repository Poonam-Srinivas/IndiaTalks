using IndiaTalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace IndiaTalks.API.Repositories
{
    public interface IRegionRepository
    {
        //now create definitions for all methods as we need to pass all the dbcontext through repository
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);
        //
        //Task GetById(Guid id);
        Task <Region?> UpdateAsync(Guid id, Region region);

        Task<Region?> DeleteAsync(Guid id);
    }
}
 