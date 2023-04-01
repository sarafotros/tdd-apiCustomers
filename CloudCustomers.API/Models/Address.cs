using Microsoft.AspNetCore.Authentication;

namespace CloudCustomers.API.Models;

public class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostCode { get; set; }
}