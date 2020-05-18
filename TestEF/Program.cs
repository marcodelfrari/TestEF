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
			builder.RegisterType<BlogRepository>().As<IBlogRepository>();
			Container = builder.Build();
			 
			InitDB(); 
			
			UpdateTitle();

			LogTitle();
		}

		
		private static void LogTitle()
		{
			IBlogRepository repoStandard = Container.Resolve<IBlogRepository>();
			Blog blog = repoStandard.GetBlog(1);
			Debug.WriteLine($"Title: {blog.Title}");
		}

		private static void UpdateTitle()
		{
			IBlogRepository repoStandard = Container.Resolve<IBlogRepository>();
			repoStandard.SetTitle(1, DateTime.Now.ToString());
		} 
		
		/// <summary>
		/// Add Blog with ID = 1 if not exists
		/// </summary>
		private static void InitDB()
		{
			DeleteDBFile();
			
			IBlogRepository repoStandard = Container.Resolve<IBlogRepository>();
		 
			Blog newBlog = new Blog();
			newBlog.BlogId = 1;
			newBlog.Title = DateTime.Now.ToString();
			repoStandard.AddBlog(newBlog);
		}
		
		private static void DeleteDBFile()
		{
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string db = Path.Combine(Path.GetDirectoryName(path), "TestDatabase.db");
			File.Delete(db);
		}

	}
}