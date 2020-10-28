using System.Collections.Generic;

namespace Skuld.Architecture
{
    public interface ISkuldDB
	{
		IEnumerable<IDatabaseVersion> GetRevisionHistory();

		IDatabaseVersion GetCurrentVersion();

		string AbsFilePath { get; }
	}
}
