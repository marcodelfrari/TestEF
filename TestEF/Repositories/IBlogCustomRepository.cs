using TestEF.Models;

namespace TestEF.Repositories
{
	public interface IBlogCustomRepository : IBlogRepository
	{
		void UpdateCustomField(int blogId, string val);
	}
}