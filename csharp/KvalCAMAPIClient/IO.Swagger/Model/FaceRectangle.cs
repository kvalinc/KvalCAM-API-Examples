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
    /// The face rectangle feature type, produces a rectangle cut on the face of the door with four corner radii and two depths given (one for each side of the face)
    /// </summary>
    [DataContract]
    public partial class FaceRectangle : AbstractFeature,  IEquatable<FaceRectangle>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceRectangle" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FaceRectangle() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceRectangle" /> class.
        /// </summary>
        /// <param name="Length">Length of the face rectangle (along L-axis).</param>
        /// <param name="Width">Width of the rectangle (along W-axis).</param>
        /// <param name="Radius1">Corner radius closest to lengthwise dimension reference (L-axis) and closest to widthwise dimension reference (W-axis).</param>
        /// <param name="Radius2">Corner radius furthest from lengthwise dimension reference (L-axis) and closest to widthwise dimension reference (W-axis).</param>
        /// <param name="Radius3">Corner radius closest to lengthwise dimension reference (L-axis) and furthest from widthwise dimension reference (W-axis).</param>
        /// <param name="Radius4">Corner radius furthest from lengthwise dimension reference (L-axis) and furthest from widthwise dimension reference (W-axis).</param>
        /// <param name="DepthClosestToRef">Depth closest to the T-axis reference.</param>
        /// <param name="DepthFurthestFromRef">Depth furthest from the T-axis reference.</param>
        /// <param name="ClipPockets">ClipPockets augmentation for special fire clip insert cuts, requires special tooling, may be null/is optional.</param>
        public FaceRectangle(string Length = default(string), string Width = default(string), string Radius1 = default(string), string Radius2 = default(string), string Radius3 = default(string), string Radius4 = default(string), string DepthClosestToRef = default(string), string DepthFurthestFromRef = default(string), ClipPockets ClipPockets = default(ClipPockets), string Name = default(string), string Description = default(string), string TLocation = default(string), string WLocation = default(string), string LLocation = default(string), DoorSideEnum? DoorSide = default(DoorSideEnum?), List<AbstractFeature> Children = default(List<AbstractFeature>)) : base(Name, Description, TLocation, WLocation, LLocation, DoorSide, Children, "FaceRectangle")
        {
            this.Length = Length;
            this.Width = Width;
            this.Radius1 = Radius1;
            this.Radius2 = Radius2;
            this.Radius3 = Radius3;
            this.Radius4 = Radius4;
            this.DepthClosestToRef = DepthClosestToRef;
            this.DepthFurthestFromRef = DepthFurthestFromRef;
            this.ClipPockets = ClipPockets;
        }
        
        /// <summary>
        /// Length of the face rectangle (along L-axis)
        /// </summary>
        /// <value>Length of the face rectangle (along L-axis)</value>
        [DataMember(Name="Length", EmitDefaultValue=false)]
        public string Length { get; set; }

        /// <summary>
        /// Width of the rectangle (along W-axis)
        /// </summary>
        /// <value>Width of the rectangle (along W-axis)</value>
        [DataMember(Name="Width", EmitDefaultValue=false)]
        public string Width { get; set; }

        /// <summary>
        /// Corner radius closest to lengthwise dimension reference (L-axis) and closest to widthwise dimension reference (W-axis)
        /// </summary>
        /// <value>Corner radius closest to lengthwise dimension reference (L-axis) and closest to widthwise dimension reference (W-axis)</value>
        [DataMember(Name="Radius1", EmitDefaultValue=false)]
        public string Radius1 { get; set; }

        /// <summary>
        /// Corner radius furthest from lengthwise dimension reference (L-axis) and closest to widthwise dimension reference (W-axis)
        /// </summary>
        /// <value>Corner radius furthest from lengthwise dimension reference (L-axis) and closest to widthwise dimension reference (W-axis)</value>
        [DataMember(Name="Radius2", EmitDefaultValue=false)]
        public string Radius2 { get; set; }

        /// <summary>
        /// Corner radius closest to lengthwise dimension reference (L-axis) and furthest from widthwise dimension reference (W-axis)
        /// </summary>
        /// <value>Corner radius closest to lengthwise dimension reference (L-axis) and furthest from widthwise dimension reference (W-axis)</value>
        [DataMember(Name="Radius3", EmitDefaultValue=false)]
        public string Radius3 { get; set; }

        /// <summary>
        /// Corner radius furthest from lengthwise dimension reference (L-axis) and furthest from widthwise dimension reference (W-axis)
        /// </summary>
        /// <value>Corner radius furthest from lengthwise dimension reference (L-axis) and furthest from widthwise dimension reference (W-axis)</value>
        [DataMember(Name="Radius4", EmitDefaultValue=false)]
        public string Radius4 { get; set; }

        /// <summary>
        /// Depth closest to the T-axis reference
        /// </summary>
        /// <value>Depth closest to the T-axis reference</value>
        [DataMember(Name="DepthClosestToRef", EmitDefaultValue=false)]
        public string DepthClosestToRef { get; set; }

        /// <summary>
        /// Depth furthest from the T-axis reference
        /// </summary>
        /// <value>Depth furthest from the T-axis reference</value>
        [DataMember(Name="DepthFurthestFromRef", EmitDefaultValue=false)]
        public string DepthFurthestFromRef { get; set; }

        /// <summary>
        /// ClipPockets augmentation for special fire clip insert cuts, requires special tooling, may be null/is optional
        /// </summary>
        /// <value>ClipPockets augmentation for special fire clip insert cuts, requires special tooling, may be null/is optional</value>
        [DataMember(Name="ClipPockets", EmitDefaultValue=false)]
        public ClipPockets ClipPockets { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FaceRectangle {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Radius1: ").Append(Radius1).Append("\n");
            sb.Append("  Radius2: ").Append(Radius2).Append("\n");
            sb.Append("  Radius3: ").Append(Radius3).Append("\n");
            sb.Append("  Radius4: ").Append(Radius4).Append("\n");
            sb.Append("  DepthClosestToRef: ").Append(DepthClosestToRef).Append("\n");
            sb.Append("  DepthFurthestFromRef: ").Append(DepthFurthestFromRef).Append("\n");
            sb.Append("  ClipPockets: ").Append(ClipPockets).Append("\n");
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
            return this.Equals(input as FaceRectangle);
        }

        /// <summary>
        /// Returns true if FaceRectangle instances are equal
        /// </summary>
        /// <param name="input">Instance of FaceRectangle to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FaceRectangle input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Length == input.Length ||
                    (this.Length != null &&
                    this.Length.Equals(input.Length))
                ) && base.Equals(input) && 
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
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
                ) && base.Equals(input) && 
                (
                    this.DepthClosestToRef == input.DepthClosestToRef ||
                    (this.DepthClosestToRef != null &&
                    this.DepthClosestToRef.Equals(input.DepthClosestToRef))
                ) && base.Equals(input) && 
                (
                    this.DepthFurthestFromRef == input.DepthFurthestFromRef ||
                    (this.DepthFurthestFromRef != null &&
                    this.DepthFurthestFromRef.Equals(input.DepthFurthestFromRef))
                ) && base.Equals(input) && 
                (
                    this.ClipPockets == input.ClipPockets ||
                    (this.ClipPockets != null &&
                    this.ClipPockets.Equals(input.ClipPockets))
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
                if (this.Length != null)
                    hashCode = hashCode * 59 + this.Length.GetHashCode();
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Radius1 != null)
                    hashCode = hashCode * 59 + this.Radius1.GetHashCode();
                if (this.Radius2 != null)
                    hashCode = hashCode * 59 + this.Radius2.GetHashCode();
                if (this.Radius3 != null)
                    hashCode = hashCode * 59 + this.Radius3.GetHashCode();
                if (this.Radius4 != null)
                    hashCode = hashCode * 59 + this.Radius4.GetHashCode();
                if (this.DepthClosestToRef != null)
                    hashCode = hashCode * 59 + this.DepthClosestToRef.GetHashCode();
                if (this.DepthFurthestFromRef != null)
                    hashCode = hashCode * 59 + this.DepthFurthestFromRef.GetHashCode();
                if (this.ClipPockets != null)
                    hashCode = hashCode * 59 + this.ClipPockets.GetHashCode();
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
