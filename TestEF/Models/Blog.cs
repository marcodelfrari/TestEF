using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEF.Models
{
	/// <summary>
	/// Blog entity
	/// </summary>
	
	[Table("Blog")]
	public class Blog
	{
		[Key]
		public int BlogId { get; set; }


		[Required]
		[MaxLength(128)]
		public string Title { get; set; }


		[Required]
		[MaxLength(256)]
		public string SubTitle { get; set; }


	}
}