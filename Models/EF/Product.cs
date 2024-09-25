﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.EF
{
    interface MVCEntityProduct
    {
        string UpdateDatabase(ApplicationDbContext db, Product model);
    }
    [Table("tb_Product")]
    public class Product : CommonAbstract, MVCEntityProduct
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public string UpdateDatabase(ApplicationDbContext db,Product model)
        {
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
            db.Products.Attach(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Chỉnh sửa thành công";
        }
        public class ProxyProduct : MVCEntityProduct
        {
            private Product _product;
            public ProxyProduct(Product product)
            {
                _product = product;
            }
            public string UpdateDatabase(ApplicationDbContext db, Product model)
            {
                string notAllow = "Ho Chi Minh";
                if (_product.Title.Contains(notAllow))
                {
                    return "Title không hợp lệ";
                }
                return _product.UpdateDatabase(db, model);
            }
        }
    }
}