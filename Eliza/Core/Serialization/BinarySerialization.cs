using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Eliza.Core.Serialization
{
    class BinarySerialization
    {
        public readonly Stream BaseStream;

        public BinarySerialization(Stream baseStream)
        {
            BaseStream = baseStream;
        }

        protected bool IsList(Type type)
        {
            return typeof(IList).IsAssignableFrom(type);
        }

        protected bool IsDictionary(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        protected IEnumerable<FieldInfo> GetFieldsSorted(Type objectType)
        {
            Stack<Type> typeStack = new Stack<Type>();

            do
            {
                typeStack.Push(objectType);

                objectType = objectType.BaseType;
            }
            while (objectType != null);

            while (typeStack.Count > 0)
            {
                objectType = typeStack.Pop();

                foreach (FieldInfo Info in objectType.GetFields())
                {
                    yield return Info;
                }
            }
        }
    }
}
