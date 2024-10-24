using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Unbabel.Models.Entities
{
    public class JobEntity
    {
        public string Id { get; set; }

        [JsonProperty("pipeline_id")]
        public string PipelineId { get; set; }

        public string Status { get; set; }

        [JsonProperty("output_file_id")]
        public IEnumerable<string>? OutputFileIds { get; set; }
    }
}
