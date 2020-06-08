using Skuld.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Core
{
	internal abstract class AbstractUpdateScript
	{
		public DbVer DbVer { get; }

		public AbstractUpdateScript(DbVer dbVer)
		{
			DbVer = dbVer ?? throw new ArgumentOutOfRangeException("dbVer");
		}

		protected abstract IEnumerable<string> Commands { get;}
	}
}
