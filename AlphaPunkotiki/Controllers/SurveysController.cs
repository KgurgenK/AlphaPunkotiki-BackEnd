using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AlphaPunkotiki.WebApi.Controllers.Models.SurveysController;

namespace AlphaPunkotiki.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveysController(ISurveysService surveysService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetSurveysResponse>> GetAvailableSurveys()
        => Ok(new GetSurveysResponse(await surveysService.GetAllAvailableSurveysAsync()));

    [HttpGet("created-by/{creatorId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetSurveysResponse>> GetUserSurveys([FromRoute] Guid creatorId)
        => Ok(new GetSurveysResponse(await surveysService.GetUserSurveysAsync(creatorId)));

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetFullSurveyResponse>> GetSurveyWithQuestionsById([FromRoute] Guid id)
    {
        var result = await surveysService.GetSurveyWithQuestionsAsync(id);

        return result.TryGetValue(out var surveyWithQuestions, out var fault)
            ? Ok(new GetFullSurveyResponse(surveyWithQuestions.Survey, surveyWithQuestions.Questions))
            : fault.ThrowResultError();
    }

    [AuthorizedRoles(Role.Interviewer, Role.Admin)]
    [HttpGet("questions-statistics/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetQuestionStatisticsResponse>> GetQuestionStatistics([FromRoute] Guid id)
    {
        var statistics = await surveysService.GetStatisticsOfQuestionAsync(id);

        return Ok(new GetQuestionStatisticsResponse(statistics));
    }

    [AuthorizedRoles(Role.Interviewer, Role.Admin)]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateSurvey([FromBody] CreateSurveyRequest request)
    {
        await surveysService.CreateSurveyAsync(request.Survey, request.Questions);

        return Created();
    }

    [AuthorizedRoles(Role.Respondent, Role.Admin)]
    [HttpPost("post-answers")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PostAnswers([FromBody] PostAnswersRequest request)
    {
        var success = await surveysService.TryAddAnswersAsync(request.UserId, request.Answers);

        return success ? Created() : BadRequest();
    }
}

