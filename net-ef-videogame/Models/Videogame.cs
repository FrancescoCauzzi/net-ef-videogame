using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Videogame
    {
        // properties
        // convection the Id will be always the primary key for the EF framework
        [Key]
        public long Id { get; private set; }

        [MaxLength(255)]
        public string Name { get; private set; }

        public string Overview { get; private set; }

        public DateTime ReleaseDate { get; private set; }


        // relazione uno a molti, ogni videogame può avere solo una sh che lo produce ma la sh produce più videogames
        public long SoftwareHouseId { get; private set; }
        public SoftwareHouse? SoftwareHouse { get; private set; }

        // Constructor
        public Videogame(string name, string overview, DateTime releaseDate, long softwareHouseId)
        {

            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }



        // override ToSTring()
        public override string ToString()
        {
            return @$"
Videogame Id: {Id} 
Name: {Name} 
Overview: {Overview} 
ReleaseDate: {ReleaseDate.Day}/{ReleaseDate.Month}/{ReleaseDate.Year} 
SoftwareHouseId: {SoftwareHouseId}";
        }
    }
}
