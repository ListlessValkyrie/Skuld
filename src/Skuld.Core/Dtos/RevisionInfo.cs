using Skuld.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Core.Dtos
{
	public class RevisionInfo : IRevisionInfo
	{
		public DbVer DbVer { get; set;}

		public int Revision { get; set; }

		public DateTime Date { get; set; }

		string DBType { get; set; }

		string Description { get; set; }
	}
}
