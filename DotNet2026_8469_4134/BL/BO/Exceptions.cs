namespace BO;

[Serializable]
public class BLNotExistException : Exception
{
    public BLNotExistException(string m) : base(m)
    {
    }
}

[Serializable]
public class BLAlreadyExistException : Exception
{
    public BLAlreadyExistException(string m) : base(m)
    {
    }
}
