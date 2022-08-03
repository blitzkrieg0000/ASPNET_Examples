using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Entities.Concrete
{
	public partial class Player
	{
		public Player()
		{
			PlayingData = new HashSet<PlayingDatum>();
		}

		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime? Birthday { get; set; }
		public char Gender { get; set; }
		public DateTime SaveDate { get; set; }
		public bool IsDeleted { get; set; }

		public virtual ICollection<PlayingDatum> PlayingData { get; set; }
	}
}
