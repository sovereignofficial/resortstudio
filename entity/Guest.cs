using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.entity
{
    [Table("guests")]
    public class Guest : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public string CreatedAt { get; set; }

        [Column("fullName")]
        public string FullName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("nationality")]
        public string Nationality { get; set; }

        [Column("countryFlag")]
        public string CountryFlag { get; set; }

        [Column("nationalID")]
        public string NationalId { get; set; }
    }
}
