using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidBootcamp.WebApplication.Models
{
    public class Category
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] ini biar auto increment Identity ganti none kaalau gak mau auto incrment atau gak usah masukin itu
        public int CategoryId { get; set; }

        [Required] //ini harus ada isinya artinya
        [StringLength(100)] //panjang string
        public string CategoryName { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }

    //ada sebelumnya Wallet.cs
    //isinya
    /*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidBootcamp.WebApplication.Models
    {
        public class Wallet
        {
            [Key]
            public int WalletId { get; set; }
            [ForeignKey("CustomerId")]
            public int CustomerId { get; set; }
            public string WalletName { get; set; }
            public decimal Saldo { get; set; }

            public Customer? Customer { get; set; }
            public IEnumerable<OrderHeader>? OrderHeaders { get; set; }

        }
    }*/


}
