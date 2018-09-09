using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class ExerciseViewModel
    {

        [Required(ErrorMessage = "Please enter exercise name.")]
        [MaxLength(100, ErrorMessage = "Please enter less than 100 characters.")]
        public string ExerciseName { get; set; }

        //[DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter exercise date name.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExerciseDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter duration in minutes.")]
        [Range(1, 120)]
        public int DurationInMinutes { get; set; }
    }
}