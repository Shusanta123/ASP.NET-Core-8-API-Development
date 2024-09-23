namespace UniversityManagementSystem.DLL.Models;


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
}
