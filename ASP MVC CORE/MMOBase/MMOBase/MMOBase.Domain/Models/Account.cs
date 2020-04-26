using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMOBase.Domain.Models
{
	public class Account
	{
		[Key]
		[MaxLength(50)]
		public string Login { get; set; }
		[MaxLength(30)]
		public string Name { get; set; }
		[Column(TypeName = "Datetime")]
		public DateTime CreationDate { get; set; }
		public virtual ICollection<Champion> Champions { get; set; }
	}
}