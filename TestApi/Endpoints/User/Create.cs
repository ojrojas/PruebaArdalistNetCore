using Application.Application.TestApi;
using Application.Commons;
using Application.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.TestApi.Endpoints
{
    [Collection("Sequential")]
    public class Create : IClassFixture<ApiTestBuilding>
    {
       JsonSerializerSettings _serializerSettings = new() {
           ContractResolver = new CamelCasePropertyNamesContractResolver(),
           DateTimeZoneHandling = DateTimeZoneHandling.Utc,
           NullValueHandling = NullValueHandling.Ignore,
       };

        public Create(ApiTestBuilding factory)
        {
            Client = factory.CreateClient();
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsNotAuthorizedGivenNormalUserToken()
        {
            var jsonContent = GetValidNewItemJson();
            var token = ApiTokenHelper.GetUserTokenInvalid();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.PostAsync("api/users", jsonContent);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsSuccessGivenValidNewItemAndAdminUserToken()
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/users", jsonContent);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Response<UserDto>>(stringResponse, _serializerSettings);
            var posibleResult = CreateNewUserTest();
            Assert.Equal(posibleResult.Name, model.Data.Name);
            Assert.Equal(posibleResult.LastName, model.Data.LastName);
            Assert.Equal(posibleResult.Identification, model.Data.Identification);
            Assert.Equal(posibleResult.TypeIdentificationId, model.Data.TypeIdentificationId);
        }

        private StringContent GetValidNewItemJson()
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(CreateNewUserTest()), Encoding.UTF8, "application/json");
            return jsonContent;
        }

        private UserDto CreateNewUserTest()
        {
            return  new UserDto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Julian",
                LastName = "Pacheco",
                TypeIdentificationId = "974beb4d-1717-4440-bb71-8a303aa661ea",
                Identification = "554455",
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedOn = DateTime.Now,
                Password = "Abc12345#",
                Email = "julian@pacheco.com",
                State = true
            };
        }
    }
}
