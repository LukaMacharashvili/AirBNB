using AirBNB.Hotels.Service.Dtos;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Interfaces;

namespace AirBNB.Hotels.Service.Services
{
    public class HotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> Load(int adminId)
        {
            return await _hotelRepository.Load(adminId);
        }

        public async Task<Hotel> Fetch(int id)
        {
            return await _hotelRepository.Fetch(id);
        }

        public async Task<Hotel> Create(int adminId, CreateHotelDto createHotelDto)
        {
            var hotel = new Hotel(createHotelDto.Name, createHotelDto.Image, adminId);

            await this._hotelRepository.Create(hotel);

            return hotel;
        }

        public async Task Delete(int adminId, int id)
        {
            var hotel = await _hotelRepository.Fetch(id);
            if (hotel == null || hotel.UserId == adminId) return;

            _hotelRepository.Delete(hotel);
            await _hotelRepository.Save();
        }

        public async Task<Hotel> Update(int adminId, int id, UpdateHotelDto updateHotelDto)
        {
            var hotel = await _hotelRepository.Fetch(id);
            if (hotel == null || hotel.UserId == adminId) return null;

            if (updateHotelDto.Name != null) hotel.Name = updateHotelDto.Name;
            if (updateHotelDto.Image != null) hotel.Image = updateHotelDto.Image;

            await _hotelRepository.Save();
            return hotel;
        }
    }
}
