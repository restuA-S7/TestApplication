namespace RapidBootcamp.BackEndAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // =null!

        public IEnumerable<Product>? Products { get; set; } //soalnya nut null harus pakai tanda tanya jadi pas kita post itu gak bisa makanya harus kasih tanda
        //tanya

    }


}
