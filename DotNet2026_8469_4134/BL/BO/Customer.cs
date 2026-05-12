namespace BO;
using static BO.Tools;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public bool IsClub { get; set; }
    public Customer() : this(-1, "", "", "", false) { }

    public Customer(int id, string name, string address, string phone, bool isClub = false)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
        IsClub = isClub;
    }

    public override string ToString() =>
    this.ToStringProperty();

}

