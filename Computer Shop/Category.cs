using System;

namespace Computer
{
	
	public class Category
	{
	
		public string Name { get; set; }

		public string Status { get; set; }

		
		public Category(string name, string status)
		{
			this.Name = name;
			this.Status = status;
		}
	}
}
