namespace Dal;

public class NotExistException : Exception
{
    public NotExistException(string m) : base(m)
    {
    }
}

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string m) : base(m)
    {
    }
}