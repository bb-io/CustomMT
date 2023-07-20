using Apps.CustomMT.Constants;
using Apps.CustomMT.Models.Request;
using Apps.CustomMT.Models.Request.Template;
using Apps.CustomMT.Models.Request.Translate;
using Apps.CustomMT.Models.Response;
using Apps.CustomMT.Models.Response.Template;
using Apps.CustomMT.Models.Response.Translate;
using Apps.CustomMT.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.CustomMT.Actions;

[ActionList]
public class TranslateActions
{
    #region Fields

    public readonly CustomMtClient Client;

    #endregion

    #region Constructors

    public TranslateActions()
    {
        Client = new();
    }

    #endregion

    #region Translate actions

    [Action("Translate multiple lines", Description = "Translate segments by template name")]
    public Task<TranslateMultipleResponse> TranslateMultiple(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] TranslateMultipleRequest input)
    {
        var request = new CustomMtRequest(ApiEndpoints.Translate, Method.Post, creds);
        request.AddJsonBody(JsonConvert.SerializeObject(input));
        
        return Client.ExecuteWithHandling<TranslateMultipleResponse>(request);
    }
    
    [Action("Translate text", Description = "Translate text by template name")]
    public async Task<TranslateSingleResponse> Translate(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] TranslateSingleRequest input)
    {
        var response = await TranslateMultiple(creds, new(input));

        return new()
        {
            TranslatedText = response.TranslatedText.First()
        };
    }

    #endregion

    #region Template actions

    [Action("Get templates", Description = "Get templates list by language pair")]
    public async Task<GetTemplatesResponse> GetTemplates(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] GetTemplatesRequest input)
    {
        var request = new CustomMtRequest(ApiEndpoints.GetTemplates, Method.Post, creds);
        request.AddJsonBody(JsonConvert.SerializeObject(input));
        
        var response = await Client.ExecuteWithHandling<List<Template>>(request);
        return new(response);
    }
    
    [Action("Get all templates", Description = "Get full templates list")]
    public async Task<GetTemplatesResponse> GetAllTemplates(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var request = new CustomMtRequest(ApiEndpoints.GetTemplatesList, Method.Get, creds);
        
        var response = await Client.ExecuteWithHandling<List<FullTemplate>>(request);
        return new(response.Cast<Template>().ToList());
    }

    #endregion
}