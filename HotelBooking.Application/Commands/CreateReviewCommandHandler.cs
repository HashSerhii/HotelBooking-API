using HotelBooking.Application.Mediator.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Application.Commands;

public class CreateReviewCommandHandler : ICommandHandler<CreateReviewCommand, int>
{
    private readonly IGenericRepository<Review> _reviewRepository;
    private readonly IGenericRepository<Hotel> _hotelRepository;

    public CreateReviewCommandHandler(
        IGenericRepository<Review> reviewRepository,
        IGenericRepository<Hotel> hotelRepository)
    {
        _reviewRepository = reviewRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<int> ExecuteAsync(CreateReviewCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByIdAsync(command.HotelId);
            if (hotel == null)
                throw new Exception("Hotel not found");

            var review = new Review
            {
                HotelId = command.HotelId,
                UserId = command.UserId!,
                Rating = command.Rating,
                Comment = command.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await _reviewRepository.AddAsync(review);

            return review.Id;
    }
}
    