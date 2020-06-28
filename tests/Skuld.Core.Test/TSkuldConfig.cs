using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Skuld.Architecture;

namespace Skuld.Core.Test
{
	[TestFixture]
	public class TSkuldConfig
	{
		[Test]
		public void Init()
		{
			string tempFile = Tools.GetTempFilenameWithExtension(".sqlite");

			ISkuldConfig config = new SkuldConfig(tempFile);
			StringAssert.AreEqualIgnoringCase(tempFile, config.AbsFilePath);

			System.Diagnostics.Process.Start(tempFile);
			Assert.AreEqual(0, config.GetCurrentVersion().Revision);
		}
	}
}
