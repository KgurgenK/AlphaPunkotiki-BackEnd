using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using AlphaPunkotiki.WebApi.Models.InterviewsController;
using Microsoft.AspNetCore.Mvc;

namespace AlphaPunkotiki.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterviewsController(IInterviewsService interviewsService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetInterviewResponse>> GetInterviewById([FromRoute] Guid id)
    {
        var interview = await interviewsService.GetInterviewAsync(id);

        return interview is null ? NotFound() : Ok(new GetInterviewResponse(interview));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewsResponse>> GetAvailableInterviews()
        => Ok(new GetInterviewsResponse(await interviewsService.GetAllAvailableInterviewsAsync()));

    [HttpGet("created-by/{creatorId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewsResponse>> GetUserInterviews([FromRoute] Guid creatorId)
        => Ok(new GetInterviewsResponse(await interviewsService.GetUserInterviewsAsync(creatorId)));

    [HttpGet("requests/created-by/{candidateId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewRequestsResponse>> GetCandidateInterviewRequests(
        [FromRoute] Guid candidateId)
        => Ok(new GetInterviewRequestsResponse(
            await interviewsService.GetCandidateInterviewRequestsAsync(candidateId)));

    [HttpGet("requests/by-interviewer/{interviewerId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewRequestsResponse>> GetInterviewerInterviewRequests(
        [FromRoute] Guid interviewerId)
        => Ok(new GetInterviewRequestsResponse(await interviewsService.GetInterviewerInterviewRequestsAsync(interviewerId)));

    [HttpGet("{interviewId:guid}/requests")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetInterviewRequestsResponse>> GetInterviewRequestsOfInterview(
        [FromRoute] Guid interviewId)
        => Ok(new GetInterviewRequestsResponse(await interviewsService.GetInterviewRequestsByInterviewAsync(interviewId)));

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateInterview([FromBody] CreateInterviewRequest request)
    {
        await interviewsService.CreateInterviewAsync(request.InterviewInfo);

        return Created();
    }

    [HttpPost("requests/create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateInterviewRequest([FromBody] CreateInterviewRequestRequest request)
    {
        var success = await interviewsService.TryCreateInterviewRequestAsync(request.UserId, request.InterviewId);

        return success ? Created() : BadRequest();
    }

    [HttpPost("requests/{interviewRequestId:guid}/approve")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> ApproveInterviewRequest(
        [FromRoute] Guid interviewRequestId, [FromBody] ChangeInterviewRequestStatusRequest request)
    {
        var success = await interviewsService.TryChangeInterviewRequestStatusAsync(interviewRequestId,
            InterviewRequestStatus.Approved, request.Message);

        return success ? Ok() : NotFound();
    }

    [HttpPost("requests/{interviewRequestId:guid}/reject")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RejectInterviewRequest(
        [FromRoute] Guid interviewRequestId, [FromBody] ChangeInterviewRequestStatusRequest request)
    {
        var success = await interviewsService.TryChangeInterviewRequestStatusAsync(interviewRequestId,
            InterviewRequestStatus.Rejected, request.Message);

        return success ? Ok() : NotFound();
    }

    [HttpDelete("requests/{interviewRequestId:guid}/delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteInterviewRequest([FromRoute] Guid interviewRequestId)
    {
        await interviewsService.DeleteInterviewRequestAsync(interviewRequestId);

        return NoContent();
    }
}
