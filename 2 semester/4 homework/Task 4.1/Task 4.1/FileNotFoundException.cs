using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    /// <summary>
    /// Это исключение создается, когда попытка доступа к файлу, не существующему на диске, заканчивается неудачей
    /// </summary>
    [Serializable]
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException() { }
        public FileNotFoundException(string message) : base(message) { }
        public FileNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected FileNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
