using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRoomsRepository _roomRepo;

        public BookingService(IRoomsRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public decimal CalculateBookingPrice(Booking booking)
        {
            var room = _roomRepo.GetRoom(booking.RoomId);

            var numberOfNights = (booking.CheckOutDate - booking.CheckInDate).Days;
            return room.Rate * numberOfNights;
        }
    }
}
