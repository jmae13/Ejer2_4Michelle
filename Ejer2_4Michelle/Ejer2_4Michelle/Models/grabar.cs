using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace Ejer2_4Michelle.Models
{
    public class grabar
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
    }
}
