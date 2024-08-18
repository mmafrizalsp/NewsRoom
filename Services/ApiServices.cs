using NewsRoom.Models;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace NewsRoom.Services;

public static class ApiServices
{
    private static async Task<object> ApiClient(string _endpoint, HttpMethod _httpMethod, object? _tModel = null)
    {
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var client = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });
            var finalurl = $"https://newsapi.org/v2/{_endpoint}&apiKey=f6707516dc1845298b5597b91dfe41ef";
            var request = new HttpRequestMessage(_httpMethod, finalurl);
            if (_tModel != null)
            {
                var jsonParamContent = JsonSerializer.Serialize(_tModel);
                request.Content = new StringContent(jsonParamContent, null, "application/json");
            }

            var getdata = await client.SendAsync(request);
            if (!getdata.IsSuccessStatusCode) throw new Exception("Failed to fetch data");
            getdata.EnsureSuccessStatusCode();

            var getResult = await getdata.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(getResult)) throw new Exception("Nothing to show");

            var tempResult = JsonSerializer.Deserialize<MetaDataResult>(getResult);
            if (tempResult == null) throw new Exception("Failed to extract content");

            return tempResult.code == 200 ? await Task.FromResult(tempResult?.result) : await Task.FromResult(string.Empty);
        }
        catch (Exception en)
        {
            return await Task.FromResult(en.Message);
        }
    }

    public static async Task<object> GetAsync(string endpoint)
    {
        try
        {
            return await ApiClient(endpoint, HttpMethod.Get);
        }
        catch (Exception en)
        {
            return await Task.FromResult(en.Message);
        }
    }

    public static async Task<object> PostAsync(string endpoint, object tModel)
    {
        try
        {
            return await ApiClient(endpoint, HttpMethod.Post, tModel);
        }
        catch (Exception en)
        {
            return await Task.FromResult(en.Message);
        }
    }
    public static async Task<object> PutAsync(string endpoint, object tModel)
    {
        try
        {
            return await ApiClient(endpoint, HttpMethod.Put, tModel);
        }
        catch (Exception en)
        {
            return await Task.FromResult(en.Message);
        }
    }
    public static async Task<object> DeleteAsync(string endpoint, object tModel)
    {
        try
        {
            return await ApiClient(endpoint, HttpMethod.Delete, tModel);
        }
        catch (Exception en)
        {
            return await Task.FromResult(en.Message);
        }
    }
}