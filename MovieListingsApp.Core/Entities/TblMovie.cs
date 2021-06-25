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
        public ICollection<TblMovieThumbnail> Thumbnails { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int Year { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TblMovie movie && Equals(movie);
        }

        public bool Equals(TblMovie movie)
        {
            // Cannot simply check equality based on Id. 
            // If multiple movies are added at the same time, 
            // the Id will be 0, since the database hasn't generated the Id yet automatically. 
            // Hence, they will be considered as the same movie. 
            // 
            // So, no way a movie with the same Title can have the 
            // same Description and be released in the same year. 
            return Id == movie.Id
                && Title.ToUpper() == movie.Title.ToUpper() 
                && Description.ToUpper() == movie.Description.ToUpper() 
                && Year == movie.Year;
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