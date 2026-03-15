namespace BO;

[Serializable]
public class BlNotExistException : Exception
{
    public BlNotExistException(string? message) : base(message) { }
    public BlNotExistException(string message, Exception innerException)
                : base(message, innerException) { }

}

[Serializable]
public class BlAlreadyExistException : Exception
{
    public BlAlreadyExistException(string? message) : base(message) { }
    public BlAlreadyExistException(string message, Exception innerException)
                : base(message, innerException) { }

}

[Serializable]
public class BlException : Exception
{
    public BlException(string? message) : base(message) { }
    public BlException(string message, Exception innerException)
                : base(message, innerException) { }

}