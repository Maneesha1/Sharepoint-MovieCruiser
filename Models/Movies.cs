using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCrusier.Models
{
    public partial class Movies
    {
        
        public int MovieId { get; set; }
        [Required(ErrorMessage = "please enter movie ")]
        [StringLength(maximumLength:65,MinimumLength =2,ErrorMessage ="Name should between 2 to 65 characters")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "please enter BoxOffice")]
        [MaxLength(12)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "BoxOffice must be numeric")]
        public string BoxOffice { get; set; }
        [Required(ErrorMessage = "Select yes or NO")]
        public string Active { get; set; }
        [Required(ErrorMessage = "please select Genre")]
        public string Genre { get; set; }
        public string HasTeaser { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        public DateTime DateOfLaunch { get; set; }
    }
}
