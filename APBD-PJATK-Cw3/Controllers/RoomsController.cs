using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Responses;
using APBD_PJATK_Cw3.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomsService roomsService) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<RoomResponse>> GetAll(int? minCapacity, bool? hasProjector, bool? isActive)
    {
        return Ok(roomsService.GetRooms(minCapacity, hasProjector, isActive));
    }

    [HttpGet("{id:long}")]
    public ActionResult<RoomResponse> GetById(long id)
    {
        try
        {
            return Ok(roomsService.GetRoom(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
    }
    
    [HttpGet("building/{buildingCode}")]
    public ActionResult<List<RoomResponse>> GetByBuildingCode(string buildingCode)
    {
        return Ok(roomsService.GetByBuildingCode(buildingCode));
    }

    [HttpPost]
    public ActionResult<RoomResponse> AddRoom(AddRoomRequest request)
    {
        var newRoom = roomsService.AddRoom(request);
        return CreatedAtAction(
            nameof(GetById),
            new { id = newRoom.Id },
            newRoom
        );
    }
    
    [HttpPut("{id:long}")]
    public ActionResult<RoomResponse> UpdateRoom(UpdateRoomRequest request, long id)
    {
        try
        {
            return Ok(roomsService.UpdateRoom(request, id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
    }
    
    [HttpDelete("{id:long}")]
    public ActionResult DeleteRoom(long id)
    {
        try
        {
            roomsService.DeleteRoom(id);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
        catch (InvalidOperationException e)
        {
            return Conflict(new ErrorResponse(e.Message));
        }
    }
}