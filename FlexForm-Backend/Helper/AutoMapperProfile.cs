namespace FlexForm_Backend.Helper;

using AutoMapper;
using FlexForm_Backend.Entities;
using FlexForm_Backend.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> AuthenticateResponse
        CreateMap<Users, AuthenticateResponse>();

        // RegisterRequest -> User
        CreateMap<RegisterRequest, Users>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, Users>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
        
                    return true;
                }
            ));
    }
}