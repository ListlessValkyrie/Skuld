using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Skuld.Core.Test
{
	[TestFixture]
	public class TSkuldConfig
	{
		[Test]
		public void Init()
		{
			string tempFile = Tools.GetTempFilenameWithExtension(".sqlite");

			SkuldConfig config = new SkuldConfig(tempFile);

			StringAssert.AreEqualIgnoringCase(tempFile, config.AbsFilePath);

			System.Diagnostics.Process.Start(tempFile);
		}
	}
}
