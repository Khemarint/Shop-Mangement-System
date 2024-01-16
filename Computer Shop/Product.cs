using System;

namespace Computer
{
	// Token: 0x02000006 RID: 6
	public class Product
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00003377 File Offset: 0x00001577
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000337F File Offset: 0x0000157F
		public string Name { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003388 File Offset: 0x00001588
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00003390 File Offset: 0x00001590
		public byte[] Image { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003399 File Offset: 0x00001599
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000033A1 File Offset: 0x000015A1
		public int Rate { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000033AA File Offset: 0x000015AA
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000033B2 File Offset: 0x000015B2
		public int Quantity { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000033BB File Offset: 0x000015BB
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000033C3 File Offset: 0x000015C3
		public string Brand { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000033CC File Offset: 0x000015CC
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000033D4 File Offset: 0x000015D4
		public string Category { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000033DD File Offset: 0x000015DD
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000033E5 File Offset: 0x000015E5
		public string Status { get; set; }

		// Token: 0x06000043 RID: 67 RVA: 0x000033F0 File Offset: 0x000015F0
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
