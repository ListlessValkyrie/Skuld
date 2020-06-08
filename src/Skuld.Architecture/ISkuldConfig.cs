using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Architecture
{
	public interface ISkuldConfig
	{
		IEnumerable<IRevisionInfo> GetRevisionHistory();

		IRevisionInfo GetCurrentRevision();
	}
}
