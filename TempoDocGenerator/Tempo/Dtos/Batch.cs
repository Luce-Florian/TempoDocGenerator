namespace TempoDocGenerator.Tempo.Dtos;

internal class Batch
{
    public Resource resource { get; set; }
    public List<InstrumentationLibrarySpan> instrumentationLibrarySpans { get; set; }
}

