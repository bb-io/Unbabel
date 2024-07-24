using Apps.Unbabel.Models.Entities;

namespace Apps.Unbabel.Models.Response.Translation;

public record SearchTranslationsResponse(List<TranslationEntity> Translations);