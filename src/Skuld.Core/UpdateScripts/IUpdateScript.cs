using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Core.UpdateScripts
{
	internal interface IUpdateScript
	{
		int Revision { get; }

		IEnumerable<string> UpdateCommands { get; }
	}
}
