using Newtonsoft.Json;
using Project.Core;

namespace BackendWebApi.Core
{
    public class ApplicationModel
    {
        [JsonProperty("applicationID")]
        public string applicationID { get; set; }

        [JsonProperty("questions")]
        public List<QuestionModel> questions { get; set; }

        
    }
}
