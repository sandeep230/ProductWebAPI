using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductWebAPI.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar")]
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar")]
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }

    }
    [Table("SubCategory")]
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar")]
        [MaxLength(50)]
        public string Title { get; set; }
        public virtual Category Category { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "varchar")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [Column("shortdescription", TypeName = "varchar")]
        [MaxLength(255)]
        public string shortdescription { get; set; }
        [DataType(DataType.Upload)]
        public byte[] Image { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
    [Table("Review")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public int Rating { get; set; }
        public DateTime AddedDate { get; set; }
        public Product Product { get; set; }
        public string Username { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }

    public class ProductReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}