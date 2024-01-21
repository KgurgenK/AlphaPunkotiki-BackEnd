using AlphaPunkotiki.WebApi.Models.SurveysController;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlphaPunkotiki.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveysController(ISurveysService surveysService) : ControllerBase
{
    [HttpGet("surveys")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetSurveysResponse>> GetAvailableSurveys()
        => Ok(new GetSurveysResponse(await surveysService.GetAllAvailableSurveysAsync()));

    [HttpGet("user-surveys/{creatorId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetSurveysResponse>> GetUserSurveys([FromRoute] Guid creatorId)
        => Ok(new GetSurveysResponse(await surveysService.GetUserSurveysAsync(creatorId)));

    [HttpGet("surveys/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetFullSurveyResponse>> GetSurveyWithQuestionsById([FromRoute] Guid id)
    {
        var (survey, questions) = await surveysService.GetSurveyWithQuestionsAsync(id);

        return survey is null ? NotFound() : Ok(new GetFullSurveyResponse(survey, questions));
    }

    [HttpGet("questions-statistics/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetQuestionStatisticsResponse>> GetQuestionStatistics(Guid id)
    {
        var statistics = await surveysService.GetStatisticsOfQuestionAsync(id);

        return Ok(new GetQuestionStatisticsResponse(statistics));
    }

    [HttpPost("create-survey")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateSurvey([FromBody] CreateSurveyRequest request)
    {
        await surveysService.CreateSurveyAsync(request.Survey, request.Questions);

        return Created();
    }

    [HttpPost("post-answers")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> PostAnswers([FromBody] PostAnswersRequest request)
    {
        await surveysService.AddAnswersAsync(request.UserId, request.Answers);

        return Created();
    }
}

