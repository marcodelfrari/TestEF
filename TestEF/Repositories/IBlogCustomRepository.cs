using TestEF.Models;

namespace TestEF.Repositories
{
	public interface IBlogCustomRepository : IBlogRepository
	{
		void SetCustomField(int blogId, string val);
	}
}