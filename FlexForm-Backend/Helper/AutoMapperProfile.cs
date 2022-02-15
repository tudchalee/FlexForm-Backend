namespace FlexForm_Backend.Helper;

using AutoMapper;
using FlexForm_Backend.Models;
using FlexForm_Backend.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterRequest, User>();
    }
}