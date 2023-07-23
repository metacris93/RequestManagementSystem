using Services.Common.Dto;
using User.API.Dtos;

namespace User.API.Service.IService;

public interface IAuthService
{
    Task<ApiResponse<UserDto>> Register(RegistrationRequestDto registrationRequestDto);
    Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto);
    Task<ApiResponse<string>> AssignRole(AssignRoleRequestDto assignRoleRequestDto);
}
