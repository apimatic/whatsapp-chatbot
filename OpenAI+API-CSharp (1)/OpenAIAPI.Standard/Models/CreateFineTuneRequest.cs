// <copyright file="CreateFineTuneRequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace OpenAIAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using OpenAIAPI.Standard;
    using OpenAIAPI.Standard.Utilities;

    /// <summary>
    /// CreateFineTuneRequest.
    /// </summary>
    public class CreateFineTuneRequest
    {
        private string validationFile;
        private string model;
        private int? nEpochs;
        private int? batchSize;
        private double? learningRateMultiplier;
        private double? promptLossWeight;
        private bool? computeClassificationMetrics;
        private int? classificationNClasses;
        private string classificationPositiveClass;
        private List<double> classificationBetas;
        private string suffix;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "validation_file", false },
            { "model", true },
            { "n_epochs", true },
            { "batch_size", false },
            { "learning_rate_multiplier", false },
            { "prompt_loss_weight", true },
            { "compute_classification_metrics", true },
            { "classification_n_classes", false },
            { "classification_positive_class", false },
            { "classification_betas", false },
            { "suffix", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFineTuneRequest"/> class.
        /// </summary>
        public CreateFineTuneRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFineTuneRequest"/> class.
        /// </summary>
        /// <param name="trainingFile">training_file.</param>
        /// <param name="validationFile">validation_file.</param>
        /// <param name="model">model.</param>
        /// <param name="nEpochs">n_epochs.</param>
        /// <param name="batchSize">batch_size.</param>
        /// <param name="learningRateMultiplier">learning_rate_multiplier.</param>
        /// <param name="promptLossWeight">prompt_loss_weight.</param>
        /// <param name="computeClassificationMetrics">compute_classification_metrics.</param>
        /// <param name="classificationNClasses">classification_n_classes.</param>
        /// <param name="classificationPositiveClass">classification_positive_class.</param>
        /// <param name="classificationBetas">classification_betas.</param>
        /// <param name="suffix">suffix.</param>
        public CreateFineTuneRequest(
            string trainingFile,
            string validationFile = null,
            string model = "curie",
            int? nEpochs = 4,
            int? batchSize = null,
            double? learningRateMultiplier = null,
            double? promptLossWeight = 0.1,
            bool? computeClassificationMetrics = false,
            int? classificationNClasses = null,
            string classificationPositiveClass = null,
            List<double> classificationBetas = null,
            string suffix = null)
        {
            this.TrainingFile = trainingFile;
            if (validationFile != null)
            {
                this.ValidationFile = validationFile;
            }

            this.Model = model;
            this.NEpochs = nEpochs;
            if (batchSize != null)
            {
                this.BatchSize = batchSize;
            }

            if (learningRateMultiplier != null)
            {
                this.LearningRateMultiplier = learningRateMultiplier;
            }

            this.PromptLossWeight = promptLossWeight;
            this.ComputeClassificationMetrics = computeClassificationMetrics;
            if (classificationNClasses != null)
            {
                this.ClassificationNClasses = classificationNClasses;
            }

            if (classificationPositiveClass != null)
            {
                this.ClassificationPositiveClass = classificationPositiveClass;
            }

            if (classificationBetas != null)
            {
                this.ClassificationBetas = classificationBetas;
            }

            if (suffix != null)
            {
                this.Suffix = suffix;
            }

        }

        /// <summary>
        /// The ID of an uploaded file that contains training data.
        /// See [upload file](/docs/api-reference/files/upload) for how to upload a file.
        /// Your dataset must be formatted as a JSONL file, where each training
        /// example is a JSON object with the keys "prompt" and "completion".
        /// Additionally, you must upload your file with the purpose `fine-tune`.
        /// See the [fine-tuning guide](/docs/guides/fine-tuning/creating-training-data) for more details.
        /// </summary>
        [JsonProperty("training_file")]
        public string TrainingFile { get; set; }

        /// <summary>
        /// The ID of an uploaded file that contains validation data.
        /// If you provide this file, the data is used to generate validation
        /// metrics periodically during fine-tuning. These metrics can be viewed in
        /// the [fine-tuning results file](/docs/guides/fine-tuning/analyzing-your-fine-tuned-model).
        /// Your train and validation data should be mutually exclusive.
        /// Your dataset must be formatted as a JSONL file, where each validation
        /// example is a JSON object with the keys "prompt" and "completion".
        /// Additionally, you must upload your file with the purpose `fine-tune`.
        /// See the [fine-tuning guide](/docs/guides/fine-tuning/creating-training-data) for more details.
        /// </summary>
        [JsonProperty("validation_file")]
        public string ValidationFile
        {
            get
            {
                return this.validationFile;
            }

            set
            {
                this.shouldSerialize["validation_file"] = true;
                this.validationFile = value;
            }
        }

        /// <summary>
        /// The name of the base model to fine-tune. You can select one of "ada",
        /// "babbage", "curie", or "davinci". To learn more about these models, see the
        /// [Models](https://beta.openai.com/docs/models) documentation.
        /// </summary>
        [JsonProperty("model")]
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.shouldSerialize["model"] = true;
                this.model = value;
            }
        }

        /// <summary>
        /// The number of epochs to train the model for. An epoch refers to one
        /// full cycle through the training dataset.
        /// </summary>
        [JsonProperty("n_epochs")]
        public int? NEpochs
        {
            get
            {
                return this.nEpochs;
            }

            set
            {
                this.shouldSerialize["n_epochs"] = true;
                this.nEpochs = value;
            }
        }

        /// <summary>
        /// The batch size to use for training. The batch size is the number of
        /// training examples used to train a single forward and backward pass.
        /// By default, the batch size will be dynamically configured to be
        /// ~0.2% of the number of examples in the training set, capped at 256 -
        /// in general, we've found that larger batch sizes tend to work better
        /// for larger datasets.
        /// </summary>
        [JsonProperty("batch_size")]
        public int? BatchSize
        {
            get
            {
                return this.batchSize;
            }

            set
            {
                this.shouldSerialize["batch_size"] = true;
                this.batchSize = value;
            }
        }

        /// <summary>
        /// The learning rate multiplier to use for training.
        /// The fine-tuning learning rate is the original learning rate used for
        /// pretraining multiplied by this value.
        /// By default, the learning rate multiplier is the 0.05, 0.1, or 0.2
        /// depending on final `batch_size` (larger learning rates tend to
        /// perform better with larger batch sizes). We recommend experimenting
        /// with values in the range 0.02 to 0.2 to see what produces the best
        /// results.
        /// </summary>
        [JsonProperty("learning_rate_multiplier")]
        public double? LearningRateMultiplier
        {
            get
            {
                return this.learningRateMultiplier;
            }

            set
            {
                this.shouldSerialize["learning_rate_multiplier"] = true;
                this.learningRateMultiplier = value;
            }
        }

        /// <summary>
        /// The weight to use for loss on the prompt tokens. This controls how
        /// much the model tries to learn to generate the prompt (as compared
        /// to the completion which always has a weight of 1.0), and can add
        /// a stabilizing effect to training when completions are short.
        /// If prompts are extremely long (relative to completions), it may make
        /// sense to reduce this weight so as to avoid over-prioritizing
        /// learning the prompt.
        /// </summary>
        [JsonProperty("prompt_loss_weight")]
        public double? PromptLossWeight
        {
            get
            {
                return this.promptLossWeight;
            }

            set
            {
                this.shouldSerialize["prompt_loss_weight"] = true;
                this.promptLossWeight = value;
            }
        }

        /// <summary>
        /// If set, we calculate classification-specific metrics such as accuracy
        /// and F-1 score using the validation set at the end of every epoch.
        /// These metrics can be viewed in the [results file](/docs/guides/fine-tuning/analyzing-your-fine-tuned-model).
        /// In order to compute classification metrics, you must provide a
        /// `validation_file`. Additionally, you must
        /// specify `classification_n_classes` for multiclass classification or
        /// `classification_positive_class` for binary classification.
        /// </summary>
        [JsonProperty("compute_classification_metrics")]
        public bool? ComputeClassificationMetrics
        {
            get
            {
                return this.computeClassificationMetrics;
            }

            set
            {
                this.shouldSerialize["compute_classification_metrics"] = true;
                this.computeClassificationMetrics = value;
            }
        }

        /// <summary>
        /// The number of classes in a classification task.
        /// This parameter is required for multiclass classification.
        /// </summary>
        [JsonProperty("classification_n_classes")]
        public int? ClassificationNClasses
        {
            get
            {
                return this.classificationNClasses;
            }

            set
            {
                this.shouldSerialize["classification_n_classes"] = true;
                this.classificationNClasses = value;
            }
        }

        /// <summary>
        /// The positive class in binary classification.
        /// This parameter is needed to generate precision, recall, and F1
        /// metrics when doing binary classification.
        /// </summary>
        [JsonProperty("classification_positive_class")]
        public string ClassificationPositiveClass
        {
            get
            {
                return this.classificationPositiveClass;
            }

            set
            {
                this.shouldSerialize["classification_positive_class"] = true;
                this.classificationPositiveClass = value;
            }
        }

        /// <summary>
        /// If this is provided, we calculate F-beta scores at the specified
        /// beta values. The F-beta score is a generalization of F-1 score.
        /// This is only used for binary classification.
        /// With a beta of 1 (i.e. the F-1 score), precision and recall are
        /// given the same weight. A larger beta score puts more weight on
        /// recall and less on precision. A smaller beta score puts more weight
        /// on precision and less on recall.
        /// </summary>
        [JsonProperty("classification_betas")]
        public List<double> ClassificationBetas
        {
            get
            {
                return this.classificationBetas;
            }

            set
            {
                this.shouldSerialize["classification_betas"] = true;
                this.classificationBetas = value;
            }
        }

        /// <summary>
        /// A string of up to 40 characters that will be added to your fine-tuned model name.
        /// For example, a `suffix` of "custom-model-name" would produce a model name like `ada:ft-your-org:custom-model-name-2022-02-15-04-21-04`.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        {
            get
            {
                return this.suffix;
            }

            set
            {
                this.shouldSerialize["suffix"] = true;
                this.suffix = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateFineTuneRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetValidationFile()
        {
            this.shouldSerialize["validation_file"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModel()
        {
            this.shouldSerialize["model"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetNEpochs()
        {
            this.shouldSerialize["n_epochs"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBatchSize()
        {
            this.shouldSerialize["batch_size"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetLearningRateMultiplier()
        {
            this.shouldSerialize["learning_rate_multiplier"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetPromptLossWeight()
        {
            this.shouldSerialize["prompt_loss_weight"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetComputeClassificationMetrics()
        {
            this.shouldSerialize["compute_classification_metrics"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetClassificationNClasses()
        {
            this.shouldSerialize["classification_n_classes"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetClassificationPositiveClass()
        {
            this.shouldSerialize["classification_positive_class"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetClassificationBetas()
        {
            this.shouldSerialize["classification_betas"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSuffix()
        {
            this.shouldSerialize["suffix"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValidationFile()
        {
            return this.shouldSerialize["validation_file"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModel()
        {
            return this.shouldSerialize["model"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNEpochs()
        {
            return this.shouldSerialize["n_epochs"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatchSize()
        {
            return this.shouldSerialize["batch_size"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLearningRateMultiplier()
        {
            return this.shouldSerialize["learning_rate_multiplier"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePromptLossWeight()
        {
            return this.shouldSerialize["prompt_loss_weight"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeComputeClassificationMetrics()
        {
            return this.shouldSerialize["compute_classification_metrics"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClassificationNClasses()
        {
            return this.shouldSerialize["classification_n_classes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClassificationPositiveClass()
        {
            return this.shouldSerialize["classification_positive_class"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClassificationBetas()
        {
            return this.shouldSerialize["classification_betas"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSuffix()
        {
            return this.shouldSerialize["suffix"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CreateFineTuneRequest other &&
                ((this.TrainingFile == null && other.TrainingFile == null) || (this.TrainingFile?.Equals(other.TrainingFile) == true)) &&
                ((this.ValidationFile == null && other.ValidationFile == null) || (this.ValidationFile?.Equals(other.ValidationFile) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.NEpochs == null && other.NEpochs == null) || (this.NEpochs?.Equals(other.NEpochs) == true)) &&
                ((this.BatchSize == null && other.BatchSize == null) || (this.BatchSize?.Equals(other.BatchSize) == true)) &&
                ((this.LearningRateMultiplier == null && other.LearningRateMultiplier == null) || (this.LearningRateMultiplier?.Equals(other.LearningRateMultiplier) == true)) &&
                ((this.PromptLossWeight == null && other.PromptLossWeight == null) || (this.PromptLossWeight?.Equals(other.PromptLossWeight) == true)) &&
                ((this.ComputeClassificationMetrics == null && other.ComputeClassificationMetrics == null) || (this.ComputeClassificationMetrics?.Equals(other.ComputeClassificationMetrics) == true)) &&
                ((this.ClassificationNClasses == null && other.ClassificationNClasses == null) || (this.ClassificationNClasses?.Equals(other.ClassificationNClasses) == true)) &&
                ((this.ClassificationPositiveClass == null && other.ClassificationPositiveClass == null) || (this.ClassificationPositiveClass?.Equals(other.ClassificationPositiveClass) == true)) &&
                ((this.ClassificationBetas == null && other.ClassificationBetas == null) || (this.ClassificationBetas?.Equals(other.ClassificationBetas) == true)) &&
                ((this.Suffix == null && other.Suffix == null) || (this.Suffix?.Equals(other.Suffix) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TrainingFile = {(this.TrainingFile == null ? "null" : this.TrainingFile == string.Empty ? "" : this.TrainingFile)}");
            toStringOutput.Add($"this.ValidationFile = {(this.ValidationFile == null ? "null" : this.ValidationFile == string.Empty ? "" : this.ValidationFile)}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model == string.Empty ? "" : this.Model)}");
            toStringOutput.Add($"this.NEpochs = {(this.NEpochs == null ? "null" : this.NEpochs.ToString())}");
            toStringOutput.Add($"this.BatchSize = {(this.BatchSize == null ? "null" : this.BatchSize.ToString())}");
            toStringOutput.Add($"this.LearningRateMultiplier = {(this.LearningRateMultiplier == null ? "null" : this.LearningRateMultiplier.ToString())}");
            toStringOutput.Add($"this.PromptLossWeight = {(this.PromptLossWeight == null ? "null" : this.PromptLossWeight.ToString())}");
            toStringOutput.Add($"this.ComputeClassificationMetrics = {(this.ComputeClassificationMetrics == null ? "null" : this.ComputeClassificationMetrics.ToString())}");
            toStringOutput.Add($"this.ClassificationNClasses = {(this.ClassificationNClasses == null ? "null" : this.ClassificationNClasses.ToString())}");
            toStringOutput.Add($"this.ClassificationPositiveClass = {(this.ClassificationPositiveClass == null ? "null" : this.ClassificationPositiveClass == string.Empty ? "" : this.ClassificationPositiveClass)}");
            toStringOutput.Add($"this.ClassificationBetas = {(this.ClassificationBetas == null ? "null" : $"[{string.Join(", ", this.ClassificationBetas)} ]")}");
            toStringOutput.Add($"this.Suffix = {(this.Suffix == null ? "null" : this.Suffix == string.Empty ? "" : this.Suffix)}");
        }
    }
}