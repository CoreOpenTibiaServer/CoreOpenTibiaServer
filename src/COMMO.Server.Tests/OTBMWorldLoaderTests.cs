namespace COMMO.Server.Tests {
	using NUnit.Framework;
	using Server.World;
	using System;
	using System.IO;

	[TestFixture]
	public sealed class OTBMWorldLoaderTests {
		public const int OTBMIdentifierLength = 4;
		public enum Worlds { Empty }

		[Test]
		public void LoadEmptyWorld() {
			var rawData = GetSerializedWorldData(Worlds.Empty);
			var relevantData = rawData.Slice(OTBMIdentifierLength);
			var parsingTree = OTBMWorldLoader.LoadWorld(relevantData);
		}

		public static Memory<byte> GetSerializedWorldData(Worlds world) {
			var testWorldsDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory,
			"..", "..", "..", "..", "OTBMTestWorlds");

			switch (world) {
				case Worlds.Empty:
				return File.ReadAllBytes(Path.Combine(testWorldsDirectory, "Empty.otbm"));

				default:
				throw new InvalidOperationException();
			}
		}
	}
}

