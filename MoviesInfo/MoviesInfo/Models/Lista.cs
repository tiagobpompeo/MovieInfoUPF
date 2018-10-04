using System;
using SQLite;

namespace MoviesInfo.Models
{
    [Table("lista")]
    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        [MaxLength(250), Unique]
        public string Qualquer { get; set; }
    }
}