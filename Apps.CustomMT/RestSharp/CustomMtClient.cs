﻿using Apps.CustomMT.Constants;
using Apps.CustomMT.Models.Response;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.CustomMT.RestSharp;

public class CustomMtClient : RestClient
{
    public CustomMtClient() : base(new RestClientOptions() { BaseUrl = new(Urls.ApiUrl) })
    {
    }

    public async Task<T> ExecuteWithHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content);
    }

    public async Task<RestResponse> ExecuteWithHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
            return response;

        throw ConfigureErrorException(response);
    }

    private Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonConvert.DeserializeObject<ErrorModel>(response.Content);

        return new(error.Error);
    }
}