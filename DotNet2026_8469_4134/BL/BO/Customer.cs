namespace BO;
using static BO.Tools;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public Customer() : this(-1, "", "", "") { }

    public Customer(int id, string name, string address, string phone)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
    }

    public override string ToString() =>
    this.ToStringProperty();

}

