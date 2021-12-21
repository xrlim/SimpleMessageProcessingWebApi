using System;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var formatA = @"{
    ""from"": ""6588882222"",
    ""to"": ""6511111111"",
    ""type"": ""text"",
    ""text"": ""Hello"",
    ""sendTime"": ""2021-08-23 09:00""
}";
var formatB = @"{
    ""from"": ""6588882222"",
    ""to"": ""6511111111"",
    ""type"": ""text"",
    ""text"": ""Hello"",
    ""sendTime"": ""2021-08-23 09:00""
}{
    ""message"": {
        ""type"": ""text"",
        ""id"": ""asdf-qwer-zxcv-aaaa"",
        ""text"": ""Hello""
    },
    ""source"": {
        ""type"": ""user"",
        ""userId"": ""qwerty""
    },
    ""timestamp"": 1629680508
}";
var formatC = @"{
    ""msisdn"": ""6588882222"",
    ""message"": {
    ""msgText"": ""Hello"",
        ""msgTime"": ""2021-08-23 09:00""
    }
}";

string apiUrl = "https://localhost:7032/api/message/ProcessMessage";

HttpClient httpClient = new HttpClient();

// formatA
var content = new StringContent(formatA, Encoding.UTF8, "application/json");
var response = await httpClient.PostAsync(apiUrl, content);
response.EnsureSuccessStatusCode();

//formatB
content = new StringContent(formatA, Encoding.UTF8, "application/json");
response = await httpClient.PostAsync(apiUrl, content);
response.EnsureSuccessStatusCode();

//formatC
content = new StringContent(formatA, Encoding.UTF8, "application/json");
response = await httpClient.PostAsync(apiUrl, content);
response.EnsureSuccessStatusCode();

