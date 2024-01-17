using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Exceptions.Feature
{
    public class FeatureNotFoundException : Exception
    {
        public FeatureNotFoundException() : base("The feature not found.")
        {

        }
        public FeatureNotFoundException(string? message) : base(message)
        {
        }
    }
}
