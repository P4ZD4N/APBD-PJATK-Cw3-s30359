using APBD_PJATK_Cw3.Enums;
using APBD_PJATK_Cw3.Requests;
using APBD_PJATK_Cw3.Responses;
using APBD_PJATK_Cw3.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationsService reservationsService) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<ReservationResponse>> GetAll(DateOnly? date, ReservationStatus? status, long? roomId)
    {
        return Ok(reservationsService.GetReservations(date, status, roomId));
    }

    [HttpGet("{id:long}")]
    public ActionResult<ReservationResponse> GetById(long id)
    {
        try
        {
            return Ok(reservationsService.GetReservation(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
    }

    [HttpPost]
    public ActionResult<ReservationResponse> AddReservation(AddReservationRequest request)
    {
        try
        {
            var newReservation = reservationsService.AddReservation(request);
            return CreatedAtAction(
                nameof(GetById),
                new { id = newReservation.Id },
                newReservation
            );
        }
        catch (ArgumentException e)
        {
            return BadRequest(new ErrorResponse(e.Message));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
    }

    [HttpPut("{id:long}")]
    public ActionResult<ReservationResponse> UpdateReservation(UpdateReservationRequest request, long id)
    {
        try
        {
            return Ok(reservationsService.UpdateReservation(request, id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
        catch (ArgumentException e)
        {
            return BadRequest(new ErrorResponse(e.Message));
        }
    }

    [HttpDelete("{id:long}")]
    public ActionResult DeleteReservation(long id)
    {
        try
        {
            reservationsService.DeleteReservation(id);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new ErrorResponse(e.Message));
        }
    }
}