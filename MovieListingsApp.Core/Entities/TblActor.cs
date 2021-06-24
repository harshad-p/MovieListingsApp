using MovieListingsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieListingsApp.Entities
{
    public class TblActor
    {
        public TblActor()
        {
            MovieActors = new HashSet<TblMovieActor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<TblMovieActor> MovieActors { get; set; }

        [Required]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        //public override bool Equals(object obj)
        //{
        //    return obj is TblActor actor && Equals(actor);
        //}

        //public bool Equals(TblActor actor)
        //{
        //    return Id == actor.Id && Name.ToUpper() == actor.Name.ToUpper();
        //}

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Gender);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Gender: {Gender}";
        }

    }
}