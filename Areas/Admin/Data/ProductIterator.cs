﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Data
{
    public interface ITerator
    {
        Product First();
        Product Next();
        bool IsDone { get; }
        Product CurrentItem { get; }
    }
    public class ProductIterator : ITerator
    {
        List<Product> _listProduct;
        int current = 0;
        int step = 1;
        public ProductIterator(List<Product> listProduct)
        {
            _listProduct = listProduct;
        }

        public bool IsDone {
            get { return current >= _listProduct.Count; } 
        }

        public Product CurrentItem => _listProduct[current];

        public Product First()
        {
            current = 0;
            if (_listProduct.Count > 0)
                return _listProduct[current];
            return null;
        }

        public Product Next()
        {
            current += step;
            if (!IsDone)
                return _listProduct[current];
            else
                return null;
        }
    }
}