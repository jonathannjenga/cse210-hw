class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
    }
}
       static void Main(string[] args)
    {
        
        Address address1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Address address2 = new Address("456 King Rd", "Toronto", "ON", "Canada");

        
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Alice Brown", address2);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P1001", 25.99, 2));
        order1.AddProduct(new Product("Keyboard", "P1002", 45.50, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("USB Hub", "P2001", 15.75, 3));
        order2.AddProduct(new Product("Laptop Stand", "P2002", 32.99, 1));
        order2.AddProduct(new Product("Webcam", "P2003", 49.95, 1));
        Console.WriteLine("===== ORDER 1 =====");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine("===== ORDER 2 =====");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}\n");
    }
}
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}
public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder("Packing Label:\n");

        foreach (Product product in _products)
        {
            label.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}

