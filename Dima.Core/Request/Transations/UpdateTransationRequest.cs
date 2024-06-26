using System.ComponentModel.DataAnnotations;
using Dima.Core.Enums;

namespace Dima.Core.Request.Transations;

public class UpdateTransationRequest:Request
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Titulo Invalido")]
    public string Title { get; set; }=String.Empty;
    [Required(ErrorMessage = "Tipo Invadlido")]
    public ETransationType Type { get; set; }
    [Required(ErrorMessage = "Valor Invalido")]
    public decimal Amount { get; set; }
    [Required(ErrorMessage = "Categoria Invalida")]
    public long CategoryId { get; set; }
    [Required(ErrorMessage = "Data Invalido")]
    public DateTime? PaidOrReceivedAt { get; set; }
}