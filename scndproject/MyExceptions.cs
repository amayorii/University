using System;

namespace scndproject;

public class ZeroOrNegativeNumberException : Exception
{
    public ZeroOrNegativeNumberException() { }

    public ZeroOrNegativeNumberException(string message) : base(message) { }

    public ZeroOrNegativeNumberException(string message, Exception inner) : base(message, inner) { }
}

public class CantExistException : Exception
{
    public CantExistException() { }

    public CantExistException(string message) : base(message) { }

    public CantExistException(string message, Exception inner) : base(message, inner) { }
}

public class SideAccessingException : Exception
{
    public SideAccessingException() { }

    public SideAccessingException(string message) : base(message) { }

    public SideAccessingException(string message, Exception inner) : base(message, inner) { }
}
