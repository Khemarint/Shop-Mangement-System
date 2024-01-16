using System;

namespace Computer
{
	// Token: 0x02000003 RID: 3
	public class Category
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000208C File Offset: 0x0000028C
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002094 File Offset: 0x00000294
		public string Name { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000209D File Offset: 0x0000029D
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020A5 File Offset: 0x000002A5
		public string Status { get; set; }

		// Token: 0x0600000A RID: 10 RVA: 0x000020AE File Offset: 0x000002AE
		public Category(string name, string status)
		{
			this.Name = name;
			this.Status = status;
		}
	}
}
