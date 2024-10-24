using Apps.Unbabel.DataSourceHandlers.StaticHandlers;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Unbabel.Polling.Models
{
    public class OptionalProjectStatus
    {
        [StaticDataSource(typeof(ProjectStatusDataHandler))]
        public string? Status { get; set; }
    }
}
