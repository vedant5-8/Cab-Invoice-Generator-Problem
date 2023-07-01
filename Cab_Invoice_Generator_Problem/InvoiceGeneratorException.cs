using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator_Problem
{
    public class InvoiceGeneratorException : Exception
    {
        public enum Type
        {
            INVALID_TIME,
            INVALID_DISTANCE
        }
        public Type type;
        public InvoiceGeneratorException(Type type, string message):base(message)
        {
            this.type = type;
        }
    }
}
