﻿using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.Unbabel.Webhooks
{
    [WebhookList]
    public class WebhookList : UnbabelInvocable
    {
        public WebhookList(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Webhook("On translations completed",
            Description = "On translations completed")]
        public async Task<WebhookResponse<ProjectEntity>> TranslationsCompleted(WebhookRequest request)
        {
            var data = JsonConvert.DeserializeObject<ProjectEntity>(request.Body.ToString());
            return new WebhookResponse<ProjectEntity>
            {
                HttpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK),
                Result = data
            };
        }
    }
}
