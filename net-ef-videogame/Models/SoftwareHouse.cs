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

        public string SoftwareHouseName { get; set; }
        public string SoftwareHouseTaxId { get; set; }
        public string SoftwareHouseCity  { get; set; }
        public string SoftwareHouseCountry { get; set; }

        // relazione uno a molti (la SH produce possiede molti games)
        public List<Videogame> Videogame { get; set; }
    }
}
