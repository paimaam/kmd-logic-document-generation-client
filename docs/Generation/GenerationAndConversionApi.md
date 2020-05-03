﻿# KMD Logic DocumentGenerationClient Api

The Logic DocumentGenerationClient provides APIs for:

* listing document generation Templates;
* requesting the generation of documents based on those templates;
* requesting conversion of documents to other formats, in particular to Pdf/A;
* checking on the progress of document generation and format conversion;
* requesting a signed download url from which to stream the generated or converted document.

## Motivating example

```c#
DocumentGenerationClient client;
Guid subscriptionId;
string aTemplateId;
JObject mergeData;

// ...

// Get all configurations for this subscription Id
// and select the Id of the first one with the name MyConfigurationName
var configurationId = 
    (await client.GetConfigurationsForSubscription(subscriptionId)
        .ConfigureAwait(false))
    .FirstOrDefault(c => c.Name == "MyConfigurationName")
    .ConfigurationId;

// Request a document be generated using the known template id and provided merge data
var documentGenerationProgress =
    await documentGenerationClient.RequestDocumentGeneration(
            subscriptionId,
            configurationId,
            new DocumentGenerationRequestDetails(
                @"MySchool\MyDepartment",
                aTemplateId,
                "en",
                DocumentFormat.Pdf,
                mergeData))
        .ConfigureAwait(false);

// ...

// Download the generated document
var documentGenerationUri =
    await documentGenerationClient.GetDocumentGenerationUri(
            subscriptionId,
            documentGenerationProgress.Id)
        .ConfigureAwait(false);

var downloadUri = documentGenerationUri.Uri;
```

## The Document Generation Client API

### `DocumentGenerationClient` constructor

#### Creates a DocumentGenerationClient object.

All Logic Document Generation is done relative to a DocumentGenerationClient object.
To create a DocumentGenerationClient, you need:

