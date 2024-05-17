using Newtonsoft.Json;

namespace BackendWebApi.Core
{
    public class QuestionDTO
    {
        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("questionType")]
        public string questionType { get; set; }

        [JsonProperty("options")]
        public List<string> options { get; set; }
    }
}
