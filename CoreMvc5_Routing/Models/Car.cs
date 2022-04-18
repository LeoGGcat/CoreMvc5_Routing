using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CoreMvc5_Routing.Models
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Comment("汽車廠牌製造商")]
        public string Brand { get; set; }
        [Comment("汽車名稱")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Comment("汽車售價")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        [Comment("汽車分類")]
        public string Category { get; set; }
        [Comment("汽車年份")]
        public int Year { get; set; }
        [Comment("汽車年度銷售數字")]
        public int SoldNumber { get; set; }
    }
}