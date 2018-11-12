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
    /// The teeshape feature type, produces a teeshape cut composed of a tee neck part and main rectangle part with four corner radii
    /// </summary>
    [DataContract]
    public partial class TeeShape : AbstractFeature,  IEquatable<TeeShape>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeeShape" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TeeShape() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TeeShape" /> class.
        /// </summary>
        /// <param name="Bevel">Bevel value in degrees for the teeshape.</param>
        /// <param name="TeeRelativeLocation">Center of the tee neck part relative to teeshape center along the lengthwise dimension (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side).</param>
        /// <param name="TeeLength">Length of the tee neck part (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side).</param>
        /// <param name="MainLength">Length of the main rectangle part of the teeshape (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side).</param>
        /// <param name="MainWidth">Width of the main rectangle part of the teeshape (along T-axis).</param>
        /// <param name="Depth">Depth of the teeshape.</param>
        /// <param name="Radius1">Corner radius closest to lengthwise dimension reference (L-axis or W-axis) and closest to widthwise dimension reference (T-axis).</param>
        /// <param name="Radius2">Corner radius furthest from lengthwise dimension reference (L-axis or W-axis) and closest to widthwise dimension reference (T-axis).</param>
        /// <param name="Radius3">Corner radius closest to lengthwise dimension reference (L-axis or W-axis) and furthest from widthwise dimension reference (T-axis).</param>
        /// <param name="Radius4">Corner radius furthest from lengthwise dimension reference (L-axis or W-axis) and furthest from widthwise dimension reference (T-axis).</param>
        public TeeShape(string Bevel = default(string), string TeeRelativeLocation = default(string), string TeeLength = default(string), string MainLength = default(string), string MainWidth = default(string), string Depth = default(string), string Radius1 = default(string), string Radius2 = default(string), string Radius3 = default(string), string Radius4 = default(string), string Name = default(string), string Description = default(string), string TLocation = default(string), string WLocation = default(string), string LLocation = default(string), DoorSideEnum? DoorSide = default(DoorSideEnum?), List<AbstractFeature> Children = default(List<AbstractFeature>)) : base(Name, Description, TLocation, WLocation, LLocation, DoorSide, Children, "TeeShape")
        {
            this.Bevel = Bevel;
            this.TeeRelativeLocation = TeeRelativeLocation;
            this.TeeLength = TeeLength;
            this.MainLength = MainLength;
            this.MainWidth = MainWidth;
            this.Depth = Depth;
            this.Radius1 = Radius1;
            this.Radius2 = Radius2;
            this.Radius3 = Radius3;
            this.Radius4 = Radius4;
        }
        
        /// <summary>
        /// Bevel value in degrees for the teeshape
        /// </summary>
        /// <value>Bevel value in degrees for the teeshape</value>
        [DataMember(Name="Bevel", EmitDefaultValue=false)]
        public string Bevel { get; set; }

        /// <summary>
        /// Center of the tee neck part relative to teeshape center along the lengthwise dimension (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side)
        /// </summary>
        /// <value>Center of the tee neck part relative to teeshape center along the lengthwise dimension (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side)</value>
        [DataMember(Name="TeeRelativeLocation", EmitDefaultValue=false)]
        public string TeeRelativeLocation { get; set; }

        /// <summary>
        /// Length of the tee neck part (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side)
        /// </summary>
        /// <value>Length of the tee neck part (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side)</value>
        [DataMember(Name="TeeLength", EmitDefaultValue=false)]
        public string TeeLength { get; set; }

        /// <summary>
        /// Length of the main rectangle part of the teeshape (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side)
        /// </summary>
        /// <value>Length of the main rectangle part of the teeshape (along L-axis if on the hinge or lock door side, W-axis if on the top or bottom door side)</value>
        [DataMember(Name="MainLength", EmitDefaultValue=false)]
        public string MainLength { get; set; }

        /// <summary>
        /// Width of the main rectangle part of the teeshape (along T-axis)
        /// </summary>
        /// <value>Width of the main rectangle part of the teeshape (along T-axis)</value>
        [DataMember(Name="MainWidth", EmitDefaultValue=false)]
        public string MainWidth { get; set; }

        /// <summary>
        /// Depth of the teeshape
        /// </summary>
        /// <value>Depth of the teeshape</value>
        [DataMember(Name="Depth", EmitDefaultValue=false)]
        public string Depth { get; set; }

        /// <summary>
        /// Corner radius closest to lengthwise dimension reference (L-axis or W-axis) and closest to widthwise dimension reference (T-axis)
        /// </summary>
        /// <value>Corner radius closest to lengthwise dimension reference (L-axis or W-axis) and closest to widthwise dimension reference (T-axis)</value>
        [DataMember(Name="Radius1", EmitDefaultValue=false)]
        public string Radius1 { get; set; }

        /// <summary>
        /// Corner radius furthest from lengthwise dimension reference (L-axis or W-axis) and closest to widthwise dimension reference (T-axis)
        /// </summary>
        /// <value>Corner radius furthest from lengthwise dimension reference (L-axis or W-axis) and closest to widthwise dimension reference (T-axis)</value>
        [DataMember(Name="Radius2", EmitDefaultValue=false)]
        public string Radius2 { get; set; }

        /// <summary>
        /// Corner radius closest to lengthwise dimension reference (L-axis or W-axis) and furthest from widthwise dimension reference (T-axis)
        /// </summary>
        /// <value>Corner radius closest to lengthwise dimension reference (L-axis or W-axis) and furthest from widthwise dimension reference (T-axis)</value>
        [DataMember(Name="Radius3", EmitDefaultValue=false)]
        public string Radius3 { get; set; }

        /// <summary>
        /// Corner radius furthest from lengthwise dimension reference (L-axis or W-axis) and furthest from widthwise dimension reference (T-axis)
        /// </summary>
        /// <value>Corner radius furthest from lengthwise dimension reference (L-axis or W-axis) and furthest from widthwise dimension reference (T-axis)</value>
        [DataMember(Name="Radius4", EmitDefaultValue=false)]
        public string Radius4 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TeeShape {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Bevel: ").Append(Bevel).Append("\n");
            sb.Append("  TeeRelativeLocation: ").Append(TeeRelativeLocation).Append("\n");
            sb.Append("  TeeLength: ").Append(TeeLength).Append("\n");
            sb.Append("  MainLength: ").Append(MainLength).Append("\n");
            sb.Append("  MainWidth: ").Append(MainWidth).Append("\n");
            sb.Append("  Depth: ").Append(Depth).Append("\n");
            sb.Append("  Radius1: ").Append(Radius1).Append("\n");
            sb.Append("  Radius2: ").Append(Radius2).Append("\n");
            sb.Append("  Radius3: ").Append(Radius3).Append("\n");
            sb.Append("  Radius4: ").Append(Radius4).Append("\n");
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
            return this.Equals(input as TeeShape);
        }

        /// <summary>
        /// Returns true if TeeShape instances are equal
        /// </summary>
        /// <param name="input">Instance of TeeShape to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TeeShape input)
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
                    this.TeeRelativeLocation == input.TeeRelativeLocation ||
                    (this.TeeRelativeLocation != null &&
                    this.TeeRelativeLocation.Equals(input.TeeRelativeLocation))
                ) && base.Equals(input) && 
                (
                    this.TeeLength == input.TeeLength ||
                    (this.TeeLength != null &&
                    this.TeeLength.Equals(input.TeeLength))
                ) && base.Equals(input) && 
                (
                    this.MainLength == input.MainLength ||
                    (this.MainLength != null &&
                    this.MainLength.Equals(input.MainLength))
                ) && base.Equals(input) && 
                (
                    this.MainWidth == input.MainWidth ||
                    (this.MainWidth != null &&
                    this.MainWidth.Equals(input.MainWidth))
                ) && base.Equals(input) && 
                (
                    this.Depth == input.Depth ||
                    (this.Depth != null &&
                    this.Depth.Equals(input.Depth))
                ) && base.Equals(input) && 
                (
                    this.Radius1 == input.Radius1 ||
                    (this.Radius1 != null &&
                    this.Radius1.Equals(input.Radius1))
                ) && base.Equals(input) && 
                (
                    this.Radius2 == input.Radius2 ||
                    (this.Radius2 != null &&
                    this.Radius2.Equals(input.Radius2))
                ) && base.Equals(input) && 
                (
                    this.Radius3 == input.Radius3 ||
                    (this.Radius3 != null &&
                    this.Radius3.Equals(input.Radius3))
                ) && base.Equals(input) && 
                (
                    this.Radius4 == input.Radius4 ||
                    (this.Radius4 != null &&
                    this.Radius4.Equals(input.Radius4))
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
                if (this.TeeRelativeLocation != null)
                    hashCode = hashCode * 59 + this.TeeRelativeLocation.GetHashCode();
                if (this.TeeLength != null)
                    hashCode = hashCode * 59 + this.TeeLength.GetHashCode();
                if (this.MainLength != null)
                    hashCode = hashCode * 59 + this.MainLength.GetHashCode();
                if (this.MainWidth != null)
                    hashCode = hashCode * 59 + this.MainWidth.GetHashCode();
                if (this.Depth != null)
                    hashCode = hashCode * 59 + this.Depth.GetHashCode();
                if (this.Radius1 != null)
                    hashCode = hashCode * 59 + this.Radius1.GetHashCode();
                if (this.Radius2 != null)
                    hashCode = hashCode * 59 + this.Radius2.GetHashCode();
                if (this.Radius3 != null)
                    hashCode = hashCode * 59 + this.Radius3.GetHashCode();
                if (this.Radius4 != null)
                    hashCode = hashCode * 59 + this.Radius4.GetHashCode();
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
