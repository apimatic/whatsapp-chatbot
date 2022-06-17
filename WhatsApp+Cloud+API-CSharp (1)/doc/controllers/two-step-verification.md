# Two-Step Verification

You are required to set up two-step verification for your phone number, as this provides an extra layer of security to the business accounts. To set it up, make a **POST** call to **`/{{Phone-Number-ID}}`** and attach the following parameters. There is no endpoint to disable two-step verification.

<h5>Reminders</h5>
* To use these endpoints, you need to authenticate yourself with a system user access token with the **`whatsapp_business_messaging`** permission.
* If you need to find your phone number ID, see [Get Phone Number ID](#c72d9c17-554d-4ae1-8f9e-b28a94010b28).

```csharp
TwoStepVerificationController twoStepVerificationController = client.TwoStepVerificationController;
```

## Class Name

`TwoStepVerificationController`


# Set Two Step Verification Code

You are required to set up two-step verification for your phone number, as this provides an extra layer of security to the business accounts. You can use this endpoint to change two-step verification code associated with your account.
After you change the verification code, future requests like changing the name, must use the new code.

You set up two-factor verification and register a phone number in the same API call.

```csharp
SetTwoStepVerificationCodeAsync(
    string phoneNumberID,
    Models.SetTwoStepVerificationCodeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `phoneNumberID` | `string` | Template, Required | - |
| `body` | [`Models.SetTwoStepVerificationCodeRequest`](../../doc/models/set-two-step-verification-code-request.md) | Body, Required | - |

## Response Type

[`Task<Models.SuccessResponse>`](../../doc/models/success-response.md)

## Example Usage

```csharp
string phoneNumberID = "Phone-Number-ID6";
var body = new SetTwoStepVerificationCodeRequest();
body.Pin = "<6-digit-pin>";

try
{
    SuccessResponse result = await twoStepVerificationController.SetTwoStepVerificationCodeAsync(phoneNumberID, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "success": true
}
```

