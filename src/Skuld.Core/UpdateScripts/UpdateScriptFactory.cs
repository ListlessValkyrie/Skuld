using Skuld.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Skuld.Core.UpdateScripts
{
	internal static class UpdateScriptFactory
	{
		public static readonly List<IUpdateScript> UpdateScripts = new List<IUpdateScript>()
		{
			new Update000()
		};

		public static int LatestRevision() => UpdateScripts.Last().Revision;

		private static void HandleRunUpdates(SkuldDB skuldConfig, int currentRevision)
		{
			foreach(IUpdateScript updateScript in UpdateScripts)
			{
				if (updateScript.Revision <= currentRevision)
					continue;

				ApplyUpdateScript(skuldConfig, updateScript);
			}
		}

		private static int ApplyUpdateScript(SkuldDB skuldConfig, IUpdateScript updateScript)
		{
			return skuldConfig.ExecuteAsTransaction(updateScript.UpdateCommands);
		}

		public static void Update(this SkuldDB skuldConfig)
		{
			if (skuldConfig == null) 
				throw new ArgumentNullException("skuldConfig");

			int currentRevision = skuldConfig.GetCurrentVersion().Revision;

			if (currentRevision < LatestRevision())			
				HandleRunUpdates(skuldConfig, currentRevision);
		}
	}
}
