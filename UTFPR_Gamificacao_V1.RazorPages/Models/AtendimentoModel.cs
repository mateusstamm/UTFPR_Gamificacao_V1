namespace UTFPR_Gamificacao_V1.RazorPages.Models
{
    public class AtendimentoModel
    {
    public int AtendimentoId { get; set; }
    public DateTime HoraPedido { get; set; }

    // Relacionamentos
    public int MesaId { get; set; }
    public MesaModel? Mesa { get; set; }
    public int GarconId { get; set; }
    public GarconModel? Garcon { get; set; }
    public ICollection<ProdutoAtendimentoModel>? ProdutosAtendimento { get; set; }
    }
}