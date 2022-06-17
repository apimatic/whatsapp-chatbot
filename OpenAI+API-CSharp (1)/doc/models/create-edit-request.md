
# Create Edit Request

## Structure

`CreateEditRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Model` | `string` | Required | ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them. |
| `Input` | `string` | Optional | The input text to use as a starting point for the edit. |
| `Instruction` | `string` | Required | The instruction that tells the model how to edit the prompt. |
| `N` | `int?` | Optional | How many edits to generate for the input and instruction.<br>**Default**: `1`<br>**Constraints**: `>= 1`, `<= 20` |
| `Temperature` | `double?` | Optional | What [sampling temperature](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277) to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.<br><br>We generally recommend altering this or `top_p` but not both.<br>**Default**: `1`<br>**Constraints**: `>= 0`, `<= 2` |
| `TopP` | `double?` | Optional | An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.<br><br>We generally recommend altering this or `temperature` but not both.<br>**Default**: `1`<br>**Constraints**: `>= 0`, `<= 1` |

## Example (as JSON)

```json
{
  "model": null,
  "instruction": "Fix the spelling mistakes."
}
```

