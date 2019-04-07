using LandonHotel.Data;
using LandonHotel.Repositories;
using LandonHotel.Services;
using Moq;
using Xunit;

namespace LandonHotel.Tests
{
    public class BookingServiceTests
    {
        private Mock<IRoomsRepository> roomRepo;

        public BookingServiceTests()
        {
            // Before each
            roomRepo = new Mock<IRoomsRepository>();
            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room());
        }

        private BookingService Subject()
        {

            return new BookingService(roomRepo.Object);
        }

        [Fact]
        public void IsBookingValid_NonSmoking_Valid()
        {
            var service = Subject();

            var isValid = service.IsBookingValid(1, new Booking { IsSmoking = false });

            Assert.True(isValid);
        }

        [Fact]
        public void IsBookingValid_Smoking_Invalid()
        {
            var service = Subject();

            var isValid = service.IsBookingValid(1, new Booking { IsSmoking = true });

            Assert.False(isValid);
        }

        [Theory]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        public void IsBookingValid_Pets(bool areAllowed, bool hasPets, bool result)
        {
            var service = Subject();
            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room { ArePetsAllowed = areAllowed });

            var isValid = service.IsBookingValid(1, new Booking { HasPets = hasPets });

            Assert.Equal(isValid, result);
        }

        [Fact]
        public void IsBookingValid_GuestsLessThanCapacity_Valid()
        {
            var service = Subject();
            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room { Capacity = 4 });

            var isValid = service.IsBookingValid(1, new Booking { NumberOfGuests = 1 });

            Assert.True(isValid);
        }

        [Fact]
        public void IsBookingValid_GuestsGreaterThanCapactiy_Invalid()
        {
            var service = Subject();
            roomRepo.Setup(r => r.GetRoom(1)).Returns(new Room { Capacity = 2 });

            var isValid = service.IsBookingValid(1, new Booking { NumberOfGuests = 10 });

            Assert.False(isValid);
        }
    }
}
