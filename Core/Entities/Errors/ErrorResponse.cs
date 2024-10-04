using System;
using Newtonsoft.Json;

public class ErrorResponse
{
    [JsonProperty("error")]
    public ErrorDetails Error { get; set; }
}

public class ErrorDetails
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("message")]
    public ErrorMessage Message { get; set; }
}

public class ErrorMessage
{
    [JsonProperty("lang")]
    public string Language { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}
