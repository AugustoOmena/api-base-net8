using AutoMapper;
using WebAppBase.Domain.Entities;
using WebAppBase.Domain.Validators.Requests;

namespace WebAppBase.API.UseCases.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}