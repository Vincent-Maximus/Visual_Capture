namespace Visual_Capture.Contracts.Interfaces;

public interface IDal<T>
{
    public List<T> GetAll();
    public T Get(Guid? id);
    public bool Create(T obj);
    public bool Update(T obj);
    public bool Delete(Guid? id);
}
