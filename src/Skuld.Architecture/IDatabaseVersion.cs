namespace Skuld.Architecture
{
	public interface IDatabaseVersion
	{
		int Revision { get;}

		int Major { get; }

		int Minor { get; }

		int Patch { get;  }

		string Description { get; }
	}
}
