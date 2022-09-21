using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class EmailTemplate
    {
        [Key]
        public int id { get; set; }
        public string key_name { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        //Relationships
    }
}
