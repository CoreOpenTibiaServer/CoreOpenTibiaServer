namespace COMMO.Server.Tests {
	using COMMO.Server.World;
	using System.Collections.Generic;
	using Xunit;

	public sealed class CoordinateTests {

		[Theory]
		[MemberData(nameof(CombinationsOfTwoOffsets))]
		public void Translate_WithTwoOffsets(int xOffset, int yOffset) {
			var startCoord = new Coordinate(
				x: 0,
				y: 0,
				z: 0);

			var translatedCoord = startCoord.Translate(
				xOffset: xOffset,
				yOffset: yOffset);

			var expectedX = startCoord.X + xOffset;
			var expectedY = startCoord.Y + yOffset;
			var expectedZ = startCoord.Z;

			Assert.Equal(
				expected: expectedX,
				actual: translatedCoord.X);

			Assert.Equal(
				expected: expectedY,
				actual: translatedCoord.Y);

			Assert.Equal(
				expected: expectedZ,
				actual: translatedCoord.Z);

		}

		public static IEnumerable<object[]> CombinationsOfTwoOffsets {
			get {
				for (int x = -1; x <= 1; x++) {
					for (int y = -1; y <= 1; y++) {
						yield return new object[] { x, y };
					}
				}
			}
		}

		[Theory]
		[MemberData(nameof(CombinationsOfThreeOffsets))]
		public void Translate_WithThreeOffsets(int xOffset, int yOffset, sbyte zOffset) {
			var startCoord = new Coordinate(
				x: 0,
				y: 0,
				z: 0);

			var translatedCoord = startCoord.Translate(
				xOffset: xOffset,
				yOffset: yOffset,
				zOffset: zOffset);

			var expectedX = startCoord.X + xOffset;
			var expectedY = startCoord.Y + yOffset;
			var expectedZ = startCoord.Z + zOffset;

			Assert.Equal(
				expected: expectedX,
				actual: translatedCoord.X);

			Assert.Equal(
				expected: expectedY,
				actual: translatedCoord.Y);

			Assert.Equal(
				expected: expectedZ,
				actual: translatedCoord.Z);

		}

		public static IEnumerable<object[]> CombinationsOfThreeOffsets {
			get {
				for (int x = -1; x <= 1; x++) {
					for (int y = -1; y <= 1; y++) {
						for (sbyte z = -1; z <= 1; z++) {
							yield return new object[] { x, y, z };
						}
					}
				}
			}
		}
	}
}
