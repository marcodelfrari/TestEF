using System;
using System.Linq;
using TestEF.Models;

namespace TestEF.Repositories
{
	public class BlogRepository : IBlogRepository
	{ 
		public void SetTitle(int id, string title)
		{ 
			using (MyDbContext dbContext = new MyDbContext())
			{
				Blog blog = dbContext.Blogs.Find(id);
				blog.Title = title;
				dbContext.SaveChanges();
			}
		}
 
		public Blog GetBlog(int id)
		{
			using (MyDbContext dbContext = new MyDbContext())
			{ 
				return  dbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
			}
		}

		public void AddBlog(Blog blog)
		{
			using (MyDbContext dbContext = new MyDbContext())
			{
				dbContext.Database.EnsureCreated();
				dbContext.Blogs.Add(blog);
				dbContext.SaveChanges();
			}
		}
	}
}