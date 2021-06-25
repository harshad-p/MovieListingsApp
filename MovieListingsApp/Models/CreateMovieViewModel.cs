﻿using System.ComponentModel.DataAnnotations;

namespace MovieListingsApp.Models
{
    public class CreateMovieViewModel
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        public int Year { get; set; }
    }
}