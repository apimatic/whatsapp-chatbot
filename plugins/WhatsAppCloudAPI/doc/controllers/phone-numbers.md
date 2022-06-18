# Phone Numbers

Some API calls listed in this document require you to know your phone number’s ID. For more information on how to get a list of phone numbers associated with your WhatsApp Business Account, see [Get All Phone Numbers](https://developers.facebook.com/docs/whatsapp/business-management-api/phone-numbers#all-phone-numbers). The API call response includes IDs for each of the phone numbers connected to your WhatsApp Business Account. Save the ID for the phone you want to use with any **`/{phone-number-ID}`** calls.

```csharp
PhoneNumbersController phoneNumbersController = client.PhoneNumbersController;
```

## Class Name

`PhoneNumbersController`

## Methods

* [Get Phone Number by ID](../../doc/controllers/phone-numbers.md#get-phone-number-by-id)
* [Request Verification Code](../../doc/controllers/phone-numbers.md#request-verification-code)
* [Verify Code](../../doc/controllers/phone-numbers.md#verify-code)


# Get Phone Number by ID

When you query all the phone numbers for a WhatsApp Business Account, each phone number has an id. You can directly query for a phone number using this id.

```csharp
GetPhoneNumberByIDAsync(
    string phoneNumberID)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `phoneNumberID` | `string` | Template, Required | - |

## Response Type

[`Task<Models.GetPhoneNumberByIDResponse>`](../../doc/models/get-phone-number-by-id-response.md)

## Example Usage

```csharp
string phoneNumberID = "Phone-Number-ID6";

try
{
    GetPhoneNumberByIDResponse result = await phoneNumbersController.GetPhoneNumberByIDAsync(phoneNumberID);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "verified_name": "Jasper's Market",
  "display_phone_number": "+1 631-555-5555",
  "id": "1906385232743451",
  "quality_rating": "GREEN"
}
```


# Request Verification Code

Used to request a code to verify a phone number's ownership. You need to verify the phone number you want to use to send messages to your customers. Phone numbers must be verified through SMS/voice call. The verification process can be done through the Graph API calls specified below.

```csharp
RequestVerificationCodeAsync(
    string phoneNumberID,
    Models.RequestVerificationCodeMethodEnum codeMethod,
    string locale)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `phoneNumberID` | `string` | Template, Required | - |
| `codeMethod` | [`Models.RequestVerificationCodeMethodEnum`](../../doc/models/request-verification-code-method-enum.md) | Form, Required | Chosen method for verification. |
| `locale` | `string` | Form, Required | Your locale. For example: "en_US". |

## Response Type

[`Task<Models.SuccessResponse>`](../../doc/models/success-response.md)

## Example Usage

```csharp
string phoneNumberID = "Phone-Number-ID6";
RequestVerificationCodeMethodEnum codeMethod = RequestVerificationCodeMethodEnum.SMS;
string locale = "en_US";

try
{
    SuccessResponse result = await phoneNumbersController.RequestVerificationCodeAsync(phoneNumberID, codeMethod, locale);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "success": true
}
```


# Verify Code

Used to verify a phone number's ownership. After you have received a SMS or Voice request code for verification, you need to verify the code that was sent to you.

```csharp
VerifyCodeAsync(
    string phoneNumberID,
    string code)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `phoneNumberID` | `string` | Template, Required | - |
| `code` | `string` | Form, Required | The code you received after calling FROM_PHONE_NUMBER_ID/request_code. |

## Response Type

[`Task<Models.SuccessResponse>`](../../doc/models/success-response.md)

## Example Usage

```csharp
string phoneNumberID = "Phone-Number-ID6";
string code = "<your-requested-code>";

try
{
    SuccessResponse result = await phoneNumbersController.VerifyCodeAsync(phoneNumberID, code);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "success": true
}
```

