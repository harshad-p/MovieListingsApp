﻿using MovieListingsApp.Models;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.Services
{
    public interface IMoviesService
    {
        Task<int> CreateAsync(CreateMovieViewModel createMovieViewModel);
    }
}