
namespace DalApi;

public interface ICrud<T>
{
    int Create(T item);
    List<T> ReadAll();
    T? Read(Func<T, bool> filter); 
    void Update(T item);
    void Delete(int id);
}
