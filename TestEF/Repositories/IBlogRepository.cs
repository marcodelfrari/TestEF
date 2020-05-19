using System;
using TestEF.Models;

namespace TestEF.Repositories
{
	public interface IBlogRepository
	{
		void SetTitle(int id, string title); 
		void AddBlog(Blog blog);
		Blog GetBlog(int id);
		public void InitDb();
		void Save(Blog blog);
		
	}
}