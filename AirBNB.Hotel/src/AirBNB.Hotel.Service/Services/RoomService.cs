using AirBNB.Hotels.Service.Dtos;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Interfaces;

namespace AirBNB.Hotels.Service.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookDateRepository _bookDateRepository;

        public RoomService(IRoomRepository roomRepository, IBookDateRepository bookDateRepository)
        {
            _bookDateRepository = bookDateRepository;
        }

        public async Task<List<Room>> Load(int hotelId)
        {
            return await _roomRepository.Load(hotelId);
        }

        public async Task<Room> Fetch(int id)
        {
            return await _roomRepository.Fetch(id);
        }

        public async Task<Room> Create(int adminId, CreateRoomDto createRoomDto)
        {
            var room = new Room(createRoomDto.Name, createRoomDto.Image, createRoomDto.HotelId, adminId);

            await this._roomRepository.Create(room);

            return room;
        }

        public async Task Delete(int adminId, int id)
        {
            var room = await _roomRepository.Fetch(id);
            if (room == null || room.UserId == adminId) return;

            _roomRepository.Delete(room);
            await _roomRepository.Save();
        }

        public async Task<Room> Update(int adminId, int id, UpdateRoomDto updateRoomDto)
        {
            var room = await _roomRepository.Fetch(id);
            if (room == null || room.UserId == adminId) return null;

            if (updateRoomDto.Name != null) room.Name = updateRoomDto.Name;
            if (updateRoomDto.Image != null) room.Image = updateRoomDto.Image;

            await _roomRepository.Save();
            return room;
        }

        public async Task<List<BookDate>> getRoomBookDates(int id)
        {
            return await _bookDateRepository.Load(id);
        }

        public async Task<BookDate> BookRoom(int id, CreateBookDto createBookDto)
        {
            var date = new BookDate(createBookDto.StartDate, createBookDto.EndDate, id);

            await this._bookDateRepository.Create(date);

            return date;
        }

        public async Task UnbookRoom(int dateId)
        {
            var date = await _bookDateRepository.Fetch(dateId);
            if (date == null) return;

            _bookDateRepository.Delete(date);
            await _bookDateRepository.Save();
        }
    }
}
