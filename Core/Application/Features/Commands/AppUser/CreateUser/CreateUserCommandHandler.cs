using Application.Abstractions.Services;
using Application.DTOs.UserDtos;
using MediatR;

namespace Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var res = await _userService.CreateAsync(new CreateUserDto
        {
            //Mail ya da şifreden ikisinden birini iki farklı kullanıcdan eklemek istersen hata veriyor HASSAS AYARLARA DİKKAT
            TC = request.TC,
            Username = request.Username,
            CreditCardBalance = request.CreditCardBalance,
            CarPlate = request.CarPlate,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Password = request.Password
        });
        return new CreateUserCommandResponse
        {
            IsSuccess = res.IsSuccess
        };
    }
}