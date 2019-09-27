using TestEF.Models;

namespace TestEF.Repositories
{
	public class BlogRepositoryCustom : BlogRepository
	{
		public Blog GetBlog(int id)
		{ 
			using (MyDbContextCustom dbContext = new MyDbContextCustom())
			{
				return dbContext.Blogs.Find(id);
			} 
		}
	}
}