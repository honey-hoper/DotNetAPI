using System.ComponentModel;

namespace System
{
    public static class ObjectExtensions
    {
        public static void Print(this Object obj) {
            foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                var name = descriptor.Name;
                var value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }
        }
    }
}