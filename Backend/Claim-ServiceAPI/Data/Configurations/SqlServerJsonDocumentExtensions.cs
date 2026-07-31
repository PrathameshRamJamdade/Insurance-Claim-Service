using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Claim_ServiceAPI.Data.Configurations;

internal static class SqlServerJsonDocumentExtensions
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    private static readonly ValueConverter<JsonDocument?, string?> JsonDocumentConverter = new(
        jsonDocument => jsonDocument == null ? null : jsonDocument.RootElement.GetRawText(),
        jsonString => string.IsNullOrWhiteSpace(jsonString) ? null : ParseJsonDocument(jsonString));

    private static readonly ValueComparer<JsonDocument?> JsonDocumentComparer = new(
        (left, right) => Serialize(left) == Serialize(right),
        document => Serialize(document).GetHashCode(StringComparison.Ordinal),
        document => document == null ? null : ParseJsonDocument(Serialize(document)));

    public static PropertyBuilder<JsonDocument?> HasSqlServerJsonConversion(this PropertyBuilder<JsonDocument?> propertyBuilder)
    {
        var builder = propertyBuilder
            .HasConversion(JsonDocumentConverter)
            .HasColumnType("nvarchar(max)");

        builder.Metadata.SetValueComparer(JsonDocumentComparer);

        return builder;
    }

    private static string Serialize(JsonDocument? document)
    {
        return document == null
            ? string.Empty
            : JsonSerializer.Serialize(document.RootElement, SerializerOptions);
    }

    private static JsonDocument ParseJsonDocument(string json)
    {
        return JsonDocument.Parse(json, default);
    }
}