using Skuld.Architecture;

namespace Skuld.Core.Dtos
{
	public class DatabaseVersionDto : IDatabaseVersion
	{
		public int Revision { get; set; }
	
		public int Major { get; set; }

		public int Minor { get; set; }

		public int Patch { get; set; }

		public string Description { get; set; }
	}
}
