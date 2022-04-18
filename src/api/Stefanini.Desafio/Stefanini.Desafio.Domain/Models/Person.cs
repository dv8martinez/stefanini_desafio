using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Desafio.Domain.Models
{
   
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public virtual int? CityId { get; set; }

        [ForeignKey("CityId")]
        public City CityFk { get; set; }
    }
}
