using TestEF.Models;

namespace TestEF.Repositories
{
	public class BlogRepository : IBlogRepository
	{ 
		public Blog GetBlog(int id)
		{ 
			using (MyDbContext dbContext = new MyDbContext())
			{
				return dbContext.Blogs.Find(id);
			}
		}

		public void Save(Blog blog)
		{
			using (MyDbContext dbContext = new MyDbContext())
			{
				dbContext.Blogs.Add(blog);
				dbContext.SaveChanges();
			}
		}
	}
}