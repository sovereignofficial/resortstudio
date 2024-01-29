using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.entity
{
    [Table("cabins")]
    public class Cabin : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public string CreatedAt { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("maxCapacity")]
        public int MaxCapacity { get; set; }

        [Column("regularPrice")]
        public int RegularPrice { get; set; }

        [Column("discount")]
        public int Discount { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("isFull")]
        public bool IsFull { get; set; }

    }
}
