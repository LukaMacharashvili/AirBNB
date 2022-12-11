using AirBNB.Application.BookDates.Commands.BookRoom;
using AirBNB.Application.BookDates.Common;
using AirBNB.Contracts.BookDates;
using Mapster;

namespace AirBNB.Api.Common.Mapping;

public class BookDateMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BookDateResult, BookDateResponse>()
            .Map(dest => dest, src => src.BookDate);

        config.NewConfig<(BookRoomRequest Request, string RoomId), BookRoomCommand>()
            .Map(dest => dest.RoomId, src => src.RoomId)
            .Map(dest => dest, src => src.Request);
    }
}