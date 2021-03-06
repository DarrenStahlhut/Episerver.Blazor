﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ContentDeliveryAPI.Library.Models;
//
//    var searchResults = SearchResults.FromJson(jsonString);

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common.Library.Models
{
    public partial class SearchResults
    {
        [JsonProperty("totalMatching")]
        public long TotalMatching { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("contentLink")]
        public ContentLink ContentLink { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("existingLanguages")]
        public List<Language> ExistingLanguages { get; set; }

        [JsonProperty("masterLanguage")]
        public Language MasterLanguage { get; set; }

        [JsonProperty("contentType")]
        public List<string> ContentType { get; set; }

        [JsonProperty("parentLink")]
        public ContentLink ParentLink { get; set; }

        [JsonProperty("routeSegment")]
        public string RouteSegment { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("changed")]
        public DateTimeOffset Changed { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("startPublish")]
        public DateTimeOffset StartPublish { get; set; }

        [JsonProperty("stopPublish")]
        public object StopPublish { get; set; }

        [JsonProperty("saved")]
        public DateTimeOffset Saved { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("mainContentArea", NullValueHandling = NullValueHandling.Ignore)]
        public MainContentArea MainContentArea { get; set; }

        [JsonProperty("hideSiteFooter")]
        public DisableIndexing HideSiteFooter { get; set; }

        [JsonProperty("hideSiteHeader")]
        public DisableIndexing HideSiteHeader { get; set; }

        [JsonProperty("metaDescription")]
        public Email MetaDescription { get; set; }

        [JsonProperty("metaTitle")]
        public Email MetaTitle { get; set; }

        [JsonProperty("teaserText")]
        public Email TeaserText { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("disableIndexing")]
        public DisableIndexing DisableIndexing { get; set; }

        [JsonProperty("mainBody", NullValueHandling = NullValueHandling.Ignore)]
        public Email MainBody { get; set; }

        [JsonProperty("pageImage")]
        public Image PageImage { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public Email Phone { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image Image { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public Email Email { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("value")]
        public List<CategoryValue> Value { get; set; }

        [JsonProperty("propertyDataType")]
        public string PropertyDataType { get; set; }
    }

    public partial class CategoryValue
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ContentLink
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("workId")]
        public long WorkId { get; set; }

        [JsonProperty("guidValue")]
        public Guid GuidValue { get; set; }

        [JsonProperty("providerName")]
        public object ProviderName { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class DisableIndexing
    {
        [JsonProperty("value")]
        public bool? Value { get; set; }

        [JsonProperty("propertyDataType")]
        public DisableIndexingPropertyDataType PropertyDataType { get; set; }
    }

    public partial class Email
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("propertyDataType")]
        public EmailPropertyDataType PropertyDataType { get; set; }
    }

    public partial class Language
    {
        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("displayName")]
        public DisplayName DisplayName { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("value")]
        public ContentLink Value { get; set; }

        [JsonProperty("propertyDataType")]
        public string PropertyDataType { get; set; }
    }

    public partial class MainContentArea
    {
        [JsonProperty("value")]
        public List<MainContentAreaValue> Value { get; set; }

        [JsonProperty("propertyDataType")]
        public string PropertyDataType { get; set; }
    }

    public partial class MainContentAreaValue
    {
        [JsonProperty("tag")]
        public object Tag { get; set; }

        [JsonProperty("displayOption")]
        public string DisplayOption { get; set; }

        [JsonProperty("contentLink")]
        public ContentLink ContentLink { get; set; }
    }

    public enum DisableIndexingPropertyDataType { PropertyBoolean };

    public enum EmailPropertyDataType { PropertyLongString, PropertyXhtmlString };

    public enum DisplayName { English };

    public enum Name { En };

    public partial class SearchResults
    {
        public static SearchResults FromJson(string json) => JsonConvert.DeserializeObject<SearchResults>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SearchResults self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DisableIndexingPropertyDataTypeConverter.Singleton,
                EmailPropertyDataTypeConverter.Singleton,
                DisplayNameConverter.Singleton,
                NameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DisableIndexingPropertyDataTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DisableIndexingPropertyDataType) || t == typeof(DisableIndexingPropertyDataType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "PropertyBoolean")
            {
                return DisableIndexingPropertyDataType.PropertyBoolean;
            }
            throw new Exception("Cannot unmarshal type DisableIndexingPropertyDataType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DisableIndexingPropertyDataType)untypedValue;
            if (value == DisableIndexingPropertyDataType.PropertyBoolean)
            {
                serializer.Serialize(writer, "PropertyBoolean");
                return;
            }
            throw new Exception("Cannot marshal type DisableIndexingPropertyDataType");
        }

        public static readonly DisableIndexingPropertyDataTypeConverter Singleton = new DisableIndexingPropertyDataTypeConverter();
    }

    internal class EmailPropertyDataTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EmailPropertyDataType) || t == typeof(EmailPropertyDataType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "PropertyLongString":
                    return EmailPropertyDataType.PropertyLongString;
                case "PropertyXhtmlString":
                    return EmailPropertyDataType.PropertyXhtmlString;
            }
            throw new Exception("Cannot unmarshal type EmailPropertyDataType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EmailPropertyDataType)untypedValue;
            switch (value)
            {
                case EmailPropertyDataType.PropertyLongString:
                    serializer.Serialize(writer, "PropertyLongString");
                    return;
                case EmailPropertyDataType.PropertyXhtmlString:
                    serializer.Serialize(writer, "PropertyXhtmlString");
                    return;
            }
            throw new Exception("Cannot marshal type EmailPropertyDataType");
        }

        public static readonly EmailPropertyDataTypeConverter Singleton = new EmailPropertyDataTypeConverter();
    }

    internal class DisplayNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DisplayName) || t == typeof(DisplayName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "English")
            {
                return DisplayName.English;
            }
            //throw new Exception("Cannot unmarshal type DisplayName");
            return null;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DisplayName)untypedValue;
            if (value == DisplayName.English)
            {
                serializer.Serialize(writer, "English");
                return;
            }
            throw new Exception("Cannot marshal type DisplayName");
        }

        public static readonly DisplayNameConverter Singleton = new DisplayNameConverter();
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "en")
            {
                return Name.En;
            }
            //throw new Exception("Cannot unmarshal type Name");
            return null;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            if (value == Name.En)
            {
                serializer.Serialize(writer, "en");
                return;
            }
            throw new Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }
}
