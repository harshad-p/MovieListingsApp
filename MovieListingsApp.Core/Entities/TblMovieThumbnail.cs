using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieListingsApp.Entities
{
    public class TblMovieThumbnail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public TblMovie Movie { get; set; }

        [Required]
        public DateTime TimeStampUtc { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}