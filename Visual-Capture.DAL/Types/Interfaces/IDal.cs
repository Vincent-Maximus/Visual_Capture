using Visual_Capture.DAL.DTO;

namespace Visual_Capture.DAL.Types.Interfaces;


public interface IDal<T>
{
    public List<CategoryDTO> Get();

    public void Create(T obj);
    public object Edit(Guid? id);

    public object Delete(Guid? id);


}