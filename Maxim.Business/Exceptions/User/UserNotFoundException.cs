using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Exceptions.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("The user is not found.")
        {

        }
        public UserNotFoundException(string? message) : base(message)
        {
        }
    }
}
