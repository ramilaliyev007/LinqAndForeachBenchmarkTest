public class Order
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Address { get; set; }

    public List<OrderLine> Lines { get; set; }

    public Order SetLines(List<OrderLine> lines)
    {
        Lines = lines;

        return this;
    }
}
