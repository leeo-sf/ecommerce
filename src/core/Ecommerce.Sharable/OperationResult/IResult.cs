﻿namespace Ecommerce.Sharable.OperationResult;

internal interface IResult<TSelf>
    where TSelf : IResult<TSelf>?
{
    Exception? Exception { get; }
    bool IsSuccess { get; }

    static abstract TSelf Success();
    static abstract TSelf Error(Exception error);
}
