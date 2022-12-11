using AirBNB.Application.Rooms.Commands.CreateRoom;
using AirBNB.Application.Rooms.Commands.UpdateRoom;
using AirBNB.Application.Rooms.Common;
using AirBNB.Contracts.Rooms;
using Mapster;

namespace AirBNB.Api.Common.Mapping;

public class RoomMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RoomResult, RoomResponse>()
            .Map(dest => dest, src => src.Room);

        config.NewConfig<(CreateRoomRequest Request, string HotelId), CreateRoomCommand>()
            .Map(dest => dest.HotelId, src => src.HotelId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(UpdateRoomRequest Request, string Id), UpdateRoomCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);
    }
}