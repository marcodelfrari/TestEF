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
			builder.RegisterType<BlogRepositoryCustom>().As<IBlogCustomRepository>();
			Container = builder.Build(); 
			
			var repoStandard = Container.Resolve<IBlogRepository>();
			repoStandard.UpdateTitle(1, DateTime.Now.ToString());
			
			
			var repoCustom = Container.Resolve<IBlogCustomRepository>();
			repoCustom.UpdateTitle(1, DateTime.Now.ToString());
			 
			repoCustom.UpdateCustomField(1, DateTime.Now.ToString());
//			
//			BlogCustom newBlog = new BlogCustom();
//			newBlog.BlogId = new Random().Next(0, 100000);
//			newBlog.CustomField = DateTime.Now.ToString();
//			newBlog.Title = "test";
//			newBlog.SubTitle = "test"; 
//			
//			repoStandard.AddBlog(newBlog);
			
			//Debug.WriteLine(newBlog.GetType());
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