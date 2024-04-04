namespace Domain.Model;
public class Associate : IAssociate
{
    public long Id { get; set; }
    public IColaborator _colaborator;

    public DateOnly _startDate;
    public DateOnly? _endDate;

    protected Associate () {}

    public Associate(IColaborator colaborator, DateOnly startDate, DateOnly? endDate)
    {
        if(colaborator is null || !isStartDateIsValid(startDate, endDate))
        {
            throw new ArgumentException("Invalid arguments.");
        }

        this._colaborator = colaborator;
        this._startDate = startDate;
        this._endDate = endDate;
    }

    public bool hasColaborador(IColaborator colab)
	{
		return this._colaborator == colab ? true : false;
	}

    public bool isStartDateIsValid(DateOnly startDate, DateOnly? endDate)
	{
		if( startDate >= endDate ) 
		{
			return false;
		}
		return true;
	}

    public bool isDateInRange(DateOnly startDate, DateOnly? endDate)
    {
        return this._startDate >= startDate && this._endDate <= endDate;
    }

    public bool isColaboratorValidInDateRange(IColaborator colaborator, DateOnly startDate, DateOnly? endDate)
    {
        return this.hasColaborador(colaborator) && this.isDateInRange(startDate, endDate);
    }

    public IColaborator getColaborator()
    {
        return this._colaborator;
    }
}