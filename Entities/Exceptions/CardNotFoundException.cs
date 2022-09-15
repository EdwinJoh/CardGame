using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CardNotFoundException :NotFoundException
    {
        public CardNotFoundException(int id):base($"Card with id {id} does not exsist in the database")
        {

        }
    }
}
