using TestEF.Models;

namespace TestEF.Repositories
{
	public interface IBlogRepository
	{
		Blog GetBlog(int id);
		void Save(Blog blog);
	}
}