using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Exceptions
{
    public class HouseRentingExceptions : ApplicationException
    {

        public HouseRentingExceptions()
        {

        }

        public HouseRentingExceptions(string errorMessage)
            : base(errorMessage)
        {

        }


    }
}
