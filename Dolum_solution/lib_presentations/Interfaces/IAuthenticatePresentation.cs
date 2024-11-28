using lib_entities;

namespace lib_presentations.Interfaces;

public interface IAuthenticatePresentation
{
    Task<string> Authenticate(string Email, string Password);
}