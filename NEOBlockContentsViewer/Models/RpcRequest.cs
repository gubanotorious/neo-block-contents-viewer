using System;
using System.Collections.Generic;
using NEOBlockContentsViewer.Enums;
using Newtonsoft.Json;

namespace NEOBlockContentsViewer.Models
{
    [Serializable]
    public class RpcRequest
    {
        [JsonProperty("jsonrpc")]
        public string JsonRpcVersion = "2.0";

        [JsonProperty("method")]
        public RpcMethod Method = RpcMethod.none;

        [JsonProperty("params")]
        public List<object> Parameters = new List<object>();

        [JsonProperty("id")]
        public int Id = 1;
    }
}
