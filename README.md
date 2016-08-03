# Square Connect V2 C# SDK

This repository contains the released C# client SDK. Check out our [API
specification repository](https://github.com/square/connect-api-specification)
for the specification and template files we used to generate this.

## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

## Dependencies
- [RestSharp] (https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET] (https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

The DLLs included in the package may not be the latest version. We recommned using [NuGet] (https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

## Generating DLLs
Option 1: Run the following command to generate the DLL

- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Option 2: Import the `Square.Connect/Square.Connect.csproj` to your solution and build from VS

## Usage
Then include the DLLs (under the `bin` folder) in the C# project, 

- RestSharp.dll
- Newtonsoft.Json.dll
- Square.Connect.dll

And use the namespaces:
```csharp
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;
```

## Getting Started

```csharp
using System;
using System.Diagnostics;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;

namespace Example
{
    public class Example
    {
        // Retriveing your location IDs
        public static void RetriveLocations()
        {
            LocationApi _locationApi = new LocationApi();
            string authorization = "YOUR_ACCESS_TOKEN";
            var response = _locationApi.ListLocations(authorization);
        }

        // Charge the card nonce
        public static void ChargeNonce()
        {
            // Every payment you process for a given business have a unique idempotency key.
            // If you're unsure whether a particular payment succeeded, you can reattempt
            // it with the same idempotency key without worrying about double charging
            // the buyer.
            string idempotencyKey = Guid.NewGuid().ToString();

            // Monetary amounts are specified in the smallest unit of the applicable currency.
            // This amount is in cents. It's also hard-coded for $1, which is not very useful.
            int amount = 100;
            string currency = "USD";
            Money money = new Money(amount, Money.ToCurrencyEnum(currency));

            string nonce = "YOUR_NONCE";
            string authorization = "YOUR_ACCESS_TOKEN";
            string locationId = "YOUR_LOCATION_ID";
            ChargeRequest body = new ChargeRequest(AmountMoney: money, IdempotencyKey: idempotencyKey, CardNonce: nonce);
            TransactionApi transactionApi = new TransactionApi();
            var response = transactionApi.Charge(authorization, locationId, body);
        }
    }
}
```

## Documentation for API Endpoints

All URIs are relative to [Square Connect V2 Documentation](https://docs.connect.squareup.com/api/connect/v2/#navsection-endpoints)

Class | Method | HTTP request 
------------ | ------------- | ------------- 
*CustomerApi* | [**CreateCustomer**](docs/CustomerApi.md#createcustomer) | **POST** /v2/customers
*CustomerApi* | [**DeleteCustomer**](docs/CustomerApi.md#deletecustomer) | **DELETE** /v2/customers/{customer_id}
*CustomerApi* | [**ListCustomers**](docs/CustomerApi.md#listcustomers) | **GET** /v2/customers
*CustomerApi* | [**RetrieveCustomer**](docs/CustomerApi.md#retrievecustomer) | **GET** /v2/customers/{customer_id}
*CustomerApi* | [**UpdateCustomer**](docs/CustomerApi.md#updatecustomer) | **PUT** /v2/customers/{customer_id}
*CustomerCardApi* | [**CreateCustomerCard**](docs/CustomerCardApi.md#createcustomercard) | **POST** /v2/customers/{customer_id}/cards
*CustomerCardApi* | [**DeleteCustomerCard**](docs/CustomerCardApi.md#deletecustomercard) | **DELETE** /v2/customers/{customer_id}/cards/{card_id}
*LocationApi* | [**ListLocations**](docs/LocationApi.md#listlocations) | **GET** /v2/locations
*RefundApi* | [**CreateRefund**](docs/RefundApi.md#createrefund) | **POST** /v2/locations/{location_id}/transactions/{transaction_id}/refund
*RefundApi* | [**ListRefunds**](docs/RefundApi.md#listrefunds) | **GET** /v2/locations/{location_id}/refunds
*TransactionApi* | [**CaptureTransaction**](docs/TransactionApi.md#capturetransaction) | **POST** /v2/locations/{location_id}/transactions/{transaction_id}/capture
*TransactionApi* | [**Charge**](docs/TransactionApi.md#charge) | **POST** /v2/locations/{location_id}/transactions
*TransactionApi* | [**ListTransactions**](docs/TransactionApi.md#listtransactions) | **GET** /v2/locations/{location_id}/transactions
*TransactionApi* | [**RetrieveTransaction**](docs/TransactionApi.md#retrievetransaction) | **GET** /v2/locations/{location_id}/transactions/{transaction_id}
*TransactionApi* | [**VoidTransaction**](docs/TransactionApi.md#voidtransaction) | **POST** /v2/locations/{location_id}/transactions/{transaction_id}/void


## Documentation for Models

 - [Model.Address](docs/Address.md)
 - [Model.CaptureTransactionResponse](docs/CaptureTransactionResponse.md)
 - [Model.Card](docs/Card.md)
 - [Model.ChargeRequest](docs/ChargeRequest.md)
 - [Model.ChargeResponse](docs/ChargeResponse.md)
 - [Model.CreateCustomerCardRequest](docs/CreateCustomerCardRequest.md)
 - [Model.CreateCustomerCardResponse](docs/CreateCustomerCardResponse.md)
 - [Model.CreateCustomerRequest](docs/CreateCustomerRequest.md)
 - [Model.CreateCustomerResponse](docs/CreateCustomerResponse.md)
 - [Model.CreateRefundRequest](docs/CreateRefundRequest.md)
 - [Model.CreateRefundResponse](docs/CreateRefundResponse.md)
 - [Model.Customer](docs/Customer.md)
 - [Model.DeleteCustomerCardResponse](docs/DeleteCustomerCardResponse.md)
 - [Model.DeleteCustomerResponse](docs/DeleteCustomerResponse.md)
 - [Model.Error](docs/Error.md)
 - [Model.ListCustomersRequest](docs/ListCustomersRequest.md)
 - [Model.ListCustomersResponse](docs/ListCustomersResponse.md)
 - [Model.ListLocationsResponse](docs/ListLocationsResponse.md)
 - [Model.ListRefundsRequest](docs/ListRefundsRequest.md)
 - [Model.ListRefundsResponse](docs/ListRefundsResponse.md)
 - [Model.ListTransactionsRequest](docs/ListTransactionsRequest.md)
 - [Model.ListTransactionsResponse](docs/ListTransactionsResponse.md)
 - [Model.Location](docs/Location.md)
 - [Model.Money](docs/Money.md)
 - [Model.Refund](docs/Refund.md)
 - [Model.RetrieveCustomerResponse](docs/RetrieveCustomerResponse.md)
 - [Model.RetrieveTransactionResponse](docs/RetrieveTransactionResponse.md)
 - [Model.Tender](docs/Tender.md)
 - [Model.TenderCardDetails](docs/TenderCardDetails.md)
 - [Model.TenderCashDetails](docs/TenderCashDetails.md)
 - [Model.Transaction](docs/Transaction.md)
 - [Model.UpdateCustomerRequest](docs/UpdateCustomerRequest.md)
 - [Model.UpdateCustomerResponse](docs/UpdateCustomerResponse.md)
 - [Model.VoidTransactionResponse](docs/VoidTransactionResponse.md)


## Contributing

Send bug reports, feature requests, and code contributions to the [API
specifications repository](https://github.com/square/connect-api-specification),
as this repository contains only the generated SDK code.

## License

```
Copyright 2016 Square, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
