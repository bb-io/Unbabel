using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Response.Translation;

public class SubmitTranslationResponse
{
    [Display("Translation UID")]
    public string TranslationUid { get; set; }
    
    public string Status { get; set; }
}