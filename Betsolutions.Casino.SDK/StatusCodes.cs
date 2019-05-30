namespace Betsolutions.Casino.SDK
{
    public enum StatusCodes
    {
        Success = 200,
        AlreadyProcessedTransaction = 201,
        InactiveToken = 401,
        InsufficientBalance = 402,
        InvalidHash = 403,
        InvalidToken = 404,
        TransferLimit = 405,
        UserNotFound = 406,
        InvalidAmount = 407,
        DuplicatedTransactionId = 408,
        SessionExpired = 409,
        InvalidCurrency = 410,
        GeneralError = 500,
    }
}
