using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Controllers.Models.SurveysController;

public record PostAnswersRequest(Guid UserId, IReadOnlyList<AnswerDto> Answers);
