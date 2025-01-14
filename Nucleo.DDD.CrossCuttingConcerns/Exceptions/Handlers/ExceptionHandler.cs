﻿using Nucleo.DDD.CrossCuttingConcerns.Exceptions.Types;
using ValidationException = Nucleo.DDD.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Nucleo.DDD.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException => HandleException(validationException),
            _ => HandleException(exception)
        };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(Exception exception);

}