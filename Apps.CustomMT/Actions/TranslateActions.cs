using Apps.CustomMT.Constants;
using Apps.CustomMT.Models.Identifiers;
using Apps.CustomMT.Models.Input;
using Apps.CustomMT.Models.Response;
using Apps.CustomMT.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CustomMT.Actions;

[ActionList]
public class TranslateActions : BaseInvocable
{
    private readonly CustomMtClient Client;
    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    public TranslateActions(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }

    [Action("Translate multiple texts", Description = "Translate multiple texts using a specified template")]
    public Task<TranslateMultipleResponse> TranslateMultiple([ActionParameter] TemplateIdentifier template, [ActionParameter] MultipleTextInput input)
    {
        var request = new CustomMtRequest(ApiEndpoints.Translate, Method.Post, Creds);
        request.AddJsonBody(new {
            text = input.Texts,
            template_name = template.Template
        });        
        return Client.ExecuteWithHandling<TranslateMultipleResponse>(request);
    }
    
    [Action("Translate text", Description = "Translate a single text using a specified template")]
    public async Task<TranslateSingleResponse> Translate([ActionParameter] TemplateIdentifier template, [ActionParameter] TextInput input)
    {
        var response = await TranslateMultiple(template, new MultipleTextInput { Texts = new List<string> { input.Text } });
        return new()
        {
            TranslatedText = response.TranslatedText.First()
        };
    }

}