using LandonHotel.Data;
using LandonHotel.Services;
using Xunit;

namespace LandonHotel.Tests
{
    public class BookingServiceTests
    {

        private static BookingService Subject()
        {
            return new BookingService(null);
        }

        [Fact]
        public void IsBookingValid_NonSmoking_Valid()
        {
            var service = Subject();
            var isValid = service.IsBookingValid(1, new Booking {IsSmoking = false});
            
            Assert.True(isValid);
        }

        [Fact]
        public void IsBookingValid_Smoking_Invalid()
        {
            var service = Subject();
            var isValid = service.IsBookingValid(1, new Booking {IsSmoking = true});

            Assert.False(isValid);
        }
    }
}
