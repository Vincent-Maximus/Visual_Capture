using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_Capture.BLL.Entities;

public class Category
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,100, ErrorMessage = "Display Order must between 1 and 100 only")]
    public int DisplayOrder { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
}