using System.Linq;
using TestEF.Models;

namespace TestEF.Repositories
{
	public class BlogRepositoryCustom : BlogRepository, IBlogCustomRepository
	{
		public override void InitDb()
		{
			using (MyDbContextCustom dbContext = new MyDbContextCustom())
			{
				dbContext.Database.EnsureCreated();
			}
		}

		public void SetCustomField(int blogId, string val)
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