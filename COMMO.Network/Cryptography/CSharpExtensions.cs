using System;
using System.IO;
using System.Numerics;

namespace COMMO.Network.Cryptography {

	public static class CSharpExtensions {

		public static BigInteger ModInverse(this BigInteger a, BigInteger n) {
			BigInteger i = n, v = 0, d = 1;
			while (a > 0) {
				BigInteger t = i / a, x = a;
				a = i % x;
				i = x;
				x = d;
				d = v - t * x;
				v = x;
			}
			v %= n;
			if (v < 0)
				v = (v + n) % n;
			return v;
		}

		public static void MemSet<T>(this T[] a, int index, T value, int num) {
			for (int i = 0; i < num; i++) {
				a[index + i] = value;
			}
		}

		public static void MemCpy<T>(this T[] destination, int index, T[] source, int num) {
			for (int i = 0; i < num; i++) {
				destination[index + i] = source[i];
			}
		}

		public static ushort ReadUInt16(this MemoryStream stream) {
			byte[] buffer = new byte[sizeof(ushort)];
			stream.Read(buffer, 0, buffer.Length);
			return BitConverter.ToUInt16(buffer, 0);
		}

		public static byte[] ReadBytes(this MemoryStream stream, int length) {
			byte[] buffer = new byte[length];
			stream.Read(buffer, 0, buffer.Length);
			return buffer;
		}
	}
}
