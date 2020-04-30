// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.DocumentGeneration.Client.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DocumentGenerationConfigurationEntrySummary
    {
        /// <summary>
        /// Initializes a new instance of the
        /// DocumentGenerationConfigurationEntrySummary class.
        /// </summary>
        public DocumentGenerationConfigurationEntrySummary()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// DocumentGenerationConfigurationEntrySummary class.
        /// </summary>
        /// <param name="templateStorageType">Possible values include:
        /// 'SharePointOnline', 'AzureBlobStorage'</param>
        public DocumentGenerationConfigurationEntrySummary(System.Guid? id = default(System.Guid?), string key = default(string), string name = default(string), string templateStorageType = default(string), IList<DocumentGenerationConfigurationEntrySummary> children = default(IList<DocumentGenerationConfigurationEntrySummary>))
        {
            Id = id;
            Key = key;
            Name = name;
            TemplateStorageType = templateStorageType;
            Children = children;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'SharePointOnline',
        /// 'AzureBlobStorage'
        /// </summary>
        [JsonProperty(PropertyName = "templateStorageType")]
        public string TemplateStorageType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public IList<DocumentGenerationConfigurationEntrySummary> Children { get; set; }

    }
}
