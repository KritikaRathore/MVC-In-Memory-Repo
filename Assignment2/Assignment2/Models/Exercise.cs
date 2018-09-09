using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Exercise
    {

        [Required]
        public string ExerciseName { get; set; }
        
        [Required]
        public DateTime ExerciseDate { get; set; }

        [Required]
        public int DurationInMinutes { get; set; }
    }
}