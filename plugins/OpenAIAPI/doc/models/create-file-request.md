
# Create File Request

## Structure

`CreateFileRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `File` | `Stream` | Required | Name of the [JSON Lines](https://jsonlines.readthedocs.io/en/latest/) file to be uploaded.<br><br>If the `purpose` is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your [training examples](/docs/guides/fine-tuning/prepare-training-data). |
| `Purpose` | `string` | Required | The intended purpose of the uploaded documents.<br><br>Use "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tunes). This allows us to validate the format of the uploaded file. |

## Example (as JSON)

```json
{
  "file": "file",
  "purpose": "purpose6"
}
```

