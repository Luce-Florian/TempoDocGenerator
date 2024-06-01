using TempoDocGenerator.Tempo.Dtos;

namespace TempoDocGenerator.Tempo;

public class TempoNodeExtractor
{
    public static Node Extract(string validTrace)
    {
        TempoTrace trace = GetTraceFromText(validTrace);

        var nodeModels = GetNodeModelsFromTrace(trace);

        return BuildTreeNode(nodeModels);
    }

    private static Node BuildTreeNode(IReadOnlyCollection<NodeModel> nodeModels)
    {
        var indexNodeModels = nodeModels.ToDictionary(i => i.Id);
        var indexNodes = new Dictionary<string, Node>();

        Node? root = null;

        foreach (var nodeModel in nodeModels)
        {
            Node node = GetOrCreateNode(indexNodes, nodeModel);

            if (nodeModel.IsRootNode())
            {
                root = node;
                continue;
            }

            Node parentNode = GetOrCreateNode(indexNodeModels[nodeModel.ParentId], indexNodes);

            parentNode.Nodes.Add(node);
        }

        return root ?? throw new InvalidOperationException();
    }

    private static Node GetOrCreateNode(Dictionary<string, Node> indexNodes, NodeModel nodeModel)
    {
        if (!indexNodes.TryGetValue(nodeModel.Id, out var node))
        {
            node = new Node()
            {
                Id = nodeModel.Id,
                Name = nodeModel.Name,
                Type = nodeModel.Type,
                Nodes = new List<Node>(),
            };

            indexNodes.Add(nodeModel.Id, node);
        }

        return node;
    }

    private static Node GetOrCreateNode(NodeModel nodeModel, Dictionary<string, Node> indexedNodes)
    {
        if (indexedNodes.TryGetValue(nodeModel.Id, out var node))
            return node;

        return new Node()
        { Id = nodeModel.Id };
    }

    private static IReadOnlyCollection<NodeModel> GetNodeModelsFromTrace(TempoTrace trace)
    {
        return trace.batches
            .SelectMany(i => i.instrumentationLibrarySpans.SelectMany(i => i.spans))
            .Select(ToNodeModel)
            .ToList();
    }

    private static NodeModel ToNodeModel(Span span)
        => new NodeModel(
            span.spanId,
            span.parentSpanId,
            span.name,
            GetNodeType(span));

    private static string GetNodeType(Span span)
    {
        var attribute = span.attributes.FirstOrDefault(i => i.key == "type");
        if (attribute is not null)
            return attribute.value.stringValue.ToLower();

        if (span.attributes.Any(i => i.key.StartsWith("db")))
            return "database";

        if (span.kind == "SPAN_KIND_SERVER" && span.attributes.Any(i => i.key == "http.request.method"))
            return "server request";

        if (span.attributes.Any(i => i.key == "http.request.method"))
            return "client request";


        return string.Empty;
    }

    private static TempoTrace GetTraceFromText(string validTrace)
    {
        return System.Text.Json.JsonSerializer.Deserialize<TempoTrace>(validTrace)
            ?? throw new InvalidOperationException();
    }

    private record NodeModel(string Id, string ParentId, string Name, string Type)
    {
        internal bool IsRootNode()
            => ParentId == "0000000000000000";
    }
}
