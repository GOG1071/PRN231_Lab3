using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

public class Category : IModel
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, StringLength(40)]
    public string CategoryName { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}