using System;

namespace TicTacToe.Infrastructure.IoC
{
    public class TypedParameter
    {
        public Type Type { get; }
        public object Value { get; }

        public TypedParameter(Type type, object value)
        {
            Type = type;
            Value = value;
        }
    }
}