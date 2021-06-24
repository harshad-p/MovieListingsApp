using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieListingsApp.Entities
{
    public class TblMovie
    {
        public TblMovie()
        {
            MovieActors = new HashSet<TblMovieActor>();
            Thumbnails = new HashSet<TblMovieThumbnail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<TblMovieActor> MovieActors { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int Year { get; set; }

        public ICollection<TblMovieThumbnail> Thumbnails { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TblMovie movie && Equals(movie);
        }

        public bool Equals(TblMovie movie)
        {
            return Id == movie.Id && Title.ToUpper() == movie.Title.ToUpper();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}";
        }

    }
}