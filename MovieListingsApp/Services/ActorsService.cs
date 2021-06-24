using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Contracts.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MovieListingsApp.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IActorsRepository _actorsRepository;

        public ActorsService(IActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        public async Task Test()
        {
            var actors = await _actorsRepository.GetAllHeavyAsync();
            var count = actors.Count();
        }
    }
}