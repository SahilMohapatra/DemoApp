using AutoMapper;
using BooksManagement.DTOs;
using BooksManagement.Models;
using BooksManagement.Validators;
using FluentValidation;
using FluentValidation.Results;
using HotChocolate;

namespace BooksManagement.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)] 
    public class ReviewMutation
    {
        private readonly IValidator<ReviewDto> _validator;
        private readonly IMapper _mapper;

        public ReviewMutation(IValidator<ReviewDto> validator, IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public ReviewDto AddReview(ReviewDto input, [Service] HealthContext context)
        {
            ValidateInput(input);

            var bookExists = context.Books.Any(b => b.Id == input.BookId);
            if (!bookExists)
                throw new GraphQLException($"Book with ID {input.BookId} not found.");

            var review = _mapper.Map<Review>(input);
            context.Reviews.Add(review);
            context.SaveChanges();

            return _mapper.Map<ReviewDto>(review);
        }

        public ReviewDto UpdateReview(int id, ReviewDto input, [Service] HealthContext context)
        {
            ValidateInput(input);

            var existing = context.Reviews.FirstOrDefault(r => r.Id == id);
            if (existing == null)
                throw new GraphQLException($"Review with ID {id} not found.");

            _mapper.Map(input, existing);
            context.SaveChanges();

            return _mapper.Map<ReviewDto>(existing);
        }

        public bool DeleteReview(int id, [Service] HealthContext context)
        {
            var review = context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
                throw new GraphQLException($"Review with ID {id} not found.");

            context.Reviews.Remove(review);
            context.SaveChanges();
            return true;
        }

        private void ValidateInput(ReviewDto input)
        {
            ValidationResult result = _validator.Validate(input);
            if (!result.IsValid)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new GraphQLException($"Validation failed: {errors}");
            }
        }
    }
}
