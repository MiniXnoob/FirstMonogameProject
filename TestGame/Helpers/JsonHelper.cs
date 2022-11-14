using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestGame.Helpers;

/// <summary>
/// A helper class to facilitate JSON operations with a standardized set of options
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// Gets a standardized set of options
    /// </summary>
    /// <param name="writeIndented"></param>
    /// <returns></returns>
    public static JsonSerializerOptions GetJsonSerializerOptions(bool writeIndented = true)
    {
        var jsonSerializationOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = writeIndented
        };

        // DO NOT CHANGE SEQUENCE ARBITRARILY
        //jsonSerializationOptions.Converters.Add(new LanguageJsonConverter());
        jsonSerializationOptions.Converters.Add(new JsonStringEnumConverter());

        return jsonSerializationOptions;
    }

    /// <summary>
    /// Serializes object to JSON using standardized options and invariant culture
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="writeIndented"></param>
    /// <returns></returns>
    public static string Serialize<T>(T source, bool writeIndented = true)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        return JsonSerializer.Serialize(source, GetJsonSerializerOptions(writeIndented));
    }

    /// <summary>
    /// Deserializes object from JSON using standardized options and invariant culture
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T? Deserialize<T>(string source)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        return JsonSerializer.Deserialize<T>(source, GetJsonSerializerOptions());
    }
}