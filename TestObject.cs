using Newtonsoft.Json;

namespace TestEtoWebkit
{
    public class TestObject
    {
        [JsonProperty("returnValue")]
        public string ReturnValue { get; set; }

        [JsonProperty("numbers")]
        public float[] Numbers { get; set; }

        public TestObject() { }
    }
}