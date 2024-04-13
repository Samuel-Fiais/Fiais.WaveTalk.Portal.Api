using System.Reflection;
using Fiais.WaveTalk.Portal.Application.Constants;

namespace Fiais.WaveTalk.Portal.Application.Exceptions;

public class ApplicationException : Exception
{
    protected ApplicationException(string message) : base(message)
    {
    }
}

public class ApplicationNoContentException() : ApplicationException(ExceptionMessages.NoContent);

public class ApplicationNotFoundException : ApplicationException
{
    public ApplicationNotFoundException(MemberInfo type) : base($"{ExceptionMessages.NotFound} ({type.Name})".Trim())
    {
    }

    public ApplicationNotFoundException(string? entity = null) : base(
        $"{ExceptionMessages.NotFound} {(!string.IsNullOrEmpty(entity) ? "(" + entity + ")" : string.Empty)}".Trim())
    {
    }
}

public class ApplicationUnauthorizedException() : ApplicationException(ExceptionMessages.Unauthorized);

public class ApplicationTokenInvalidException() : ApplicationException(ExceptionMessages.TokenInvalid);

public class ApplicationTokenExpiredException() : ApplicationException(ExceptionMessages.TokenExpired);

public class ApplicationInternalServerErrorException() : ApplicationException(ExceptionMessages.InternalServerError);

public class ApplicationUserDisabledException() : ApplicationException(ExceptionMessages.UserDisabled);

public class ApplicationNotificationException(ICollection<string?> notifications)
    : ApplicationException(string.Join(" - ", notifications));

public class ApplicationDontCreateException(string? entity = null) : ApplicationException(
    $"{ExceptionMessages.DontCreate} {(!string.IsNullOrEmpty(entity) ? "(" + entity + ")" : string.Empty)}".Trim());

public class ApplicationDontUpdateException(string? entity = null) : ApplicationException(
    $"{ExceptionMessages.DontUpdate} {(!string.IsNullOrEmpty(entity) ? "(" + entity + ")" : string.Empty)}".Trim());

public class ApplicationUserNotFoundException(string? property = null) : ApplicationException(
    $"{ExceptionMessages.UserNotFound} {(!string.IsNullOrEmpty(property) ? "(" + property + ")" : string.Empty)}".Trim());

public class ApplicationAlreadyExistsException(string? property = null) : ApplicationException(
    $"{ExceptionMessages.AlreadyExists} {(!string.IsNullOrEmpty(property) ? "(" + property + ")" : string.Empty)}"
        .Trim());
        
public class ApplicationUserDontVinculateWithChatRoomException() : ApplicationException(
    ExceptionMessages.UserDontVinculateWithChatRoom);