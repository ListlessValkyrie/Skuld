using Skuld.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Core.UpdateScripts
{
	internal abstract class AbstractUpdateScript : IUpdateScript
	{
		public int Revision { get; } = -1;

		public abstract IEnumerable<string> UpdateCommands { get; }

		public AbstractUpdateScript(int revision)
		{
			Revision = revision;
		}
	}
}
