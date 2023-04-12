namespace UTFPR_Gamificacao_V1.RazorPages.Models
{
    public class ProdutoAtendimentoModel
    {
    public int ProdutoId { get; set; }
    public int Quantidade {get; set; }
    public ProdutoModel? Produto { get; set; }
    public int AtendimentoId { get; set; }
    public AtendimentoModel? Atendimento { get; set; }
    }
}