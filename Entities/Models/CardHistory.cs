using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CardHistory
    {
   
        public int Id { get; set; }
        public string CardOne { get; set; }
        public string CardTwo { get; set; }
        public string CardThree { get; set; }
        public string CardFour { get; set; }
        public string CardFive { get; set; }
    }
}
