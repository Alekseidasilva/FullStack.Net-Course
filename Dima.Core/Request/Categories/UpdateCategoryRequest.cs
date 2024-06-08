using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Request.Categories;

public class UpdateCategoryRequest:Request
{
    [Required(ErrorMessage = "Titulo Invalido")]
    [MaxLength(80,ErrorMessage = "O Titulo deve conter ate 80 caracteres")]
    public string Title { get; set; }=String.Empty;
    
    [Required(ErrorMessage = "Descricao Invalida")]
    public string Description { get; set; }=String.Empty;
}