namespace Visual_Capture.Contracts.Interfaces;

public interface IManagerDal<T>
{
    public List<T> GetAll();
    public T Get(Guid? id);
    public bool Create(T obj);
    public bool Edit(T obj);
    public bool Delete(Guid? id);
}
