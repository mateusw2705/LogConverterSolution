namespace Domain.Request;

public record LogConversionRequest
{
    public string SourceUrl { get; set; }
    public string TargetPath { get; set; }
}
