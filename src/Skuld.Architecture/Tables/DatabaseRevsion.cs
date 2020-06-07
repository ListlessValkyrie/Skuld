using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Architecture.Tables
{
	public class DatabaseRevision
	{
		public int revision { get; set; }

		public DateTime date { get; set; }

		public string dbType { get; set; }
	}
}
