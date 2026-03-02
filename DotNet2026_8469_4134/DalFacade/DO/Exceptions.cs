namespace Do;

[Serializable]
public class DalNotExistException : Exception
{
    public DalNotExistException(string m) : base(m)
    {
    }
}

[Serializable]
public class DalAlreadyExistException : Exception
{
    public DalAlreadyExistException(string m) : base(m)
    {
    }
}