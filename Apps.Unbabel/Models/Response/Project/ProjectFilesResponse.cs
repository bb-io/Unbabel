using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Unbabel.Models.Response.Project
{
    public class ProjectFilesResponse
    {
        public IEnumerable<CompletedFile> Files { get; set; }
    }
}
