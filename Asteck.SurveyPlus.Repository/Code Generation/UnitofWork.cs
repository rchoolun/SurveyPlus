using System;
using Asteck.SurveyPlus.Data;

public class UnitOfWork : IUnitOfWork
{
    private SurveyPlusEntities _context;

    public UnitOfWork(SurveyPlusEntities context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new SurveyPlusEntities();
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
