﻿using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.API.Image
{
    internal class ImageResponseDto
    {
        [JsonPropertyName("created")]
        public int Created { get; set; }

        [JsonPropertyName("data")]
        public List<ImageResponseDataDto> Data { get; set; }
    }

    internal class ImageResponseDataDto
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("b64_json")]
        public string B64Json { get; set; }
    }
}
