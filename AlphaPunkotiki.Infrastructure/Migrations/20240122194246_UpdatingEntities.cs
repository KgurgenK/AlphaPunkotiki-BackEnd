using System;
using AlphaPunkotiki.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaPunkotiki.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionTimeLimit",
                table: "Surveys",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Surveys",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedCompletionTime",
                table: "Surveys",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedPublicationTime",
                table: "Surveys",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedUsages",
                table: "Surveys",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationTimeLimit",
                table: "Surveys",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsagesLimit",
                table: "Surveys",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "Questions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Tooltip",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<QuestionType>(
                name: "Type",
                table: "Questions",
                type: "question_type",
                nullable: false,
                defaultValue: QuestionType.Text);

            migrationBuilder.AddColumn<string[]>(
                name: "Variables",
                table: "Questions",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionTimeLimit",
                table: "Interviews",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Interviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedCompletionTime",
                table: "Interviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedPublicationTime",
                table: "Interviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimitedUsages",
                table: "Interviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationTimeLimit",
                table: "Interviews",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsagesLimit",
                table: "Interviews",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "InterviewRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InterviewId",
                table: "InterviewRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Answers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Answers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string[]>(
                name: "Values",
                table: "Answers",
                type: "text[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequests_InterviewId",
                table: "InterviewRequests",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewRequests_Interviews_InterviewId",
                table: "InterviewRequests",
                column: "InterviewId",
                principalTable: "Interviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewRequests_Interviews_InterviewId",
                table: "InterviewRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_InterviewRequests_InterviewId",
                table: "InterviewRequests");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CompletionTimeLimit",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "IsLimitedCompletionTime",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "IsLimitedPublicationTime",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "IsLimitedUsages",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "PublicationTimeLimit",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "UsagesLimit",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Tooltip",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Variables",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CompletionTimeLimit",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "IsLimitedCompletionTime",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "IsLimitedPublicationTime",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "IsLimitedUsages",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "PublicationTimeLimit",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "UsagesLimit",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "InterviewRequests");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "InterviewRequests");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "Answers");
        }
    }
}
