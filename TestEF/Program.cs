using System;
using System.Diagnostics;
using System.IO;
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
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<BlogRepositoryCustom>().As<IBlogRepository>();
			builder.RegisterType<BlogRepositoryCustom>().As<IBlogCustomRepository>();
			Container = builder.Build();
			 
			InitDB(); 
			 
			UpdateCustomField();
			
			UpdateTitle();

			ShowBlogData();
		}

		private static void UpdateCustomField()
		{
			IBlogCustomRepository repoStandard = Container.Resolve<IBlogCustomRepository>();
			repoStandard.SetCustomField(1, $"Custom {DateTime.Now}");
		}


		private static void ShowBlogData()
		{
			IBlogRepository repoStandard = Container.Resolve<IBlogRepository>();
			Blog blog = repoStandard.GetBlog(1);
			Debug.WriteLine($"Title: {blog.Title}");
		}
		
		private static void ShowBlogDataCustom()
		{
			IBlogCustomRepository repoStandard = Container.Resolve<IBlogCustomRepository>();
			BlogCustom blog = repoStandard.GetBlog(1) as BlogCustom;
			Debug.WriteLine($"Title: {blog?.Title}");
			Debug.WriteLine($"Custom: {blog?.CustomField}");
		}

		private static void UpdateTitle()
		{
			IBlogRepository repoStandard = Container.Resolve<IBlogRepository>();
			Blog blog = repoStandard.GetBlog(1);
			blog.Title = DateTime.Now.ToString();
			repoStandard.Save(blog);
		} 
		
		/// <summary>
		/// Add Blog with ID = 1 if not exists
		/// </summary>
		private static void InitDB()
		{
			// 1- remove existing DB
			DeleteDBFile();
			
			// 2- EnsureCreated
			IBlogRepository repo = Container.Resolve<IBlogRepository>();
			repo.InitDb();
			
			// 3- Add sample Blog record
			Blog newBlog = new Blog();
			newBlog.BlogId = 1;
			newBlog.Title = "Title";
			repo.AddBlog(newBlog);
		}
		
		private static void DeleteDBFile()
		{
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string db = Path.Combine(Path.GetDirectoryName(path), "TestDatabase.db");
			File.Delete(db);
		}

	}
}