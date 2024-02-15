using System;

namespace Computer
{

	public class Product
	{
	
		public string Name { get; set; }

	
		public byte[] Image { get; set; }

		public int Rate { get; set; }

		
		public int Quantity { get; set; }

	
		public string Brand { get; set; }

		
		public string Category { get; set; }


		public string Status { get; set; }

		
		public Product(string name, byte[] image, int rate, int quantity, string brand, string category, string status)
		{
			this.Name = name;
			this.Image = image;
			this.Rate = rate;
			this.Quantity = quantity;
			this.Brand = brand;
			this.Category = category;
			this.Status = status;
		}
	}
}
