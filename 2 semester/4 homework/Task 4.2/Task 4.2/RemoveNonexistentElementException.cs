using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._2
{
    [Serializable]
    public class RemoveNonexistentElementException : Exception
    {
        public RemoveNonexistentElementException() { }
        public RemoveNonexistentElementException(string message) : base(message) { }
        public RemoveNonexistentElementException(string message, Exception inner) : base(message, inner) { }
        protected RemoveNonexistentElementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
