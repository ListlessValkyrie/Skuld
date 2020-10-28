using System.Collections.Generic;

namespace Skuld.Core.UpdateScripts
{
	internal class Update000 : AbstractUpdateScript
	{
		public Update000()
			:base(0)
		{
		}

		public override IEnumerable<string> UpdateCommands { get; } = new string[]
		{
			"INSERT INTO databaseRevision('revision', 'dbType') VALUES(0, 'SkuldDB')",
			"INSERT INTO databaseVersion('revision', 'major', 'minor', 'patch', 'description') VALUES(0, 1, 0, 0, 'Base functionality')"
		};
	}
}
