namespace DataModel.Model;

using Domain.Model;

public class ColaboratorDataModel
{
    public long Id { get; set; }
    public string Email { get; set; }
	public string Name { get; set; }
    public AddressDataModel Address { get; set; }

    public ColaboratorDataModel() {}

    // public ColaboratorDataModel(Colaborator colab)
    // {
    //     Id = colab.Id;
    //     Email = colab.GetEmail();
    //     Name = colab.GetName();

    //     Address = new AddressDataModel(colab.Address);
    // }

    public ColaboratorDataModel(IColaborator colab) {
        Id = colab.Id;
        Email = colab.GetEmail();
        Name = colab.GetName();
        
        Address = new AddressDataModel(colab.GetAddress());

    }
}