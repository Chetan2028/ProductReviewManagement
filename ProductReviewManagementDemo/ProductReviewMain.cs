using System;

namespace ProductReviewManagementDemo
{
    class ProductReviewMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management");
            Management management = new Management();
            management.AddProductsToList();
            management.RetrieveProductIdAndReview();
        }
    }
}
