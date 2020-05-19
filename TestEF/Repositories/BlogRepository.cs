using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
		
		public virtual void InitDb()
		{
			using (MyDbContext dbContext = new MyDbContext())
			{
				dbContext.Database.EnsureCreated();
			}
		}

		public void Save(Blog blog)
		{
			using (MyDbContext dbContext = new MyDbContext())
			{
				dbContext.Attach(blog);
				dbContext.Entry(blog).State = EntityState.Modified;
			}
		}

		public void AddBlog(Blog blog)
		{
			using (MyDbContext dbContext = new MyDbContext())
			{
				dbContext.Blogs.Add(blog);
				dbContext.SaveChanges();
			}
		}
	}
}