
# Create Search Request

## Structure

`CreateSearchRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Query` | `string` | Required | Query to search against the documents.<br>**Constraints**: *Minimum Length*: `1` |
| `Documents` | `List<string>` | Optional | Up to 200 documents to search over, provided as a list of strings.<br><br>The maximum document length (in tokens) is 2034 minus the number of tokens in the query.<br><br>You should specify either `documents` or a `file`, but not both.<br>**Constraints**: *Minimum Items*: `1`, *Maximum Items*: `200` |
| `File` | `string` | Optional | The ID of an uploaded file that contains documents to search over.<br><br>You should specify either `documents` or a `file`, but not both. |
| `MaxRerank` | `int?` | Optional | The maximum number of documents to be re-ranked and returned by search.<br><br>This flag only takes effect when `file` is set.<br>**Default**: `200`<br>**Constraints**: `>= 1` |
| `ReturnMetadata` | `bool?` | Optional | A special boolean flag for showing metadata. If set to `true`, each document entry in the returned JSON will contain a "metadata" field.<br><br>This flag only takes effect when `file` is set.<br>**Default**: `false` |
| `User` | `string` | Optional | A unique identifier representing your end-user, which will help OpenAI to monitor and detect abuse. |

## Example (as JSON)

```json
{
  "query": "the president"
}
```

