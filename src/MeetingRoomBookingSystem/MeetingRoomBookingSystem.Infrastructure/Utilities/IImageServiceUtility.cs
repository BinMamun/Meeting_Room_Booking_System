using Microsoft.AspNetCore.Http;

namespace MeetingRoomBookingSystem.Infrastructure.Utilities
{
    public interface IImageServiceUtility
    {
        Task<string?> UploadImage(IFormFile? Picture);
        Task DeleteImage(string? imagePath);
    }
}
