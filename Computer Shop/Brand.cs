using System;

namespace Computer
{
	
	public class Brand
	{
		
		public string Name { get; set; }

	
		public string Status { get; set; }

		
		public Brand(string name, string status)
		{
			this.Name = name;
			this.Status = status;
		}
	}
}
