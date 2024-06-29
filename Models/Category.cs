using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookWeb.Models;

public class Category{
    [Key]
    public int id { get; set; }
    [Required]
    public String Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

}