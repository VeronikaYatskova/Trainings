using Microsoft.EntityFrameworkCore;
using Trainings.Data.Context;
using Trainings.Data.Models;
using Trainings.Data.Repositories.Abstracts;

namespace Trainings.Data.Repositories
{
    public class TechnologyRepository : RepositoryBase<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Technology>> GetTechnologies() =>
            await FindAll().ToListAsync();       
    }
}
