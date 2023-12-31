﻿using MovieTask.Entities;
using MovieTask.Repositories.Abstract;
using MovieTask.Services.Abstract;
using System.Linq.Expressions;

namespace MovieTask.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void Add(Movie entity)
        {
            _movieRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var item = _movieRepository.Get(s => s.Id == id);
            _movieRepository.Delete(item);
        }

        public Movie Get(Expression<Func<Movie, bool>> expression)
        {
            return _movieRepository.Get(expression);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public void Update(Movie entity)
        {
            _movieRepository.Update(entity);
        }
    }
}
