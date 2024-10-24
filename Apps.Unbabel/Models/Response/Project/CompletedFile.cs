using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Unbabel.Models.Response.Project
{
    public class CompletedFile
    {
        [Display("Order ID")]
        public string OrderId { get; set; }

        [Display("Job ID")]
        public string JobId { get; set; }

        [Display("Pipeline ID")]
        public string PipelineId { get; set; }

        [Display("Input file ID")]
        public string InputFileId { get; set; }

        [Display("Output file ID")]
        public string OutputFileID { get; set; }
    }
}
