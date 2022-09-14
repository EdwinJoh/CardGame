using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Commons
{
    public interface ICard
    {
        public int Rank { get; set; }
        public CardSuit Suits { get; set; }
    }
}
