namespace Claim_ServiceAPI.Enums;

public enum ClaimDocumentStorageProvider
{
    Local = 1,
    AmazonS3 = 2,
    AzureBlob = 3,
    GoogleCloudStorage = 4,
    Other = 99
}