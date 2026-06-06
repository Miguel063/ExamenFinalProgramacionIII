namespace ExamenFinalProgramacionIII;

public class Cart
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<CartItem> Items { get; set; } = [];
}