using Microsoft.AspNetCore.Http;

public class UpdateItemVM
{
    public int item_id { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public string description { get; set; }
    public IFormFile? image { get; set; } 
    public string? ExistingImagePath { get; set; }
    public int menu_id { get; set; }
    public bool recommended { get; set; }
}
