using System;
using System.Threading.Tasks;
using EssayChecker.API.Models.Foundation.Users;
using EssayChecker.API.Models.Foundation.Users.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace EssayChecker.API.Services.Foundation.Users;

public partial class UserService
{
    private delegate ValueTask<User> ReturningUserFunction();

    private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
    {
        try
        {
            return await returningUserFunction();
        }
        catch (UserNullException userNullException)
        {
            throw CreateAndLogValidationException(userNullException);
        }
        catch (InvalidUserException invalidUserException)
        {
            throw CreateAndLogValidationException(invalidUserException);
        }
        catch(SqlException sqlException)
        {
            var userStorageException = new FailedUserStorageException(sqlException);
            throw CreateAndLogCriticalDependencyException(userStorageException);
        }
    }

    private UserValidationException CreateAndLogValidationException(Xeption exception)
    {
        var userValidationException = 
            new UserValidationException(exception);

        this.loggingBroker.LogError(userValidationException);
        return userValidationException;
    }

    private UserDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
    {
        var userDependencyException = 
            new UserDependencyException(exception);
        
        this.loggingBroker.LogCritical(userDependencyException);
        return userDependencyException;
    }
}