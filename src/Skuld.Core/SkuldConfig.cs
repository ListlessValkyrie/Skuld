using Skuld.Architecture;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skuld.Core
{
	public class SkuldConfig : ISkuldConfig
	{
		public string AbsFilePath { get; }

		private SQLiteConnection connection = null;

		public SkuldConfig(string absFilePath)
		{
			if (string.IsNullOrEmpty(absFilePath)) throw new ArgumentOutOfRangeException("absFilePath");

			AbsFilePath = absFilePath;
			HandleStartup();
		}

		private void HandleStartup()
		{
			//if (!File.Exists(AbsFilePath)) throw new ArgumentOutOfRangeException("absFilePath", "File does not exist");

			connection = new SQLiteConnection(AbsFilePath);

			if (!connection.GetTableInfo("databaseRevision").Any()) HandleCreateBaseTables();
		}

		public int ExecuteNonQuery(string cmdText)
		{
			SQLiteCommand command = connection.CreateCommand(cmdText);
			return command.ExecuteNonQuery();
		}

		private void HandleCreateBaseTables()
		{
			List<string> commands = new List<string>
			{
				"CREATE TABLE databaseRevision('revision' INTEGER NOT NULL, 'date' DATETIME DEFAULT current_timestamp, 'dbType' TEXT NOT NULL, PRIMARY KEY('revision'))",
				"CREATE TABLE databaseVersion('revision' INTEGER NOT NULL, 'major' INTEGER NOT NULL, 'minor' INTEGER NOT NULL, 'patch' INTEGER NOT NULL, 'description' TEXT, FOREIGN KEY('revision') REFERENCES 'databaseRevision' ('revision') ON DELETE CASCADE)",

				"CREATE VIEW DatabaseHistory AS SELECT databaseRevision.revision 'Revision', databaseRevision.date 'Date', databaseRevision.dbType 'DbType', databaseVersion.major 'Major', databaseVersion.minor 'Minor', databaseVersion.patch 'Patch', databaseVersion.description 'Description' FROM databaseVersion INNER JOIN databaseRevision ON databaseRevision.revision = databaseVersion.revision",

				"INSERT INTO databaseRevision('revision', 'dbType') VALUES(-1, 'AbstractDB')",
				"INSERT INTO databaseVersion('revision', 'major', 'minor', 'patch', 'description') VALUES(-1, 0, 0, 0, 'Initializing')"
			};

			foreach(string cmdText in commands)
			{
				ExecuteNonQuery(cmdText);
			}
		}

		public IEnumerable<IRevisionInfo> GetRevisionHistory()
		{
			throw new NotImplementedException();
		}

		public IRevisionInfo GetCurrentRevision()
		{
			string cmdText = @"";

			SQLiteCommand command = connection.CreateCommand(cmdText);

			throw new NotImplementedException();
		}
	}
}
