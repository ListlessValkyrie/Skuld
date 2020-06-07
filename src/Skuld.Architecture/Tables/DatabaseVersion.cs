using SQLite;

namespace Skuld.Architecture.Tables
{
	public class DatabaseVersion
	{
		public int Revision { get; set; }

		public int Major { get; set; }

		public int Minor { get; set; }

		public int Patch { get; set; }

		public string Description { get; set; }
	}
}
