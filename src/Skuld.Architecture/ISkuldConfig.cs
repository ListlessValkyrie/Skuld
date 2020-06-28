﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Skuld.Architecture
{
	public interface ISkuldConfig
	{
		IEnumerable<IDatabaseVersion> GetRevisionHistory();

		IDatabaseVersion GetCurrentVersion();

		string AbsFilePath { get; }
	}
}
