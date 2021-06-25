using MovieListingsApp.Contracts.FormModelGenerators;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Models.MovieModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MovieListingsApp.FormModelGenerators
{
    public class MovieFormModelGenerators : IMovieFormModelGenerators
    {
        private readonly IActorsRepository _actorsRepository;

        public MovieFormModelGenerators(IActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        public async Task<CreateFormModel> GetCreateFormModelAsync()
        {
            try
            {
                var createFormModel = new CreateFormModel();

                var actors = await _actorsRepository.GetAllAsync();
                foreach(var actor in actors)
                {
                    createFormModel.Actors.Add(new SelectListItem()
                    {
                        Text = actor.Name, 
                        Value = actor.Id.ToString()
                    });
                }

                return createFormModel;
            }
            catch (Exception)
            {
                // log exception. 
                return null;
            }
        }
    }
}