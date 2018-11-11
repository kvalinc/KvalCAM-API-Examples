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
    /// The circle feature type, produces a circular cut with a given diameter and depth
    /// </summary>
    [DataContract]
    public partial class Circle : AbstractFeature,  IEquatable<Circle>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Circle() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        /// <param name="Bevel">Bevel value in degrees for the circle.</param>
        /// <param name="Diameter">Target nominal diameter of the circle, this diameter is cut if the machine/tools can produce it.</param>
        /// <param name="DiameterMinimum">Minimum allowed diameter for the circle, if machine/tools unable to produce target diameter then this is the minimum acceptable diameter.</param>
        /// <param name="DiameterMaximum">Maximum allowed diameter for the circle, if machine/tools unable to produce target diameter then this is the maximum acceptable diameter.</param>
        /// <param name="Depth">Target nominal depth of the circle, this depth is is cut if machine/tools can produce it.</param>
        /// <param name="DepthMinimum">Minimum allowed depth of the circle, if machine/tools unable to produce target depth then this is the minimum acceptable depth.</param>
        /// <param name="DepthMaximum">Maximum allowed depth of the circle, if machine/tools unable to produce target depth then this is the maximum acceptable depth.</param>
        public Circle(string Bevel = default(string), string Diameter = default(string), string DiameterMinimum = default(string), string DiameterMaximum = default(string), string Depth = default(string), string DepthMinimum = default(string), string DepthMaximum = default(string), string Name = default(string), string Description = default(string), string TLocation = default(string), string WLocation = default(string), string LLocation = default(string), DoorSideEnum? DoorSide = default(DoorSideEnum?), List<AbstractFeature> Children = default(List<AbstractFeature>), string Type = "Circle") : base(Name, Description, TLocation, WLocation, LLocation, DoorSide, Children, Type)
        {
            this.Bevel = Bevel;
            this.Diameter = Diameter;
            this.DiameterMinimum = DiameterMinimum;
            this.DiameterMaximum = DiameterMaximum;
            this.Depth = Depth;
            this.DepthMinimum = DepthMinimum;
            this.DepthMaximum = DepthMaximum;
        }
        
        /// <summary>
        /// Bevel value in degrees for the circle
        /// </summary>
        /// <value>Bevel value in degrees for the circle</value>
        [DataMember(Name="Bevel", EmitDefaultValue=false)]
        public string Bevel { get; set; }

        /// <summary>
        /// Target nominal diameter of the circle, this diameter is cut if the machine/tools can produce it
        /// </summary>
        /// <value>Target nominal diameter of the circle, this diameter is cut if the machine/tools can produce it</value>
        [DataMember(Name="Diameter", EmitDefaultValue=false)]
        public string Diameter { get; set; }

        /// <summary>
        /// Minimum allowed diameter for the circle, if machine/tools unable to produce target diameter then this is the minimum acceptable diameter
        /// </summary>
        /// <value>Minimum allowed diameter for the circle, if machine/tools unable to produce target diameter then this is the minimum acceptable diameter</value>
        [DataMember(Name="DiameterMinimum", EmitDefaultValue=false)]
        public string DiameterMinimum { get; set; }

        /// <summary>
        /// Maximum allowed diameter for the circle, if machine/tools unable to produce target diameter then this is the maximum acceptable diameter
        /// </summary>
        /// <value>Maximum allowed diameter for the circle, if machine/tools unable to produce target diameter then this is the maximum acceptable diameter</value>
        [DataMember(Name="DiameterMaximum", EmitDefaultValue=false)]
        public string DiameterMaximum { get; set; }

        /// <summary>
        /// Target nominal depth of the circle, this depth is is cut if machine/tools can produce it
        /// </summary>
        /// <value>Target nominal depth of the circle, this depth is is cut if machine/tools can produce it</value>
        [DataMember(Name="Depth", EmitDefaultValue=false)]
        public string Depth { get; set; }

        /// <summary>
        /// Minimum allowed depth of the circle, if machine/tools unable to produce target depth then this is the minimum acceptable depth
        /// </summary>
        /// <value>Minimum allowed depth of the circle, if machine/tools unable to produce target depth then this is the minimum acceptable depth</value>
        [DataMember(Name="DepthMinimum", EmitDefaultValue=false)]
        public string DepthMinimum { get; set; }

        /// <summary>
        /// Maximum allowed depth of the circle, if machine/tools unable to produce target depth then this is the maximum acceptable depth
        /// </summary>
        /// <value>Maximum allowed depth of the circle, if machine/tools unable to produce target depth then this is the maximum acceptable depth</value>
        [DataMember(Name="DepthMaximum", EmitDefaultValue=false)]
        public string DepthMaximum { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Circle {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Bevel: ").Append(Bevel).Append("\n");
            sb.Append("  Diameter: ").Append(Diameter).Append("\n");
            sb.Append("  DiameterMinimum: ").Append(DiameterMinimum).Append("\n");
            sb.Append("  DiameterMaximum: ").Append(DiameterMaximum).Append("\n");
            sb.Append("  Depth: ").Append(Depth).Append("\n");
            sb.Append("  DepthMinimum: ").Append(DepthMinimum).Append("\n");
            sb.Append("  DepthMaximum: ").Append(DepthMaximum).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as Circle);
        }

        /// <summary>
        /// Returns true if Circle instances are equal
        /// </summary>
        /// <param name="input">Instance of Circle to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Circle input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Bevel == input.Bevel ||
                    (this.Bevel != null &&
                    this.Bevel.Equals(input.Bevel))
                ) && base.Equals(input) && 
                (
                    this.Diameter == input.Diameter ||
                    (this.Diameter != null &&
                    this.Diameter.Equals(input.Diameter))
                ) && base.Equals(input) && 
                (
                    this.DiameterMinimum == input.DiameterMinimum ||
                    (this.DiameterMinimum != null &&
                    this.DiameterMinimum.Equals(input.DiameterMinimum))
                ) && base.Equals(input) && 
                (
                    this.DiameterMaximum == input.DiameterMaximum ||
                    (this.DiameterMaximum != null &&
                    this.DiameterMaximum.Equals(input.DiameterMaximum))
                ) && base.Equals(input) && 
                (
                    this.Depth == input.Depth ||
                    (this.Depth != null &&
                    this.Depth.Equals(input.Depth))
                ) && base.Equals(input) && 
                (
                    this.DepthMinimum == input.DepthMinimum ||
                    (this.DepthMinimum != null &&
                    this.DepthMinimum.Equals(input.DepthMinimum))
                ) && base.Equals(input) && 
                (
                    this.DepthMaximum == input.DepthMaximum ||
                    (this.DepthMaximum != null &&
                    this.DepthMaximum.Equals(input.DepthMaximum))
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
                int hashCode = base.GetHashCode();
                if (this.Bevel != null)
                    hashCode = hashCode * 59 + this.Bevel.GetHashCode();
                if (this.Diameter != null)
                    hashCode = hashCode * 59 + this.Diameter.GetHashCode();
                if (this.DiameterMinimum != null)
                    hashCode = hashCode * 59 + this.DiameterMinimum.GetHashCode();
                if (this.DiameterMaximum != null)
                    hashCode = hashCode * 59 + this.DiameterMaximum.GetHashCode();
                if (this.Depth != null)
                    hashCode = hashCode * 59 + this.Depth.GetHashCode();
                if (this.DepthMinimum != null)
                    hashCode = hashCode * 59 + this.DepthMinimum.GetHashCode();
                if (this.DepthMaximum != null)
                    hashCode = hashCode * 59 + this.DepthMaximum.GetHashCode();
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
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
