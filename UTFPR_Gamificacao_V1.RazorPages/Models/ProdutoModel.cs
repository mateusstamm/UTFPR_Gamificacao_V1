namespace UTFPR_Gamificacao_V1.RazorPages.Models
{
    public class ProdutoModel
    {
    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }

    // Relacionamento com Categoria
    public int CategoriaId { get; set; }
    public CategoriaModel? Categoria { get; set; }
    }
}