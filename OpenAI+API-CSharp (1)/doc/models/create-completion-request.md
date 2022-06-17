
# Create Completion Request

## Structure

`CreateCompletionRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Model` | `string` | Required | ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them. |
| `Prompt` | `string` | Optional | The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.<br><br>Note that <\|endoftext\|> is the document separator that the model sees during training, so if a prompt is not specified the model will generate as if from the beginning of a new document.<br>**Default**: `"<\|endoftext\|>"` |
| `Suffix` | `string` | Optional | The suffix that comes after a completion of inserted text. |
| `MaxTokens` | `int?` | Optional | The maximum number of [tokens](/tokenizer) to generate in the completion.<br><br>The token count of your prompt plus `max_tokens` cannot exceed the model's context length. Most models have a context length of 2048 tokens (except for the newest models, which support 4096).<br>**Default**: `16`<br>**Constraints**: `>= 0` |
| `Temperature` | `double?` | Optional | What [sampling temperature](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277) to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.<br><br>We generally recommend altering this or `top_p` but not both.<br>**Default**: `1`<br>**Constraints**: `>= 0`, `<= 2` |
| `TopP` | `double?` | Optional | An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.<br><br>We generally recommend altering this or `temperature` but not both.<br>**Default**: `1`<br>**Constraints**: `>= 0`, `<= 1` |
| `N` | `int?` | Optional | How many completions to generate for each prompt.<br><br>**Note:** Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.<br>**Default**: `1`<br>**Constraints**: `>= 1`, `<= 128` |
| `Stream` | `bool?` | Optional | Whether to stream back partial progress. If set, tokens will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available, with the stream terminated by a `data: [DONE]` message.<br>**Default**: `false` |
| `Logprobs` | `int?` | Optional | Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens. For example, if `logprobs` is 5, the API will return a list of the 5 most likely tokens. The API will always return the `logprob` of the sampled token, so there may be up to `logprobs+1` elements in the response.<br><br>The maximum value for `logprobs` is 5. If you need more than this, please contact support@openai.com and describe your use case.<br>**Constraints**: `>= 0`, `<= 5` |
| `Echo` | `bool?` | Optional | Echo back the prompt in addition to the completion<br>**Default**: `false` |
| `Stop` | `string` | Optional | Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence. |
| `PresencePenalty` | `double?` | Optional | Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.<br><br>[See more information about frequency and presence penalties.](/docs/api-reference/parameter-details)<br>**Default**: `0`<br>**Constraints**: `>= -2`, `<= 2` |
| `FrequencyPenalty` | `double?` | Optional | Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.<br><br>[See more information about frequency and presence penalties.](/docs/api-reference/parameter-details)<br>**Default**: `0`<br>**Constraints**: `>= -2`, `<= 2` |
| `BestOf` | `int?` | Optional | Generates `best_of` completions server-side and returns the "best" (the one with the highest log probability per token). Results cannot be streamed.<br><br>When used with `n`, `best_of` controls the number of candidate completions and `n` specifies how many to return – `best_of` must be greater than `n`.<br><br>**Note:** Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.<br>**Default**: `1`<br>**Constraints**: `>= 0`, `<= 20` |
| `LogitBias` | `object` | Optional | Modify the likelihood of specified tokens appearing in the completion.<br><br>Accepts a json object that maps tokens (specified by their token ID in the GPT tokenizer) to an associated bias value from -100 to 100. You can use this [tokenizer tool](/tokenizer?view=bpe) (which works for both GPT-2 and GPT-3) to convert text to token IDs. Mathematically, the bias is added to the logits generated by the model prior to sampling. The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.<br><br>As an example, you can pass `{"50256": -100}` to prevent the <\|endoftext\|> token from being generated. |
| `User` | `string` | Optional | A unique identifier representing your end-user, which will help OpenAI to monitor and detect abuse. |

## Example (as JSON)

```json
{
  "model": "model2",
  "prompt": null,
  "suffix": null,
  "max_tokens": null,
  "temperature": null,
  "top_p": null,
  "n": null,
  "stream": null,
  "logprobs": null,
  "echo": null,
  "stop": null,
  "presence_penalty": null,
  "frequency_penalty": null,
  "best_of": null,
  "logit_bias": null,
  "user": null
}
```

