using AirBNB.Application.Authentication.Common;
using AirBNB.Contracts.Authentication;
using Mapster;

namespace AirBNB.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);


    }
}