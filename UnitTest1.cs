using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FamilyBudget.Application.Interface;
using FamilyBudget.Infrastructure.DataContext;
using FamilyBudget.Infrastructure.Repositories;
using FamilyBudget.Application.Services;
using FamilyBudget.Application.Model;

using Moq;
using Moq.Protected;


namespace TestInfrastructure
{
    [TestClass]
    public class UnitTest1
    {
//         [TestMethod]
//         public void TestCategoryXrefsFromDbContext()
//         {
//            using (var db = new BudgetDbContext())
//             {
//                 //Console.WriteLine("Querying for a blog");
//                var blogs = db.CategoryXrefs         //.CategoryXrefs   Categories  Purchases  Products
// //                    .FromSqlRaw("select ProductID,Title from Products")
//                     .ToList();
// //               var blogs = db.Products
// //                    .FromSqlRaw("select ProductID,Title from Products")
// //                    .ToList();
//                 Assert.AreNotEqual(blogs.Count,0);

//             }
//         }

        [TestMethod]
        public void TestCategoryXrefsFromRepo()
        {
            var rpo = new Mock<IProductRepo>().Object;
           //using (var db = new BudgetDbContext())
            {
                //var rpo = new ProductRepo(db);
                {
                    
                    //Console.WriteLine("Querying for a blog");
                var blogs = rpo.ReadAll();
                    Assert.AreNotEqual(blogs.ToList().Count,0);
                }
            }
        }

        [TestMethod]
        public void TestProductFromAppSvc()
        {
            var rpo = new Mock<IProductRepo>().Object;
            var evt = new Mock<ProductService>(rpo).Object;

            var res = evt.GetAll(null);
            Assert.IsNotNull(res);


            var ievt = new Mock<IProductService>().Object;
            var evts2 = new Mock<List<ProductVM>>().Object;
            evts2.Add(new ProductVM
            {
                ProductID=42,
                Title = "Today Special Day" ,
            });

            Mock.Get(ievt).Setup(x => x.GetAll(null)).Returns(evts2);


            var res2 = ievt.GetAll(null);
            Assert.IsNotNull(res2);




/*            
           using (var db = new BudgetDbContext())
            {
                var rpo = new ProductRepo(db);
                {
                    var svc = new ProductService(rpo);
                    
                    
                    //Console.WriteLine("Querying for a blog");
                var blogs = svc.GetAll();
                    Assert.AreNotEqual(blogs.ToList().Count,0);
                }
            }
*/            
        }

    }
}
