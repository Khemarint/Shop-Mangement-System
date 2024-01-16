using System;

namespace Computer
{
	// Token: 0x02000007 RID: 7
	public class User
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003441 File Offset: 0x00001641
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00003449 File Offset: 0x00001649
		public string Name { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003452 File Offset: 0x00001652
		// (set) Token: 0x06000047 RID: 71 RVA: 0x0000345A File Offset: 0x0000165A
		public string Email { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003463 File Offset: 0x00001663
		// (set) Token: 0x06000049 RID: 73 RVA: 0x0000346B File Offset: 0x0000166B
		public string Password { get; set; }

		// Token: 0x0600004A RID: 74 RVA: 0x00003474 File Offset: 0x00001674
		public User(string name, string email, string password)
		{
			this.Name = name;
			this.Email = email;
			this.Password = password;
		}
	}
}
