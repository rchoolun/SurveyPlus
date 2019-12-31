using System;
using Asteck.SurveyPlus.Data;

public class UnitOfWork : IUnitOfWork
{
    private Entities _context;

    public UnitOfWork(Entities context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new Entities();
	}
	
    public IWebpagesRolesRepository webpages_Roless
    {
        get { return new WebpagesRolesRepository(_context); }
    }

    public IWebpagesOauthmembershipRepository webpages_OAuthMemberships
    {
        get { return new WebpagesOauthmembershipRepository(_context); }
    }

    public IWebpagesMembershipRepository webpages_Memberships
    {
        get { return new WebpagesMembershipRepository(_context); }
    }

    public IUserquestionnaireRepository UserQuestionnaires
    {
        get { return new UserquestionnaireRepository(_context); }
    }

    public IUserprofileRepository UserProfiles
    {
        get { return new UserprofileRepository(_context); }
    }

    public IUserRepository Users
    {
        get { return new UserRepository(_context); }
    }

    public IResultRepository Results
    {
        get { return new ResultRepository(_context); }
    }

    public IQuestionnairequestionRepository QuestionnaireQuestions
    {
        get { return new QuestionnairequestionRepository(_context); }
    }

    public IQuestionnaireRepository Questionnaires
    {
        get { return new QuestionnaireRepository(_context); }
    }

    public IQuestionanswerRepository QuestionAnswers
    {
        get { return new QuestionanswerRepository(_context); }
    }

    public IQuestionRepository Questions
    {
        get { return new QuestionRepository(_context); }
    }

    public IAnswerRepository Answers
    {
        get { return new AnswerRepository(_context); }
    }

    
    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
