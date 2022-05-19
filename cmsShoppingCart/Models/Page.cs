﻿using System.ComponentModel.DataAnnotations;

namespace cmsShoppingCart.Models
{
	public class Page
	{
		public int Id { get; set; }
		[Required,MinLength(2,ErrorMessage ="The minimum length is 2.")]
		public string Title { get; set; }
		public string Slug { get; set; }
		[Required, MinLength(4, ErrorMessage = "The minimum length is 4.")]

		public string Content { get; set; }
		public int Sorting { get; set; }

	}
}
