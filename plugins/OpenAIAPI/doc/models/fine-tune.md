
# Fine Tune

## Structure

`FineTune`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | - |
| `MObject` | `string` | Optional | - |
| `CreatedAt` | `int?` | Optional | - |
| `UpdatedAt` | `int?` | Optional | - |
| `Model` | `string` | Optional | - |
| `FineTunedModel` | `string` | Optional | - |
| `OrganizationId` | `string` | Optional | - |
| `Status` | `string` | Optional | - |
| `Hyperparams` | `object` | Optional | - |
| `TrainingFiles` | [`List<Models.OpenAIFile>`](../../doc/models/open-ai-file.md) | Optional | - |
| `ValidationFiles` | [`List<Models.OpenAIFile>`](../../doc/models/open-ai-file.md) | Optional | - |
| `ResultFiles` | [`List<Models.OpenAIFile>`](../../doc/models/open-ai-file.md) | Optional | - |
| `Events` | [`List<Models.FineTuneEvent>`](../../doc/models/fine-tune-event.md) | Optional | - |

## Example (as JSON)

```json
{
  "id": null,
  "object": null,
  "created_at": null,
  "updated_at": null,
  "model": null,
  "fine_tuned_model": null,
  "organization_id": null,
  "status": null,
  "hyperparams": null,
  "training_files": null,
  "validation_files": null,
  "result_files": null,
  "events": null
}
```

