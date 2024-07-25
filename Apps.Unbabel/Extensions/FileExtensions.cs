using System.Text;
using System.Xml.Linq;
using Apps.Unbabel.Models.Request.QualityIntelligence;

namespace Apps.Unbabel.Extensions;

public static class FileExtensions
{
    public static async Task<byte[]> ReadFromMultipartFormData(this byte[] file, string contentType)
    {
        var stream = new MemoryStream(file);
        var provider = await ReadFormDataAsync(stream, contentType);

        return await provider.Contents.First().ReadAsByteArrayAsync();
    }

    static Task<MultipartMemoryStreamProvider> ReadFormDataAsync(Stream stream, string contentType)
    {
        var provider = new MultipartMemoryStreamProvider();
        var content = new StreamContent(stream);
        content.Headers.Add("Content-Type", contentType);

        return content.ReadAsMultipartAsync(provider);
    }

    public static IEnumerable<TranslatedSegment> GetSegments(this Stream file)
    {
        var result = new List<TranslatedSegment>();
        using var reader = new StreamReader(file, Encoding.UTF8);
        var xliffDocument = XDocument.Load(reader);

        var defaultNs = xliffDocument.Root.GetDefaultNamespace();

        foreach (var transUnit in xliffDocument.Descendants(defaultNs + "trans-unit"))
        {
            result.Add(new TranslatedSegment()
            {
                SourceSegment = transUnit.Element(defaultNs + "source").Value,
                TargetSegment = transUnit.Element(defaultNs + "target").Value
            });
        }

        return result;
    }
}