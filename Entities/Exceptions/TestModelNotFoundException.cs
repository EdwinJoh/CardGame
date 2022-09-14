using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class TestModelNotFoundException :NotFoundException
    {
        public TestModelNotFoundException(int id) : base($"The Model with Id {id} does not exist in the database")
        {

        }
    }
}
