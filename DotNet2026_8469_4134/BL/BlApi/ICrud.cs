
namespace BlApi;

public interface ICrud<T>
{
    int Create(T item);
    List<T?> ReadAll(Func<T, bool>? filter = null);
    T? Read(Func<T, bool> filter); 
    void Update(T item);
    void Delete(int id);
}
