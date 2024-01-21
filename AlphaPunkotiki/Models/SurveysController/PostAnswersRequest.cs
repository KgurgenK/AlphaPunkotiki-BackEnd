using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Models.SurveysController;

public record PostAnswersRequest(Guid UserId, IReadOnlyList<AnswerDto> Answers);
