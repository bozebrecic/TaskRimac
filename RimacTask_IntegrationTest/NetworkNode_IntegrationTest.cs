using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RimacTask_IntegrationTest
{
    public class NetworkNode_IntegrationTest : IntegrationTest
    {
        public const string _BaseUrl = "https://localhost:44336/NetworkNode/";

        [Fact]
        public async Task GetAll()
        {
            using (var client = new IntegrationTest()._Client)
            {
                var response = await client.GetAsync(_BaseUrl + "GetAll");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Theory]
        [InlineData("TestData/US_AUTO.dbc")]
        public async Task ParseDBCFile(string filePath)
        {
            using (var client = new IntegrationTest()._Client)
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var fileContent = JsonConvert.SerializeObject(filePath);
                var stringContent = new StringContent(fileContent, UnicodeEncoding.UTF8, "application/json");

                var response = await client.PostAsync(_BaseUrl + "ParseDbcFile", stringContent);

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
