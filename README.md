# Betsolutions Casino API SDK for .NET

Betsolutions’s Casino API SDK for .NET provides developer tools for accessing Casino API. 
For Betsolutions’s Casino API documentation, please see: https://docs.betsolutions.com/

## Requirements

.NET Standard 2.0

# Installation
### Installation via Nuget
```bash
Install-Package Betsolutions.Casino.SDK -Version 1.0.4
```

### Installation via .Net CLI
```bash
dotnet add package Betsolutions.Casino.SDK --version 1.0.4
```

## Dependencies

- Newtonsoft.Json (>= 12.0.2)
- RestSharp (>= 106.6.9)

## Example
Example of 'getPlayerBalance' request. SDK calculates hash and appends merchantId and hash in the request.
```c#
var walletService = new WalletService(_merchantAuthInfo);

try
{
    var response = walletService.GetBalance(new GetBalanceRequest
    {
        Currency = "TRY",
        UserId = "718850",
        Token = "[private token]"
    });

    if (response.StatusCode == StatusCodes.Success)
    {
        var result = response.Data;

        Console.WriteLine($"{nameof(result.Balance)}: {result.Balance}");
    }
}
catch (CantConnectToServerException ex)
{
    Console.WriteLine(ex);
}

```
