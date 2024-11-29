using System;
using System.Runtime.Serialization;

namespace DrinkMachine;

public class NoMoneyException : Exception
{
    public NoMoneyException() : base() { }
    public NoMoneyException(string? message) : base(message) { }
    public NoMoneyException(string? message, Exception? innerException) : base(message, innerException) { }
}