* a `HttpClient`; 
* a `LogicTokenProviderFactory` from [Kmd.Logic.Identity.Authorization](https://www.nuget.org/packages/Kmd.Logic.Identity.Authorization);
* a [DocumentGenerationOptions](../../src/Kmd.Logic.DocumentGeneration.Client/DocumentGenerationOptions.cs) object

```c#
var documentGenerationClient =
    new DocumentGenerationClient(httpClient, tokenProviderFactory, documentGenerationOptions);
```

Your Logic `SubscriptionId` should be set on the `DocumentGenerationOptions.SubscriptionId` property.

The samples provide example ways to call the constructor:

* [ConfigurationSample](https://github.com/kmdlogic/kmd-logic-document-generation-client/blob/f1f50e76eaee8c83eeff4f5bd4002be52500e9d0/samples/Kmd.Logic.DocumentGeneration.Client.ConfigurationSample/Program.cs#L68-L72)
* [GenerationSample](https://github.com/kmdlogic/kmd-logic-document-generation-client/blob/f1f50e76eaee8c83eeff4f5bd4002be52500e9d0/samples/Kmd.Logic.DocumentGeneration.Client.GenerationSample/Program.cs#L70-L74)

## DocumentGenerationClient document generation methods

The DocumentGenerationClient methods each accept a subscriptionId, which identifies a KMD Logic subscription.  If this is null, the SubscriptionId property of the [DocumentGenerationOptions](../../src/Kmd.Logic.DocumentGeneration.Client/DocumentGenerationOptions.cs) is used.

### `GetTemplates`

#### Lists all templates.

To list all templates for a nominated configuration at or above the nominated ([hierarchyPath](../HierarchyPath.md)):

```c#
var templates =
    await documentGenerationClient.GetTemplates(subscriptionId, configurationId, hierarchyPath, subject)
        .ConfigureAwait(false);
```

where:

* `subscriptionId` identifies a KMD Logic subscription;
* `configurationId` identifies a KMD Logic Document Generation configuration;
* `hierarchyPath` encodes the hierarchy of possible template sources not including the master location ([Hierarchy Path](../HierarchyPath.md));
* `subject` is the subject of the created document.

The response is a list of `DocumentGenerationTemplate` objects.  Each template includes a TemplateId string property and a Languages property which lists the relevent document languages as ISO 2 Letter Language code values.  E.g. en, da.


### `RequestDocumentGeneration`

#### Requests a document generation.

To submit a document generation request:

```c#
var documentGenerationProgress =
    await documentGenerationClient.RequestDocumentGeneration(
        subscriptionId,
        configurationId,
        new DocumentGenerationRequestDetails(
            hierarchyPath,
            templateId,
            twoLetterIsoLanguageName,
            documentFormat,
            mergeData,
            callbackUrl
        )
        .ConfigureAwait(false);
```

where:

* `subscriptionId` identifies a KMD Logic subscription;
* `configurationId` identifies a KMD Logic Document Generation configuration belonging to that subscription;
* `hierarchyPath` encodes the hierarchy of possible template sources not including the master location ([Hierarchy Path](../HierarchyPath.md));
* `templateId` identifies the name of the document generation template;
* `twoLetterIsoLanguageName` specifies a language code in ISO 639-1 format (eg. en, da);
* `documentFormat` declares the format of the generated document (see [DocumentFormat](../../src/Kmd.Logic.DocumentGeneration.Client/Types/DocumentFormat.cs) );
* `mergeData` provides merge data compatible with [Aspose Words Reporting](https://apireference.aspose.com/net/words/aspose.words.reporting/) data sources;
* `callbackUrl` declares a URL that is to be called when document generation completes.

The returned DocumentGenerationProgress response object ([source](../../src/Kmd.Logic.DocumentGeneration.Client/ServiceMessages/DocumentGenerationProgress.cs)) includes an Id property that can be passed to later client methods.

### `GetDocumentGenerationProgress`

#### Gets document generation progress.

To retrieve an already submitted document generation request in order to read its status:

```c#
var documentGenerationProgress =
    await documentGenerationClient.GetDocumentGenerationProgress(subscriptionId, id)
        .ConfigureAwait(false);
```

where `subscriptionId` identifies a KMD Logic subscription,
and where `id` is the Id property of an earlier response to `RequestDocumentGeneration`. 

The `DocumentGenerationProgress` response object ([source](../../src/Kmd.Logic.DocumentGeneration.Client/ServiceMessages/DocumentGenerationProgress.cs)) includes a State property ( see [DocumentGenerationState.cs](../../src/Kmd.Logic.DocumentGeneration.Client/Types/DocumentGenerationState.cs) ) which can take one of the following values:

* `Requested`
* `Completed`
* `Failed`


### `GetDocumentGenerationUri`

#### Gets the document generated for the nominated request.

To retrieve a generated document (once the document `State` is `Completed`):

```c#
var documentUri =
    await documentGenerationClient.GetDocumentGenerationUri(subscriptionId, id)
        .ConfigureAwait(false);
```

where `subscriptionId` identifies a KMD Logic subscription,
and where `id` is the Id property of an earlier response to `RequestDocumentGeneration`. 

The response is a `DocumentGenerationUri` object that includes a `Uri` property using which the document can be downloaded, and a `UriExpiryTime` DateTime property up until which time the Uri link should continue to function.


### `RequestDocumentConversionToPdfA`

#### Requests document rendering to Pdf/A.

To submit a document rendering request:

```c#
var documentGenerationProgress =
    await documentGenerationClient.RequestDocumentConversionToPdfA(
        subscriptionId,
        configurationId,
        new DocumentConversionToPdfARequestDetails(
            sourceDocumentUrl,
            sourceDocumentFormat,
            callbackUrl
        )
        .ConfigureAwait(false);
```

where:

* `subscriptionId` identifies a KMD Logic subscription;
* `configurationId` identifies a KMD Logic Document Generation configuration belonging to that subscription;
* `sourceDocumentUrl` URL that identifies the document to be converted;
* `sourceDocumentFormat` declares the format of the original document (see [DocumentFormat](../../src/Kmd.Logic.DocumentGeneration.Client/Types/DocumentFormat.cs) );
* `callbackUrl` declares a URL that is to be called when document rendering completes.

The returned DocumentGenerationProgress response object ([source](../../src/Kmd.Logic.DocumentGeneration.Client/ServiceMessages/DocumentGenerationProgress.cs)) includes an Id property that can be passed to later client methods.