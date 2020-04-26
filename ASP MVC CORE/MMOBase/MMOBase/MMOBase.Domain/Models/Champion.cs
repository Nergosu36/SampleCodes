using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMOBase.Domain.Models
{
	public class Champion
	{
		[Key]
		public int ChampionID { get; set; }
		[MaxLength(30)]
		public string Name { get; set; }
		public int Level { get; set; }
		//[ForeignKey("Login")]
		public string AccountLogin { get; set; }

	}
}