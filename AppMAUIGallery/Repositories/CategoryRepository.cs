using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Layouts;

namespace AppMAUIGallery.Repositories;

public class CategoryRepository
{
    public CategoryRepository()
    {
    }
    
    public List<Category> GetCategories()
    {
        var categories = new List<Category>();

        categories.Add(new Category
        {
            Name = "Layout",
            Components = new List<Component>
            {
                new Component
                {
                    Title = "StackLayout",
                    Description = "Organização sequencial dos elementos.",
                    Page = new StackLayoutPage()
                }
            }
        });
        
        return categories;
    }
}
