using Microsoft.EntityFrameworkCore;
using Wazifny.Data;
//using Wazifny.Models;

namespace Product_Category_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext appContext = new AppDbContext();

            // var p1 = new Product { Name = "fruits " , category=new Category {Name="category1" } };

            // appContext.Products.Add(p1);
            // //appContext.SaveChanges();
            // var p2 = new Product { productId = 1, Name = "food ", category = new Category { Name = "category1" } };
            // appContext.Update(p2);
            // //appContext.SaveChanges();
            //appContext.Remove(p2);

            // appContext.Products.Remove(p1);
            // appContext.SaveChanges();

            //appContext.Products.ExecuteDelete();
            //appContext.Categories.ExecuteDelete();

        }
    }
}
