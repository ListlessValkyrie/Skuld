using Skuld.Architecture;
using Skuld.Core.Dtos;
using Skuld.Core.UpdateScripts;
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

			HandleSchemaUpdates();
		}

		private void HandleSchemaUpdates()
		{
			UpdateScriptFactory.Update(this);
		}

		public int ExecuteAsTransaction(IEnumerable<string> cmdTexts)
		{
			int numRows = 0;

			connection.BeginTransaction();

			foreach(string cmdText in cmdTexts)
			{
				numRows += connection.Execute(cmdText);
			}

			connection.Commit();

			return numRows;
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

		public IEnumerable<IDatabaseVersion> GetRevisionHistory()
		{
			throw new NotImplementedException();
		}

		public IDatabaseVersion GetCurrentVersion()
		{
			string cmdText = @"SELECT revision, major, minor, patch, description FROM databaseVersion ORDER BY revision DESC LIMIT 1";

			SQLiteCommand command = connection.CreateCommand(cmdText);

			return command.ExecuteQuery<DatabaseVersionDto>()
				.FirstOrDefault(); ;
		}
	}
}
