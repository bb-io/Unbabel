using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Request.Translation;

public class TranslationRequest
{
    [Display("Translation UID")]
    public string TranslationId { get; set; }
}