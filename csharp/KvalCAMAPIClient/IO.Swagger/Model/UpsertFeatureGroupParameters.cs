/* 
 * KvalCAM API
 *
 * KvalCAM interactive API documentation  Additional documentation is available here: https://docs.kvalinc.com/display/CAM/API  Examples are available on github here: https://github.com/kvalinc/KvalCAMAPIExamples
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Parameters for inserting or updating a feature group
    /// </summary>
    [DataContract]
    public partial class UpsertFeatureGroupParameters :  IEquatable<UpsertFeatureGroupParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertFeatureGroupParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpsertFeatureGroupParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertFeatureGroupParameters" /> class.
        /// </summary>
        /// <param name="FeatureGroup">Feature group data used to insert or update a feature group, id in feature group is used (required).</param>
        public UpsertFeatureGroupParameters(FeatureGroup FeatureGroup = default(FeatureGroup))
        {
            // to ensure "FeatureGroup" is required (not null)
            if (FeatureGroup == null)
            {
                throw new InvalidDataException("FeatureGroup is a required property for UpsertFeatureGroupParameters and cannot be null");
            }
            else
            {
                this.FeatureGroup = FeatureGroup;
            }
        }
        
        /// <summary>
        /// Feature group data used to insert or update a feature group, id in feature group is used
        /// </summary>
        /// <value>Feature group data used to insert or update a feature group, id in feature group is used</value>
        [DataMember(Name="FeatureGroup", EmitDefaultValue=false)]
        public FeatureGroup FeatureGroup { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpsertFeatureGroupParameters {\n");
            sb.Append("  FeatureGroup: ").Append(FeatureGroup).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UpsertFeatureGroupParameters);
        }

        /// <summary>
        /// Returns true if UpsertFeatureGroupParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of UpsertFeatureGroupParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpsertFeatureGroupParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FeatureGroup == input.FeatureGroup ||
                    (this.FeatureGroup != null &&
                    this.FeatureGroup.Equals(input.FeatureGroup))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.FeatureGroup != null)
                    hashCode = hashCode * 59 + this.FeatureGroup.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}