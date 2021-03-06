
# Create Fine Tune Request

## Structure

`CreateFineTuneRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `TrainingFile` | `string` | Required | The ID of an uploaded file that contains training data.<br><br>See [upload file](/docs/api-reference/files/upload) for how to upload a file.<br><br>Your dataset must be formatted as a JSONL file, where each training<br>example is a JSON object with the keys "prompt" and "completion".<br>Additionally, you must upload your file with the purpose `fine-tune`.<br><br>See the [fine-tuning guide](/docs/guides/fine-tuning/creating-training-data) for more details. |
| `ValidationFile` | `string` | Optional | The ID of an uploaded file that contains validation data.<br><br>If you provide this file, the data is used to generate validation<br>metrics periodically during fine-tuning. These metrics can be viewed in<br>the [fine-tuning results file](/docs/guides/fine-tuning/analyzing-your-fine-tuned-model).<br>Your train and validation data should be mutually exclusive.<br><br>Your dataset must be formatted as a JSONL file, where each validation<br>example is a JSON object with the keys "prompt" and "completion".<br>Additionally, you must upload your file with the purpose `fine-tune`.<br><br>See the [fine-tuning guide](/docs/guides/fine-tuning/creating-training-data) for more details. |
| `Model` | `string` | Optional | The name of the base model to fine-tune. You can select one of "ada",<br>"babbage", "curie", or "davinci". To learn more about these models, see the<br>[Models](https://beta.openai.com/docs/models) documentation.<br>**Default**: `"curie"` |
| `NEpochs` | `int?` | Optional | The number of epochs to train the model for. An epoch refers to one<br>full cycle through the training dataset.<br>**Default**: `4` |
| `BatchSize` | `int?` | Optional | The batch size to use for training. The batch size is the number of<br>training examples used to train a single forward and backward pass.<br><br>By default, the batch size will be dynamically configured to be<br>~0.2% of the number of examples in the training set, capped at 256 -<br>in general, we've found that larger batch sizes tend to work better<br>for larger datasets. |
| `LearningRateMultiplier` | `double?` | Optional | The learning rate multiplier to use for training.<br>The fine-tuning learning rate is the original learning rate used for<br>pretraining multiplied by this value.<br><br>By default, the learning rate multiplier is the 0.05, 0.1, or 0.2<br>depending on final `batch_size` (larger learning rates tend to<br>perform better with larger batch sizes). We recommend experimenting<br>with values in the range 0.02 to 0.2 to see what produces the best<br>results. |
| `PromptLossWeight` | `double?` | Optional | The weight to use for loss on the prompt tokens. This controls how<br>much the model tries to learn to generate the prompt (as compared<br>to the completion which always has a weight of 1.0), and can add<br>a stabilizing effect to training when completions are short.<br><br>If prompts are extremely long (relative to completions), it may make<br>sense to reduce this weight so as to avoid over-prioritizing<br>learning the prompt.<br>**Default**: `0.1` |
| `ComputeClassificationMetrics` | `bool?` | Optional | If set, we calculate classification-specific metrics such as accuracy<br>and F-1 score using the validation set at the end of every epoch.<br>These metrics can be viewed in the [results file](/docs/guides/fine-tuning/analyzing-your-fine-tuned-model).<br><br>In order to compute classification metrics, you must provide a<br>`validation_file`. Additionally, you must<br>specify `classification_n_classes` for multiclass classification or<br>`classification_positive_class` for binary classification.<br>**Default**: `false` |
| `ClassificationNClasses` | `int?` | Optional | The number of classes in a classification task.<br><br>This parameter is required for multiclass classification. |
| `ClassificationPositiveClass` | `string` | Optional | The positive class in binary classification.<br><br>This parameter is needed to generate precision, recall, and F1<br>metrics when doing binary classification. |
| `ClassificationBetas` | `List<double>` | Optional | If this is provided, we calculate F-beta scores at the specified<br>beta values. The F-beta score is a generalization of F-1 score.<br>This is only used for binary classification.<br><br>With a beta of 1 (i.e. the F-1 score), precision and recall are<br>given the same weight. A larger beta score puts more weight on<br>recall and less on precision. A smaller beta score puts more weight<br>on precision and less on recall. |
| `Suffix` | `string` | Optional | A string of up to 40 characters that will be added to your fine-tuned model name.<br><br>For example, a `suffix` of "custom-model-name" would produce a model name like `ada:ft-your-org:custom-model-name-2022-02-15-04-21-04`.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `40` |

## Example (as JSON)

```json
{
  "training_file": "file-ajSREls59WBbvgSzJSVWxMCB"
}
```

