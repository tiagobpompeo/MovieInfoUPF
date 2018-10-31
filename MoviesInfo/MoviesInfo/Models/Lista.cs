using System;
using SQLite;

namespace MoviesInfo.Models
{
    [Table("lista")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        [MaxLength(250), Unique]
        public string DataBirth { get; set; }

        [MaxLength(250), Unique]
        public string Telephone { get; set; }

        [MaxLength(250), Unique]
        public string Genre { get; set; }

        [MaxLength(250), Unique]
        public string Nationality { get; set; }

        [MaxLength(250), Unique]
        public string States { get; set; }

        [MaxLength(250), Unique]
        public string City { get; set; }

        [MaxLength(250), Unique]
        public string Neighborhood { get; set; }
    }
}