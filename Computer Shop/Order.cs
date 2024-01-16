using System;

namespace Computer
{
	// Token: 0x02000005 RID: 5
	public class Order
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00003279 File Offset: 0x00001479
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00003281 File Offset: 0x00001481
		public DateTime Date { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000328A File Offset: 0x0000148A
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00003292 File Offset: 0x00001492
		public string Name { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000329B File Offset: 0x0000149B
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000032A3 File Offset: 0x000014A3
		public string Number { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000032AC File Offset: 0x000014AC
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000032B4 File Offset: 0x000014B4
		public int TotalAmount { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000032BD File Offset: 0x000014BD
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000032C5 File Offset: 0x000014C5
		public int PaidAmount { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000032CE File Offset: 0x000014CE
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000032D6 File Offset: 0x000014D6
		public int DueAmount { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000032DF File Offset: 0x000014DF
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000032E7 File Offset: 0x000014E7
		public int Discount { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000032F0 File Offset: 0x000014F0
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000032F8 File Offset: 0x000014F8
		public int GrandTotal { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00003301 File Offset: 0x00001501
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00003309 File Offset: 0x00001509
		public string Status { get; set; }

		// Token: 0x06000034 RID: 52 RVA: 0x00003314 File Offset: 0x00001514
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
