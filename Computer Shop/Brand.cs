using System;

namespace Computer
{
	// Token: 0x02000002 RID: 2
	public class Brand
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public string Name { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public string Status { get; set; }

		// Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		public Brand(string name, string status)
		{
			this.Name = name;
			this.Status = status;
		}
	}
}
