using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLitePCL;

namespace TestEF.Models
{ 
	public class BlogCustom : Blog
	{  
		public String CustomField { get; set; }
	}
}