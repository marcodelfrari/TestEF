using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEF.Models
{
	[Table("Blog")]
	public class BlogCustom : Blog
	{ 
		[Required]
		public DateTime DateTimeAdd { get; set; }
	}
}