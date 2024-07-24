using System.Net.Mime;
using System.Text;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;

namespace Apps.Unbabel.Models.Request.Translation;

public class SubmitTranslationRequest
{
    public string TextFormat { get; set; }

    public string SourceText { get; set; }

    public string PipelineId { get; set; }

    public SubmitTranslationRequest(SubmitTextTranslationInput input)
    {
        SourceText = input.SourceText;
        PipelineId = input.PipelineId;
        TextFormat = "txt";
    }

    public SubmitTranslationRequest(SubmitFileTranslationInput input, IFileManagementClient _fileManagementClient)
    {
        PipelineId = input.PipelineId;
        TextFormat = GetFileTextFormat(input.File);

        var fileBytes = _fileManagementClient.DownloadAsync(input.File).Result.GetByteData().Result;
        SourceText = Encoding.UTF8.GetString(fileBytes);
    }

    private string GetFileTextFormat(FileReference inputFile)
    {
        var textFormat = inputFile.ContentType switch
        {
            MediaTypeNames.Text.Html => "html",
            MediaTypeNames.Text.Plain => "txt",
            MediaTypeNames.Application.Xml => "xliff",
            "application/xliff+xml" => "xliff",
            _ => null
        };

        textFormat ??= Path.GetExtension(inputFile.Name)?.ToLower() switch
        {
            ".html" => "html",
            ".txt" => "txt",
            ".xliff" => "xliff",
            _ => throw new("Wrong file format, Unbabel accepts only HTML, TXT or XLIFF files")
        };

        return textFormat;
    }
}