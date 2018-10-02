using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace NEOBlockContentsViewer.Enums
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RpcMethod
    {
        none,
        getassetstate,
        getblockcount,
        getblock
    }
}
