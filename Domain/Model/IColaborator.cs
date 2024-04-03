namespace Domain.Model;

public interface IColaborator
{
	long Id { get; }
	// long GetId();
	string GetEmail();
	string GetName();
	string GetStreet();
	string GetPostalCode();
	Address GetAddress();
}