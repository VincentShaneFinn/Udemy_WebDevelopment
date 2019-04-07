using LandonHotel.Data;
using LandonHotel.Repositories;

namespace LandonHotel.Services
{
    public class BookingService : IBookingService
    {
        public decimal CalculateBookingPrice(Booking booking)
        {
            var roomRepo = new RoomsRepository();
            var room = roomRepo.GetRoom(booking.RoomId);

            var numberOfNights = (booking.CheckOutDate - booking.CheckInDate).Days;
            return room.Rate * numberOfNights;
        }
    }
}
