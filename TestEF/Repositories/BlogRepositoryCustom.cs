using System.Linq;
using TestEF.Models;

namespace TestEF.Repositories
{
	public class BlogRepositoryCustom : BlogRepository, IBlogCustomRepository
	{
		public void UpdateCustomField(int blogId, string val)
		{
			using (MyDbContextCustom dbContext = new MyDbContextCustom())
			{
				var blogCustom = dbContext.Blogs.Find(blogId);
				blogCustom.CustomField = val;
				dbContext.SaveChanges();
			}
		}
	}
}