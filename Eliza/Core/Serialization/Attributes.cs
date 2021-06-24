using System;

namespace Eliza.Core.Serialization
{
    class Attributes
    {
        [AttributeUsage(AttributeTargets.Field)]
        public class LengthAttribute : Attribute
        {
            public int Size { get; set; }
            public int Max { get; set; }
            public TypeCode Type { get; set; }
        }

        [AttributeUsage(AttributeTargets.Field)]
        public class MessagePackListAttribute : Attribute {}

        [AttributeUsage(AttributeTargets.Field)]
        public class MessagePackRawAttribute : Attribute { }
    }
}
