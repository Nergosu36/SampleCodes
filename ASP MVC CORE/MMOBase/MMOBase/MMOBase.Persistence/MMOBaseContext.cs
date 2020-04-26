using MMOBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MMOBase.Persistence
{
	public class MMOBaseContext: DbContext
	{
		public MMOBaseContext(): base("MMOBaseContext")
		{
			
		}
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Champion> Champions { get; set; }
	}
}
