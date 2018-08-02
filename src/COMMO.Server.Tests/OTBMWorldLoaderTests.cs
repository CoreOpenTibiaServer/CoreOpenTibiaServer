namespace COMMO.Server.Tests {
	using NUnit.Framework;
	using Server.World;
	using System;
	using System.IO;

	[TestFixture]
	public sealed class OTBMWorldLoaderTests {
		public const int OTBMIdentifierLength = 4;
		public enum Worlds { Empty, DirtAndMexcalibur }

		[Test]
		public void LoadEmptyWorld() {
			var rawData = GetSerializedWorldData(Worlds.Empty);
			var relevantData = rawData.Slice(OTBMIdentifierLength);
			var parsingTree = OTBMWorldLoader.LoadWorld(relevantData);

			throw new NotImplementedException();
		}

		[Test]
		public void LoadWorldWIthDirtAndMexcalibur() {
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

				case Worlds.DirtAndMexcalibur:
				return File.ReadAllBytes(Path.Combine(testWorldsDirectory, "DirtAndMexcalibur.otbm"));


				default:
				throw new InvalidOperationException();
			}
		}
	}
}

