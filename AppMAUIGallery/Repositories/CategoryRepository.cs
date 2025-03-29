using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Components.Visuals;
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
        
        categories.Add(new Category
        {
            Name = "Componentes(Views)",
            Components = new List<Component>
            {
                new Component
                {
                    Title = "BoxView",
                    Description = "Um componente que cria uma caixa para ser apresentada.",
                    Page = typeof(BoxViewPage)
                },
                new Component
                {
                    Title = "Label",
                    Description = "Apresenta um texto na tela",
                    Page = typeof(LabelPage)
                },
                new Component
                {
                    Title = "Button",
                    Description = "Apresenta um botão na tela.",
                    Page = typeof(ButtonPage)
                },
                new Component
                {
                    Title = "Image",
                    Description = "Apresenta uma imagem na tela.",
                    Page = typeof(ImagePage)
                },
                new Component
                {
                    Title = "ImageButton",
                    Description = "Apresenta uma imagem com comportamento de botão.",
                    Page = typeof(ImageButtonPage)
                }
            }
        });

        categories.Add(new Category
        {
            Name = "Visuais",
            Components = new List<Component>
            {
                new Component
                {
                    Title = "Frame",
                    Description = "Caixa que envolve outros elementos.",
                    Page = typeof(FramePage)
                }

            }
        });
        
        return categories;
    }
}
