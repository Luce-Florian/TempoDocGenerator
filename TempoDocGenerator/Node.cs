namespace TempoDocGenerator;

public class Node
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Node> Nodes { get; set; } = new List<Node>();
}