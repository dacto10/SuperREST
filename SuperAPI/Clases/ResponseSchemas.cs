using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperAPI.Clases
{
    public class ResponseMessageSchema
    {
        public string message
        {
            get; set;
        }
        public ResponseMessageSchema(string msg)
        {
            this.message = msg;
        }
    }

    public class ResponseValuesSchema<T>: ResponseMessageSchema
    {
        public List<T> values
        {
            get; set;
        }
        public ResponseValuesSchema(string msg, List<T> values) : base (msg)
        {
            this.values = values;
        }

    }
}