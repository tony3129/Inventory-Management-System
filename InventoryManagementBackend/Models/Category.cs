public class Category{
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}