using IntegraBrasilAPI.Dtos;
using IntegraBrasilAPI.Interfaces;
using IntegraBrasilAPI.Models;
using System.Dynamic;
using System.Text.Json;

namespace IntegraBrasilAPI.Rest
{
    public class BrasilApiRest : IBrasilApi
    {

        public async Task<ResponseBase<BancoModel>> BuscarBanco(string codigoBanco)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{codigoBanco}");

            var response = new ResponseBase<BancoModel>();
            using (var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResponse = await responseApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<BancoModel>(contentResponse);

                if (responseApi.IsSuccessStatusCode)
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Data = objResponse;
                } else
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }
            return response;
        }
        public async Task<ResponseBase<List<BancoModel>>> BuscarTodosBancos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://brasilapi.com.br/api/banks/v1");

            var response = new ResponseBase<List<BancoModel>>();

            using(var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResponse = await responseApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<BancoModel>>(contentResponse);

                if(responseApi.IsSuccessStatusCode)
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Data = objResponse;
                } else
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }
            return response;
        }

        public async Task<ResponseBase<EnderecoModel>> BuscarEnderecoPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var response = new ResponseBase<EnderecoModel>();

            using(var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentResponse = await responseApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResponse);

                if(responseApi.IsSuccessStatusCode)
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Data = objResponse;
                } else
                {
                    response.StatusCode = responseApi.StatusCode;
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }

            return response;
        }

    }
}
