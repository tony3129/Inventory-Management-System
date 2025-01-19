using System.ComponentModel.DataAnnotations;

public class Product {
    [Key]
    public int ID { get; set;}
    [Required]
    public string Name { get; set; }
    public string Desc { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price {get; set; }
    [Required]
    public int StockQty { get; set; }

    public Category Category { get; set; }
}