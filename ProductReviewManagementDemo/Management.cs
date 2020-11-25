using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductReviewManagementDemo
{
    public class Management
    {
        List<ProductReview> listProductReview;

        /// <summary>
        /// UC1
        /// Adds the products to list.
        /// </summary>
        public void AddProductsToList()
        {
            listProductReview = new List<ProductReview>()
            {
                new ProductReview(){ProductId=1,UserId=1,Rating=5,Review="Nice",isLike=true},
                new ProductReview(){ProductId=2,UserId=1,Rating=5,Review="Nice",isLike=true},
                new ProductReview(){ProductId=3,UserId=2,Rating=7,Review="Better",isLike=true},
                new ProductReview(){ProductId=4,UserId=2,Rating=10,Review="Best",isLike=true},
                new ProductReview(){ProductId=5,UserId=3,Rating=6,Review="Better",isLike=true},
                new ProductReview(){ProductId=6,UserId=4,Rating=6,Review="Better",isLike=true},
                new ProductReview(){ProductId=1,UserId=5,Rating=1,Review="Worst",isLike=false},
                new ProductReview(){ProductId=11,UserId=10,Rating=9,Review="Best",isLike=true},
                new ProductReview(){ProductId=12,UserId=10,Rating=8,Review="Better",isLike=true},
                new ProductReview(){ProductId=9,UserId=10,Rating=2,Review="Worst",isLike=false},
                new ProductReview(){ProductId=14,UserId=10,Rating=8,Review="Best",isLike=true},
                new ProductReview(){ProductId=15,UserId=10,Rating=8,Review="Better",isLike=true},
                new ProductReview(){ProductId=16,UserId=10,Rating=3,Review="Worst",isLike=true},
            };
        }

        /// <summary>
        /// UC1
        /// Gets the products from list.
        /// </summary>
        public void GetProductsFromList()
        {
            foreach (var product in listProductReview)
            {
                Console.WriteLine("ProductID: " + product.ProductId + "  UserId : " + product.UserId + "  Rating : " + product.Rating +
              "  Review : " + product.Review + "  IsLike : " + product.isLike);
            }
        }

        /// <summary>
        /// UC2
        /// Retrieves the top 3  records with high rating.
        /// </summary>
        public void RetrieveTopRecordsWithHighRating()
        {
            var linqQuery = (from products in listProductReview
                             orderby products.Rating descending
                             select products).Take(3);

            foreach (var product in linqQuery)
            {
                Console.WriteLine("ProductID: " + product.ProductId + "  UserId : " + product.UserId + "  Rating : " + product.Rating +
              "  Review : " + product.Review + "  IsLike : " + product.isLike);
            }
        }

        /// <summary>
        /// UC3
        /// Retireves the products with rating greater than3 for selected product.
        /// </summary>
        public void RetireveProductsWithRatingGreaterThan3ForSelectedProduct()
        {
            var linqQuery = from products in listProductReview
                            where (products.Rating > 3) && (products.ProductId == 1 || products.ProductId == 4 || products.ProductId == 9)
                            select products;

            foreach (var product in linqQuery)
            {
                Console.WriteLine("ProductID: " + product.ProductId + "  UserId : " + product.UserId + "  Rating : " + product.Rating +
              "  Review : " + product.Review + "  IsLike : " + product.isLike);
            }
        }
    }
}
