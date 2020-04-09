using System;

namespace WebAPIApp
{
    public class Result<T>
    {
        public T Data { get; set; }
        public Exception Exception { get; set; }

        public bool IsSuccessful()
        {
            return Data != null;
        }
    }
}