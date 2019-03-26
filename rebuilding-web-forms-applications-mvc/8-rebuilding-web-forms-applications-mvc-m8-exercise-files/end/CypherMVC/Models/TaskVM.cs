using CypherMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherMVC.Models
{
    public class TaskVM : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DueDate(ErrorMessage = "Date must be in the future")]
        public DateTime? DueDate { get; set; }
        [Required]
        public int AssignedToId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string AssociatedMessageDisplay { get; set; }
        [Required]
        public int AssociatedMessageId { get; set; }
        [StringLength(1000, MinimumLength = 20)]
        public string Notes { get; set; }
        [Required]
        public bool Completed { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Completed && string.IsNullOrWhiteSpace(Notes))
            {
                errors.Add(new ValidationResult("Notes are required when completing a task"));
            }

            return errors;
        }
    }
}