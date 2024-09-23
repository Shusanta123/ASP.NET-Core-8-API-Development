namespace UniversityManagementSystem.DLL.Models;


public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }

    public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
}
