namespace AirBNB.Hotels.Service.Entities
{
    public class BookDate
    {
        public BookDate() { }
        public BookDate(DateTime startDate, DateTime endDate, int roomId)
        {
            StartDate = startDate;
            EndDate = endDate;

            RoomId = roomId;
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}