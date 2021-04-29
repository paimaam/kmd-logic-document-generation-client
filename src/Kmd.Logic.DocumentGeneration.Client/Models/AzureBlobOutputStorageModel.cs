// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.DocumentGeneration.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class AzureBlobOutputStorageModel
    {
        /// <summary>
        /// Initializes a new instance of the AzureBlobOutputStorageModel
        /// class.
        /// </summary>
        public AzureBlobOutputStorageModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AzureBlobOutputStorageModel
        /// class.
        /// </summary>
        public AzureBlobOutputStorageModel(string storageConnectionString = default(string), string containerName = default(string))
        {
            StorageConnectionString = storageConnectionString;
            ContainerName = containerName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "storageConnectionString")]
        public string StorageConnectionString { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "containerName")]
        public string ContainerName { get; set; }

    }
}
