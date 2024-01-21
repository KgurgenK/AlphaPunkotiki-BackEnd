﻿using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Models.InterviewsController;

public record GetInterviewRequestsResponse(IReadOnlyList<InterviewRequest> InterviewRequests);
