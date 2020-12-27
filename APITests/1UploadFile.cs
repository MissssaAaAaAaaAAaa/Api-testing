using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
namespace APITests
{
    [TestFixture]
    public class T1UploadFile
    {
        [Test]
        public void UploadFileTest()
        {
            RestClient client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Dropbox-API-Arg", "{\"path\":\"/upload.jpg\",\"mode\":\"add\",\"autorename\":true,\"mute\":false,\"strict_conflict\":false}");
            request.AddHeader("Authorization", "Bearer CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH");
            request.AddParameter("application/octet-stream", "<file contents here>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string resp = response.Content.ToString();
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode,"wrong StatusCode");
            Assert.IsTrue(resp.Contains("\"name\": \"upload.jpg\""), "wrong name");
            Assert.IsTrue(resp.Contains("id:URSsRWTGmWAAAAAAAAA"), "wrong id");
            Assert.IsTrue(resp.Contains("\"size\": 20"), "wrong size");
            Assert.IsTrue(resp.Contains("b686266b0ed8fbb70285d423e3015f34f6b0a49fbfc2ba5dda89603b07f6def8"), "wrong content hash");
        }
    }
}
