namespace TempoDocGenerator.Tempo.Dtos;

internal class Span
{
    public string traceId { get; set; }
    public string spanId { get; set; }
    public string parentSpanId { get; set; }
    public string traceState { get; set; }
    public string name { get; set; }
    public string kind { get; set; }
    public object startTimeUnixNano { get; set; }
    public object endTimeUnixNano { get; set; }
    public List<Attribute> attributes { get; set; }
    public int droppedAttributesCount { get; set; }
    public int droppedEventsCount { get; set; }
    public int droppedLinksCount { get; set; }
    public Status status { get; set; }
}

