﻿using _0_FrameWork.Domain;
using ShopManagement.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {


        public string Name { get; private set; }
        public string Code { get; private set; }
        public int UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public Category Category { get; private set; }
        public int CategoryId { get; private set; }

        public Product(string name, string code, int unitPrice, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle,
            string slug, string keyWords, string metaDescription, int categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public void Edit(string name, string code, int unitPrice, string shortDescription,
         string description, string picture, string pictureAlt, string pictureTitle,
         string slug, string keyWords, string metaDescription, int categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
            IsInStock = true;
        }


        public void InStock()
        {
            IsInStock = true;
        }

        public void InNotStock()
        {
            IsInStock = false;
        }
    }
}