using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace ProductReviewManagementDemo
{
    public class Management
    {
        //List to store Product Details
        List<ProductReview> listProductReview;

        //Create a DataTable
        DataTable table = new DataTable();

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
                new ProductReview(){ProductId=7,UserId=5,Rating=1,Review="Worst",isLike=false},
                new ProductReview(){ProductId=8,UserId=10,Rating=9,Review="Best",isLike=true},
                new ProductReview(){ProductId=9,UserId=4,Rating=2,Review="Worst",isLike=true},
                new ProductReview(){ProductId=10,UserId=5,Rating=1,Review="Worst",isLike=false},
                new ProductReview(){ProductId=11,UserId=10,Rating=9,Review="Best",isLike=true},
                new ProductReview(){ProductId=12,UserId=10,Rating=8,Review="Better",isLike=true},
                new ProductReview(){ProductId=13,UserId=10,Rating=2,Review="Worst",isLike=false},
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
        /// <summary>
        /// UC4
        /// Gets the count of reviews.
        /// </summary>
        public void GetCountOfReviews()
        {
            var ReviewCount = from products in listProductReview
                              group products by products.ProductId into g
                              select new
                              {
                                  ProductID = g.Key,
                                  Count = g.Count()
                              };

            foreach (var list in ReviewCount)
            {
                Console.WriteLine(list.ProductID + "-------------" + list.Count);
            }
        }

        /// <summary>
        /// UC5
        /// Retrieves the product identifier and review.
        /// </summary>
        public void RetrieveProductIdAndReview()
        {
            var linqQuery = from products in listProductReview
                            select new
                            {
                                ProductID = products.ProductId,
                                Review = products.Review
                            };

            foreach (var list in linqQuery)
            {
                Console.WriteLine("ProductID : " + list.ProductID + "  Review : " + list.Review);
            }
        }

        /// <summary>
        /// UC6
        /// Skips the top5 records and display other records.
        /// </summary>
        public void SkipTop5ProductsAndDisplayOtherRecords()
        {
            var linqQuery = (from products in listProductReview
                             orderby products.Rating descending
                             select products).Skip(5);

            foreach (var product in linqQuery)
            {
                Console.WriteLine("ProductID: " + product.ProductId + "  UserId : " + product.UserId + "  Rating : " + product.Rating +
              "  Review : " + product.Review + "  IsLike : " + product.isLike);
            }
        }

        /// <summary>
        /// UC8
        /// Creates the data table.
        /// </summary>
        public void CreateDataTable()
        {
            //Creating columns
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("UserId", typeof(int));
            table.Columns.Add("Rating", typeof(double));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("isLike", typeof(bool));

            //Add data to columns
            table.Rows.Add(1, 1, 4, "Nice", true);
            table.Rows.Add(2, 2, 5, "Better", true);
            table.Rows.Add(3, 3, 10, "Best", true);
            table.Rows.Add(4, 4, 9, "Best", true);
            table.Rows.Add(5, 5, 5, "Better", true);
            table.Rows.Add(6, 10, 6, "Better", false);
            table.Rows.Add(7, 4, 4, "Nice", true);
            table.Rows.Add(8, 11, 7, "Better", true);
            table.Rows.Add(9, 15, 1, "Worst", true);
            table.Rows.Add(10, 2, 8, "Best", false);
            table.Rows.Add(11, 3, 5, "Better", true);
            table.Rows.Add(12, 4, 9, "Best", true);
            table.Rows.Add(13, 10, 10, "Best", true);
            table.Rows.Add(14, 10, 2, "Worst", false);
            table.Rows.Add(15, 10, 2.5, "Worst", false);
            table.Rows.Add(16, 1, 3, "Nice", true);
        }
        /// <summary>
        /// UC9 --> to retireve data from table using isLike column
        /// Retrieves the data from table.
        /// </summary>
        public void RetrieveDataFromTable()
        {
            var recordData = from products in table.AsEnumerable()
                             where (products.Field<bool>("isLike") == true)
                             select products;

            foreach (var product in recordData)
            {
                Console.WriteLine("ProductId : " + product.Field<int>("ProductId") + "  UserId : " + product.Field<int>("userId")
                    + " Rating : " + product.Field<double>("Rating") + "  Review : " + product.Field<string>("Review") 
                    + "  IsLike : " + product.Field<bool>("isLike"));
            }
        }
    }
}
