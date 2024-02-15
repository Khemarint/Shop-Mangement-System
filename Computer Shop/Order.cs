using System;

namespace Computer
{
	
	public class Order
	{
	
		public DateTime Date { get; set; }

	
		public string Name { get; set; }

		public string Number { get; set; }

		public int TotalAmount { get; set; }

	
		public int PaidAmount { get; set; }

	
		public int DueAmount { get; set; }

		public int Discount { get; set; }

	
		public int GrandTotal { get; set; }

	
		public string Status { get; set; }

		
		public Order(DateTime date, string name, string number, int totalAmount, int paidAmount, int dueAmount, int discount, int grandTotal, string status)
		{
			this.Date = date;
			this.Name = name;
			this.Number = number;
			this.TotalAmount = totalAmount;
			this.PaidAmount = paidAmount;
			this.DueAmount = dueAmount;
			this.Discount = discount;
			this.GrandTotal = grandTotal;
			this.Status = status;
		}
	}
}
