using System.Linq;
using TestEF.Models;

namespace TestEF.Repositories
{
	public class BlogRepository : IBlogRepository
	{ 
		public void UpdateTitle(int id, string title)
		{ 
			using (MyDbContext dbContext = new MyDbContext())
			{
				Blog blog = dbContext.Blogs.Find(id);
				blog.Title = title;
				dbContext.SaveChanges();
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