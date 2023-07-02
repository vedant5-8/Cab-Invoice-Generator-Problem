
namespace Cab_Invoice_Generator_Problem
{
    public class InvoiceGeneratorException : Exception
    {
        public enum Type
        {
            INVALID_TIME,
            INVALID_DISTANCE,
            NULL_RIDES,
            INVALID_USERID
        }
        public Type type;
        public InvoiceGeneratorException(Type type, string message):base(message)
        {
            this.type = type;
        }
    }
}
