using System;
using System.Diagnostics;
using Autofac;
using TestEF.Models;
using TestEF.Repositories;

namespace TestEF
{
	class Program
	{
		public static IContainer Container { get; set; }
		
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
 
			//builder.RegisterType<BlogRepository>().As<IBlogRepository>();
			builder.RegisterType<BlogRepositoryCustom>().As<IBlogRepository>();
			Container = builder.Build(); 
			
			var repo = Container.Resolve<IBlogRepository>();
			 
			Blog blog = repo.GetBlog(1);
			
			BlogCustom newBlog = new BlogCustom();
			newBlog.BlogId = new Random().Next(0, 100000);
			newBlog.DateTimeAdd = DateTime.Now;
			newBlog.Title = "test";
			newBlog.SubTitle = "test"; 
			
			repo.Save(newBlog);
			
			Debug.WriteLine(blog.GetType());
		}

		static void Main2(string[] args)
		{
//			string dbName = "TestDatabase.db";
//			if (File.Exists(dbName))
//			{
//				File.Delete(dbName);
//			}
//			
//			using (var dbContext = new MyDbContextCustom())
//			{
//				//Ensure database is created
//				dbContext.Database.EnsureCreated();
//				if (!dbContext.BlogCustoms.Any())
//				{
//					dbContext.BlogCustoms.AddRange(new BlogCustom[]
//					{
//						new BlogCustom{ BlogId=1, Title="Blog 1", SubTitle="Blog 1 subtitle" },
//						new BlogCustom{ BlogId=2, Title="Blog 2", SubTitle="Blog 2 subtitle" },
//						new BlogCustom{ BlogId=3, Title="Blog 3", SubTitle="Blog 3 subtitle" }
//					});
//					dbContext.SaveChanges();
//				}
//
//
//				foreach (var blog in dbContext.BlogCustoms)
//				{
//					Console.WriteLine($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}");
//				}
//			}
//			Console.ReadLine();
		}
	}
}