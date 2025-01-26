using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MeetingRoomBookingSystem.Infrastructure.Entensions
{
    public static class TempDataExtension
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }

        public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object? o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
        }

        public static T? Peek<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object? o = tempData.Peek(key);
            return o == null ? null : JsonSerializer.Deserialize<T>((string)o);
        }
    }
}
