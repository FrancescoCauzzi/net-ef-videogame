using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class SoftwareHouse
    {
        [Key]
        public long SoftwareHouseId { get; set; }

        [MaxLength(255)]
        public string SoftwareHouseName { get; set; }

        [MaxLength(255)]
        public string SoftwareHouseTaxId { get; set; }

        [MaxLength(255)]
        public string SoftwareHouseCity  { get; set; }

        [MaxLength(255)]
        public string SoftwareHouseCountry { get; set; }

        // relazione uno a molti (la SH produce/possiede molti games)
        public List<Videogame> Videogames { get; set; }

        public override string ToString()
        {
            return SoftwareHouseName;

        }
    }
}
