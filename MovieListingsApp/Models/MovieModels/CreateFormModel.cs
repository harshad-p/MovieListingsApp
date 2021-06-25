using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieListingsApp.Models.MovieModels
{
    public class CreateFormModel
    {
        public CreateFormModel()
        {
            Actors = new HashSet<SelectListItem>();
        }

        public ICollection<SelectListItem> Actors { get; set; }
    }
}