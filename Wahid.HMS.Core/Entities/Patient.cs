using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wahid.HMS.Core.Enums;

namespace Wahid.HMS.Core.Entities
{
    public class Patient : EntityBase
    {
        [Required, StringLength(20, ErrorMessage = "Max Length is 20")]
        public string Serial { get; set; }
        [Required(ErrorMessage = "Please Enter Name"), StringLength(100, ErrorMessage = "Max Length is 100")]
        public string Name { get; set; }
        public byte Age { get; set; }
        [Required(ErrorMessage = "Please Select Sex")]
        public Sex Sex { get; set; }
        [StringLength(20)]
        public string Contact { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Due { get; set; }
        public decimal Paid { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new ValidationResult[0];
        }
    }
}
