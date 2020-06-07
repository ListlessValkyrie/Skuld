using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Core
{
	public static class Tools
	{ 
		public static string GetTempFilenameWithExtension(string extension = ".xxx")
		{
			if (string.IsNullOrEmpty(extension)) throw new ArgumentNullException("extension");

			return System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + extension;
		}
	}
}
