using TestEF.Models;

namespace TestEF.Repositories
{
	public interface IBlogRepository
	{
		void UpdateTitle(int id, string title);
		void AddBlog(Blog blog);
	}
}