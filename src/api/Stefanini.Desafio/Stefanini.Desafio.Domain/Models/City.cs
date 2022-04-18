using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Desafio.Domain.Models
{
    [Table("City")]
    public class City
    {

        public int CityId { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }
        
        [NotMapped]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
