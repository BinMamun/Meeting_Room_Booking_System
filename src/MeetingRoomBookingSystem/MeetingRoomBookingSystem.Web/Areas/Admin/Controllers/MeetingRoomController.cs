using AutoMapper;
using MeetingRoomBookingSystem.Domain.Entities;
using MeetingRoomBookingSystem.Domain.ServiceContracts;
using MeetingRoomBookingSystem.Infrastructure.Entensions;
using MeetingRoomBookingSystem.Infrastructure.Utilities;
using MeetingRoomBookingSystem.Web.Areas.Admin.Models;
using MeetingRoomBookingSystem.Web.Areas.Admin.Models.MeetingRoomModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeetingRoomController(
        ILogger<MeetingRoomController> logger,
        IMeetingRoomManagementService meetingRoomService,
        IMapper mapper,
        IImageServiceUtility imageServiceUtility
        ) : Controller

    {
        private readonly ILogger<MeetingRoomController> _logger = logger;
        private readonly IMeetingRoomManagementService _meetingRoomService = meetingRoomService;
        private readonly IMapper _mapper = mapper;
        private readonly IImageServiceUtility _imageServiceUtility = imageServiceUtility;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new MeetingRoomCreateModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MeetingRoomCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var meetingRoom = _mapper.Map<MeetingRoom>(model);
                meetingRoom.Id = Guid.NewGuid();
                meetingRoom.Image = await _imageServiceUtility.UploadImage(model.Image);

                try
                {
                    await _meetingRoomService.CreateMeetingRoomAsync(meetingRoom);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Data created successfully",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Data creation failed",
                        Type = ResponseTypes.Danger
                    });
                    return RedirectToAction("Create");
                }
            }
            else
            {
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Form submission is not valid",
                    Type = ResponseTypes.Danger
                });

                return View(model);
            }
        }
    }
}
