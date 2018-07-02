using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Greenfinch.Newsletter.Web.Core.Models.Exceptions
{
    /// <summary>
    /// Base class for Application Custom Exceptions
    /// </summary>
    [Serializable]
    public class BaseException : Exception, ISerializable
    {

        public BaseException()
            : base()
        {
        }


        public BaseException(string message)
            : base(message)
        {
        }

        public BaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
