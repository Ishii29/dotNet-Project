using Newtonsoft.Json;

namespace Project.Core
{
    public class QuestionModel
    {
        [JsonProperty("questionID")]
        public string questionID { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("questionType")]
        public string questionType { get; set; }

        [JsonProperty("options")]
        public List<string> options { get; set; }

        

    }
}
