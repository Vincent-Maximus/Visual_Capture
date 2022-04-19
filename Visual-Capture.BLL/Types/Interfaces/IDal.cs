using Visual_Capture.BLL.Entities;

namespace Visual_Capture.BLL.Types.Interfaces;

public interface IDal<T>
{
    public List<Category> Get();

    public void Create(T obj);
    public object Edit(Guid? id);

    public object Delete(Guid? id);


}