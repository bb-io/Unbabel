using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Unbabel.Models.Entities
{
    public class FileTranslationEntity
    {
        [Display("Translation UID")]
        public string TranslationUid { get; set; }

        [Display("Source language")]
        public string SourceLanguage { get; set; }

        [Display("Target language")]
        public string TargetLanguage { get; set; }

        [Display("Text format")]
        public string TextFormat { get; set; }

        [Display("Status")]
        public string Status { get; set; }

        [Display("Pipeline ID")]
        public string PipelineId { get; set; }

        [Display("Translated file")]
        public FileReference TranslatedFile { get; set; }
    }
}
