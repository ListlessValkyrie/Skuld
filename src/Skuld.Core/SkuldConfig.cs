using Skuld.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skuld.Core
{
	public static class SkuldConfig
	{
		private static ISkuldDB skuldDB = null;

		public static void Configure(string absFilePath)
		{
			skuldDB = new SkuldDB(absFilePath);
		}

		public static T AddOrUpdate<T>(string key, T value)
		{
			if (skuldDB == null) 
				throw new InvalidOperationException("SkuldConfig is not configured, run Configure() first");

			throw new NotImplementedException();
		}

		public static T GetOrAdd<T>(string key, T value)
		{
			if (skuldDB == null) 
				throw new InvalidOperationException("SkuldConfig is not configured, run Configure() first");

			throw new NotImplementedException();
		}
	}
}
