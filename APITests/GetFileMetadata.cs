using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace APITests
{
    [TestFixture]
    public class GetFileMetadata
    {
        [Test]
        public void GetFileMetadataTest()
        {
            RestClient client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH");
            request.AddParameter("application/json", "{\r\n    \"path\": \"/upload.jpg\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string resp = response.Content.ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "wrong StatusCode");
            Assert.IsTrue(resp.Contains("\".tag\": \"file\""), "wrong tag");
            Assert.IsTrue(resp.Contains("\"name\": \"upload.jpg\""), "wrong name");
            Assert.IsTrue(resp.Contains("\"size\": 20"), "wrong size");
            Assert.IsTrue(resp.Contains("b686266b0ed8fbb70285d423e3015f34f6b0a49fbfc2ba5dda89603b07f6def8"), "wrong content hash");
        }
    }
}
