using AirBNB.Application.Hotels.Commands.CreateHotel;
using AirBNB.Application.Hotels.Commands.UpdateHotel;
using AirBNB.Application.Hotels.Common;
using AirBNB.Contracts.Hotels;
using Mapster;

namespace AirBNB.Api.Common.Mapping;

public class HotelMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<HotelResult, HotelResponse>()
            .Map(dest => dest, src => src.Hotel);

        config.NewConfig<(CreateHotelRequest Request, string UserId), CreateHotelCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(UpdateHotelRequest Request, string Id), UpdateHotelCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);
    }
}