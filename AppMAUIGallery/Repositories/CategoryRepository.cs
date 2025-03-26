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
                    Page = typeof(StackLayoutPage)
                },
                new Component
                {
                    Title = "Grid",
                    Description = "Organiza os elementos dentro de uma tabela",
                    Page = typeof(GridLayoutPage)
                },
                new Component
                {
                    Title = "AbsoluteLayout",
                    Description = "Liberdade total para posicionar e domensionar os elementos na tela.",
                    Page = typeof(AbsoluteLayoutPage)
                },
                new Component
                {
                    Title = "FlexLayout",
                    Description = "Organiza os elementos de forma sequencial com muitas opções de personalização.",
                    Page = typeof(FlexLayoutPage)
                }
            }
        });
        
        return categories;
    }
}
