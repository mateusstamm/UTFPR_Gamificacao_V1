namespace UTFPR_Gamificacao_V1.RazorPages.Models
{
    public class MesaModel
    {
    public int MesaId { get; set; }
    public int Numero { get; set; }
    public string? Status { get; set; }
    public DateTime? HoraAbertura { get; set; }
    }
}