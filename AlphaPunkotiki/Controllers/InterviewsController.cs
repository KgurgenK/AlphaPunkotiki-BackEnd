using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using AlphaPunkotiki.WebApi.Models.InterviewsController;
using Microsoft.AspNetCore.Mvc;

namespace AlphaPunkotiki.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewsController(IInterviewsService interviewsService) : ControllerBase
{
    [HttpGet("interviews/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetInterviewResponse>> GetInterviewById([FromRoute] Guid id)
    {
        var interview = await interviewsService.GetInterviewAsync(id);

        return interview is null ? NotFound() : Ok(new GetInterviewResponse(interview));
    }

    [HttpGet("interviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewsResponse>> GetAvailableInterviews()
        => Ok(new GetInterviewsResponse(await interviewsService.GetAllAvailableInterviewsAsync()));

    [HttpGet("user-interviews/{creatorId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewsResponse>> GetUserInterviews([FromRoute] Guid creatorId)
        => Ok(new GetInterviewsResponse(await interviewsService.GetUserInterviewsAsync(creatorId)));

    [HttpGet("candidate-interview-requests/{candidateId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewRequestsResponse>> GetCandidateInterviewRequests(
        [FromRoute] Guid candidateId)
        => Ok(new GetInterviewRequestsResponse(
            await interviewsService.GetCandidateInterviewRequestsAsync(candidateId)));

    [HttpGet("interviewer-interview-requests/{interviewerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewRequestsResponse>> GetInterviewerInterviewRequests(
        [FromRoute] Guid interviewerId)
        => Ok(new GetInterviewRequestsResponse(await interviewsService.GetInterviewerInterviewRequestsAsync(interviewerId)));

    [HttpGet("interview-interview-requests/{interviewId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewRequestsResponse>> GetInterviewRequestsOfInterview(
        [FromRoute] Guid interviewId)
        => Ok(new GetInterviewRequestsResponse(await interviewsService.GetInterviewRequestsByInterviewAsync(interviewId)));

    [HttpPost("create-interview")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateInterview([FromBody] CreateInterviewRequest request)
    {
        await interviewsService.CreateInterviewAsync(request.InterviewInfo);

        return Created();
    }

    [HttpPost("create-interview-request")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> CreateInterviewRequest([FromBody] CreateInterviewRequestRequest request)
    {
        var success = await interviewsService.CreateInterviewRequestAsync(request.UserId, request.InterviewId);

        return success ? Created() : Forbid();
    }

    [HttpPost("approve-interview-request/{interviewRequestId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> ApproveInterviewRequest(
        [FromRoute] Guid interviewRequestId, [FromBody] ChangeInterviewRequestStatusRequest request)
    {
        var success = await interviewsService.ChangeInterviewRequestStatusAsync(interviewRequestId,
            InterviewRequestStatus.Approved, request.Message);

        return success ? Ok() : NotFound();
    }

    [HttpPost("reject-interview-request/{interviewRequestId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RejectInterviewRequest(
        [FromRoute] Guid interviewRequestId, [FromBody] ChangeInterviewRequestStatusRequest request)
    {
        var success = await interviewsService.ChangeInterviewRequestStatusAsync(interviewRequestId,
            InterviewRequestStatus.Rejected, request.Message);

        return success ? Ok() : NotFound();
    }

    [HttpDelete("delete-interview-request/{interviewRequestId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteInterviewRequest([FromRoute] Guid interviewRequestId)
    {
        await interviewsService.DeleteInterviewRequestAsync(interviewRequestId);

        return NoContent();
    }
}
