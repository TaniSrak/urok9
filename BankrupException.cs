using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urok9
{
    internal class BankrupException : Exception
    {
        //исключения о банкротстве
        public BankrupException(string message) : base (message)
        { 
            
        }

    }
}
