using MeetingRoomBookingSystem.Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeetingRoomController(
        ILogger<MeetingRoomController> logger,
        IMeetingRoomManagementService meetingRoomService
        ) : Controller

    {
        private readonly ILogger<MeetingRoomController> _logger = logger;
        private readonly IMeetingRoomManagementService _meetingRoomService = meetingRoomService;

        public IActionResult Index()
        {
            return View();
        }
    }
}
