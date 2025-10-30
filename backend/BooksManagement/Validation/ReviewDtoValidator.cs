using BooksManagement.DTOs;
using FluentValidation;

namespace BooksManagement.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.BookId)
                .GreaterThan(0).WithMessage("BookId must be a valid positive number.");

            RuleFor(r => r.ReviewerName)
                .NotEmpty().WithMessage("Reviewer name is required.")
                .MaximumLength(100).WithMessage("Reviewer name cannot exceed 100 characters.");

            RuleFor(r => r.Comment)
                .NotEmpty().WithMessage("Comment cannot be empty.")
                .MaximumLength(255).WithMessage("Comment cannot exceed 255 characters.");

            RuleFor(r => r.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be between 1 and 5.");
        }
    }
}
