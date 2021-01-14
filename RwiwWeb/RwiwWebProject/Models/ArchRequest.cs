using Newtonsoft.Json;
using RwiwProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RwiwWebProject.Models
{
    public class ArchRequest
    {
        [JsonProperty(PropertyName = "dependencyNumber")]
        public int DependencyNumber { get; set; }
        [JsonProperty(PropertyName = "acceptableDowntime")]
        public int AcceptableDowntime { get; set; }
        [JsonProperty(PropertyName = "syncronicUserNumber")]
        public int SyncronicUserNumber { get; set; }
        [JsonProperty(PropertyName = "packetNumberPerSession")]
        public int PacketNumberPerSession { get; set; }
        [JsonProperty(PropertyName = "applicationComplexity"), System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public ApplicationComplexity ApplicationComplexity { get; set; }
        [JsonProperty(PropertyName = "dataTypeUsed"), System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public DataTypes DataTypeUsed { get; set; }
    }
}
