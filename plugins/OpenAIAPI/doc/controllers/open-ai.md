# Open AI

The OpenAI REST API

```csharp
OpenAIController openAIController = client.OpenAIController;
```

## Class Name

`OpenAIController`

## Methods

* [List Engines](../../doc/controllers/open-ai.md#list-engines)
* [Retrieve Engine](../../doc/controllers/open-ai.md#retrieve-engine)
* [Create Completion](../../doc/controllers/open-ai.md#create-completion)
* [Create Edit](../../doc/controllers/open-ai.md#create-edit)
* [Create Embedding](../../doc/controllers/open-ai.md#create-embedding)
* [Create Search](../../doc/controllers/open-ai.md#create-search)
* [List Files](../../doc/controllers/open-ai.md#list-files)
* [Create File](../../doc/controllers/open-ai.md#create-file)
* [Delete File](../../doc/controllers/open-ai.md#delete-file)
* [Retrieve File](../../doc/controllers/open-ai.md#retrieve-file)
* [Download File](../../doc/controllers/open-ai.md#download-file)
* [Create Answer](../../doc/controllers/open-ai.md#create-answer)
* [Create Classification](../../doc/controllers/open-ai.md#create-classification)
* [Create Fine Tune](../../doc/controllers/open-ai.md#create-fine-tune)
* [List Fine Tunes](../../doc/controllers/open-ai.md#list-fine-tunes)
* [Retrieve Fine Tune](../../doc/controllers/open-ai.md#retrieve-fine-tune)
* [Cancel Fine Tune](../../doc/controllers/open-ai.md#cancel-fine-tune)
* [List Fine Tune Events](../../doc/controllers/open-ai.md#list-fine-tune-events)
* [List Models](../../doc/controllers/open-ai.md#list-models)
* [Retrieve Model](../../doc/controllers/open-ai.md#retrieve-model)
* [Delete Model](../../doc/controllers/open-ai.md#delete-model)


# List Engines

**This endpoint is deprecated.**

Lists the currently available (non-finetuned) models, and provides basic information about each one such as the owner and availability.

```csharp
ListEnginesAsync()
```

## Response Type

[`Task<Models.ListEnginesResponse>`](../../doc/models/list-engines-response.md)

## Example Usage

```csharp
try
{
    ListEnginesResponse result = await openAIController.ListEnginesAsync();
}
catch (ApiException e){};
```


# Retrieve Engine

**This endpoint is deprecated.**

Retrieves a model instance, providing basic information about it such as the owner and availability.

```csharp
RetrieveEngineAsync(
    string engineId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `engineId` | `string` | Template, Required | The ID of the engine to use for this request |

## Response Type

[`Task<Models.Engine>`](../../doc/models/engine.md)

## Example Usage

```csharp
string engineId = "davinci";

try
{
    Engine result = await openAIController.RetrieveEngineAsync(engineId);
}
catch (ApiException e){};
```


# Create Completion

Creates a completion for the provided prompt and parameters

```csharp
CreateCompletionAsync(
    Models.CreateCompletionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateCompletionRequest`](../../doc/models/create-completion-request.md) | Body, Required | - |

## Response Type

[`Task<Models.CreateCompletionResponse>`](../../doc/models/create-completion-response.md)

## Example Usage

```csharp
var body = new CreateCompletionRequest();
body.Model = "model4";

try
{
    CreateCompletionResponse result = await openAIController.CreateCompletionAsync(body);
}
catch (ApiException e){};
```


# Create Edit

Creates a new edit for the provided input, instruction, and parameters

```csharp
CreateEditAsync(
    Models.CreateEditRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateEditRequest`](../../doc/models/create-edit-request.md) | Body, Required | - |

## Response Type

[`Task<Models.CreateEditResponse>`](../../doc/models/create-edit-response.md)

## Example Usage

```csharp
var body = new CreateEditRequest();
body.Model = "model4";
body.Instruction = "Fix the spelling mistakes.";

try
{
    CreateEditResponse result = await openAIController.CreateEditAsync(body);
}
catch (ApiException e){};
```


# Create Embedding

Creates an embedding vector representing the input text.

```csharp
CreateEmbeddingAsync(
    Models.CreateEmbeddingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateEmbeddingRequest`](../../doc/models/create-embedding-request.md) | Body, Required | - |

## Response Type

[`Task<Models.CreateEmbeddingResponse>`](../../doc/models/create-embedding-response.md)

## Example Usage

```csharp
var body = new CreateEmbeddingRequest();
body.Model = "model4";
body.Input = "The quick brown fox jumped over the lazy dog";

try
{
    CreateEmbeddingResponse result = await openAIController.CreateEmbeddingAsync(body);
}
catch (ApiException e){};
```


# Create Search

**This endpoint is deprecated.**

The search endpoint computes similarity scores between provided query and documents. Documents can be passed directly to the API if there are no more than 200 of them.

To go beyond the 200 document limit, documents can be processed offline and then used for efficient retrieval at query time. When `file` is set, the search endpoint searches over all the documents in the given file and returns up to the `max_rerank` number of documents. These documents will be returned along with their search scores.

The similarity score is a positive score that usually ranges from 0 to 300 (but can sometimes go higher), where a score above 200 usually means the document is semantically similar to the query.

```csharp
CreateSearchAsync(
    string engineId,
    Models.CreateSearchRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `engineId` | `string` | Template, Required | The ID of the engine to use for this request.  You can select one of `ada`, `babbage`, `curie`, or `davinci`. |
| `body` | [`Models.CreateSearchRequest`](../../doc/models/create-search-request.md) | Body, Required | - |

## Response Type

[`Task<Models.CreateSearchResponse>`](../../doc/models/create-search-response.md)

## Example Usage

```csharp
string engineId = "davinci";
var body = new CreateSearchRequest();
body.Query = "the president";

try
{
    CreateSearchResponse result = await openAIController.CreateSearchAsync(engineId, body);
}
catch (ApiException e){};
```


# List Files

Returns a list of files that belong to the user's organization.

```csharp
ListFilesAsync()
```

## Response Type

[`Task<Models.ListFilesResponse>`](../../doc/models/list-files-response.md)

## Example Usage

```csharp
try
{
    ListFilesResponse result = await openAIController.ListFilesAsync();
}
catch (ApiException e){};
```


# Create File

Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.

```csharp
CreateFileAsync(
    FileStreamInfo file,
    string purpose)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `file` | `FileStreamInfo` | Form, Required | Name of the [JSON Lines](https://jsonlines.readthedocs.io/en/latest/) file to be uploaded.<br><br>If the `purpose` is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your [training examples](/docs/guides/fine-tuning/prepare-training-data). |
| `purpose` | `string` | Form, Required | The intended purpose of the uploaded documents.<br><br>Use "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tunes). This allows us to validate the format of the uploaded file. |

## Response Type

[`Task<Models.OpenAIFile>`](../../doc/models/open-ai-file.md)

## Example Usage

```csharp
FileStreamInfo file = new FileStreamInfo(new FileStream("dummy_file",FileMode.Open));
string purpose = "purpose6";

try
{
    OpenAIFile result = await openAIController.CreateFileAsync(file, purpose);
}
catch (ApiException e){};
```


# Delete File

Delete a file.

```csharp
DeleteFileAsync(
    string fileId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `fileId` | `string` | Template, Required | The ID of the file to use for this request |

## Response Type

[`Task<Models.DeleteFileResponse>`](../../doc/models/delete-file-response.md)

## Example Usage

```csharp
string fileId = "file_id6";

try
{
    DeleteFileResponse result = await openAIController.DeleteFileAsync(fileId);
}
catch (ApiException e){};
```


# Retrieve File

Returns information about a specific file.

```csharp
RetrieveFileAsync(
    string fileId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `fileId` | `string` | Template, Required | The ID of the file to use for this request |

## Response Type

[`Task<Models.OpenAIFile>`](../../doc/models/open-ai-file.md)

## Example Usage

```csharp
string fileId = "file_id6";

try
{
    OpenAIFile result = await openAIController.RetrieveFileAsync(fileId);
}
catch (ApiException e){};
```


# Download File

Returns the contents of the specified file

```csharp
DownloadFileAsync(
    string fileId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `fileId` | `string` | Template, Required | The ID of the file to use for this request |

## Response Type

`Task<string>`

## Example Usage

```csharp
string fileId = "file_id6";

try
{
    string result = await openAIController.DownloadFileAsync(fileId);
}
catch (ApiException e){};
```


# Create Answer

**This endpoint is deprecated.**

Answers the specified question using the provided documents and examples.

The endpoint first [searches](/docs/api-reference/searches) over provided documents or files to find relevant context. The relevant context is combined with the provided examples and question to create the prompt for [completion](/docs/api-reference/completions).

```csharp
CreateAnswerAsync(
    Models.CreateAnswerRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateAnswerRequest`](../../doc/models/create-answer-request.md) | Body, Required | - |

## Response Type

[`Task<Models.CreateAnswerResponse>`](../../doc/models/create-answer-response.md)

## Example Usage

```csharp
var body = new CreateAnswerRequest();
body.Model = "model4";
body.Question = "What is the capital of Japan?";
body.Examples = new List<List<string>>();
body.Examples.Add("examples9");
body.Examples.Add("examples8");
body.ExamplesContext = "Ottawa, Canada's capital, is located in the east of southern Ontario, near the city of Montréal and the U.S. border.";

try
{
    CreateAnswerResponse result = await openAIController.CreateAnswerAsync(body);
}
catch (ApiException e){};
```


# Create Classification

**This endpoint is deprecated.**

Classifies the specified `query` using provided examples.

The endpoint first [searches](/docs/api-reference/searches) over the labeled examples
to select the ones most relevant for the particular query. Then, the relevant examples
are combined with the query to construct a prompt to produce the final label via the
[completions](/docs/api-reference/completions) endpoint.

Labeled examples can be provided via an uploaded `file`, or explicitly listed in the
request using the `examples` parameter for quick tests and small scale use cases.

```csharp
CreateClassificationAsync(
    Models.CreateClassificationRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateClassificationRequest`](../../doc/models/create-classification-request.md) | Body, Required | - |

## Response Type

[`Task<Models.CreateClassificationResponse>`](../../doc/models/create-classification-response.md)

## Example Usage

```csharp
var body = new CreateClassificationRequest();
body.Model = "model4";
body.Query = "The plot is not very attractive.";

try
{
    CreateClassificationResponse result = await openAIController.CreateClassificationAsync(body);
}
catch (ApiException e){};
```


# Create Fine Tune

Creates a job that fine-tunes a specified model from a given dataset.

Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.

[Learn more about Fine-tuning](/docs/guides/fine-tuning)

```csharp
CreateFineTuneAsync(
    Models.CreateFineTuneRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateFineTuneRequest`](../../doc/models/create-fine-tune-request.md) | Body, Required | - |

## Response Type

[`Task<Models.FineTune>`](../../doc/models/fine-tune.md)

## Example Usage

```csharp
var body = new CreateFineTuneRequest();
body.TrainingFile = "file-ajSREls59WBbvgSzJSVWxMCB";

try
{
    FineTune result = await openAIController.CreateFineTuneAsync(body);
}
catch (ApiException e){};
```


# List Fine Tunes

List your organization's fine-tuning jobs

```csharp
ListFineTunesAsync()
```

## Response Type

[`Task<Models.ListFineTunesResponse>`](../../doc/models/list-fine-tunes-response.md)

## Example Usage

```csharp
try
{
    ListFineTunesResponse result = await openAIController.ListFineTunesAsync();
}
catch (ApiException e){};
```


# Retrieve Fine Tune

Gets info about the fine-tune job.

[Learn more about Fine-tuning](/docs/guides/fine-tuning)

```csharp
RetrieveFineTuneAsync(
    string fineTuneId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `fineTuneId` | `string` | Template, Required | The ID of the fine-tune job |

## Response Type

[`Task<Models.FineTune>`](../../doc/models/fine-tune.md)

## Example Usage

```csharp
string fineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";

try
{
    FineTune result = await openAIController.RetrieveFineTuneAsync(fineTuneId);
}
catch (ApiException e){};
```


# Cancel Fine Tune

Immediately cancel a fine-tune job.

```csharp
CancelFineTuneAsync(
    string fineTuneId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `fineTuneId` | `string` | Template, Required | The ID of the fine-tune job to cancel |

## Response Type

[`Task<Models.FineTune>`](../../doc/models/fine-tune.md)

## Example Usage

```csharp
string fineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";

try
{
    FineTune result = await openAIController.CancelFineTuneAsync(fineTuneId);
}
catch (ApiException e){};
```


# List Fine Tune Events

Get fine-grained status updates for a fine-tune job.

```csharp
ListFineTuneEventsAsync(
    string fineTuneId,
    bool? stream = false)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `fineTuneId` | `string` | Template, Required | The ID of the fine-tune job to get events for. |
| `stream` | `bool?` | Query, Optional | Whether to stream events for the fine-tune job. If set to true,<br>events will be sent as data-only<br>[server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format)<br>as they become available. The stream will terminate with a<br>`data: [DONE]` message when the job is finished (succeeded, cancelled,<br>or failed).<br><br>If set to false, only events generated so far will be returned.<br>**Default**: `false` |

## Response Type

[`Task<Models.ListFineTuneEventsResponse>`](../../doc/models/list-fine-tune-events-response.md)

## Example Usage

```csharp
string fineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";
bool? stream = false;

try
{
    ListFineTuneEventsResponse result = await openAIController.ListFineTuneEventsAsync(fineTuneId, stream);
}
catch (ApiException e){};
```


# List Models

Lists the currently available models, and provides basic information about each one such as the owner and availability.

```csharp
ListModelsAsync()
```

## Response Type

[`Task<Models.ListModelsResponse>`](../../doc/models/list-models-response.md)

## Example Usage

```csharp
try
{
    ListModelsResponse result = await openAIController.ListModelsAsync();
}
catch (ApiException e){};
```


# Retrieve Model

Retrieves a model instance, providing basic information about the model such as the owner and permissioning.

```csharp
RetrieveModelAsync(
    string model)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `model` | `string` | Template, Required | The ID of the model to use for this request |

## Response Type

[`Task<Models.Model>`](../../doc/models/model.md)

## Example Usage

```csharp
string model = "text-davinci-001";

try
{
    Model result = await openAIController.RetrieveModelAsync(model);
}
catch (ApiException e){};
```


# Delete Model

Delete a fine-tuned model. You must have the Owner role in your organization.

```csharp
DeleteModelAsync(
    string model)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `model` | `string` | Template, Required | The model to delete |

## Response Type

[`Task<Models.DeleteModelResponse>`](../../doc/models/delete-model-response.md)

## Example Usage

```csharp
string model = "curie:ft-acmeco-2021-03-03-21-44-20";

try
{
    DeleteModelResponse result = await openAIController.DeleteModelAsync(model);
}
catch (ApiException e){};
```

