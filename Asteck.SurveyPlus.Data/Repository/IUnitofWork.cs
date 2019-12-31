            using System;

public interface IUnitOfWork : IDisposable
{
    IWebpagesRolesRepository webpages_Roless { get; }
    IWebpagesOauthmembershipRepository webpages_OAuthMemberships { get; }
    IWebpagesMembershipRepository webpages_Memberships { get; }
    IUserquestionnaireRepository UserQuestionnaires { get; }
    IUserprofileRepository UserProfiles { get; }
    IUserRepository Users { get; }
    IResultRepository Results { get; }
    IQuestionnairequestionRepository QuestionnaireQuestions { get; }
    IQuestionnaireRepository Questionnaires { get; }
    IQuestionanswerRepository QuestionAnswers { get; }
    IQuestionRepository Questions { get; }
    IAnswerRepository Answers { get; }
    void Save();
}
