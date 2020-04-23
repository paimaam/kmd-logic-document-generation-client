// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.DocumentGeneration.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class SharePointOnlineTemplateModelUpdateEntryAtPathRequest
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SharePointOnlineTemplateModelUpdateEntryAtPathRequest class.
        /// </summary>
        public SharePointOnlineTemplateModelUpdateEntryAtPathRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// SharePointOnlineTemplateModelUpdateEntryAtPathRequest class.
        /// </summary>
        public SharePointOnlineTemplateModelUpdateEntryAtPathRequest(string key = default(string), string name = default(string), SharePointOnlineTemplateModel properties = default(SharePointOnlineTemplateModel))
        {
            Key = key;
            Name = name;
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public SharePointOnlineTemplateModel Properties { get; set; }

    }
}