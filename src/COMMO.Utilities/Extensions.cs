// <copyright file="Extensions.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>


namespace COMMO.Utilities {
	using System;
	using System.Collections.Generic;
	using System.Text;

	public static class Extensions {

		public static byte[] ToByteArray(this uint[] unsignedIntegers) {
			var temp = new byte[unsignedIntegers.Length * sizeof(uint)];

			for (var i = 0; i < unsignedIntegers.Length; i++) {
				Array.Copy(BitConverter.GetBytes(unsignedIntegers[i]), 0, temp, i * 4, 4);
			}

			return temp;
		}

		/// <summary>
		/// Convert a byte to a printable
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static char ToPrintableChar(this byte value) {
			if (value < 32 || value > 126) {
				return '.';
			}

			return (char)value;
		}

		/// <summary>
		/// Converts a char to a byte
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static byte ToByte(this char value) {
			return (byte)value;
		}

		/// <summary>
		/// Converts a string to a byte array
		/// </summary>
		/// <returns></returns>
		public static byte[] ToByteArray(this string s) {
			var value = new List<byte>();
			foreach (var c in s) {
				value.Add(c.ToByte());
			}

			return value.ToArray();
		}

		/// <summary>Convert a string of hex digits (ex: E4 CA B2) to a byte array.</summary>
		/// <param name="s">The string containing the hex digits (with or without spaces).</param>
		/// <returns>Returns an array of bytes.</returns>
		public static byte[] ToBytesAsHex(this string s) {
			s = s.Replace(" ", string.Empty);
			var buffer = new byte[s.Length / 2];
			for (var i = 0; i < s.Length; i += 2) {
				buffer[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
			}

			return buffer;
		}

		/// <summary>
		/// Convert a string of hex digits to a printable string of characters.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToPrintableStringAsHex(this string value) {
			byte[] temp = value.ToBytesAsHex();
			var loc = string.Empty;
			for (var i = 0; i < temp.Length; i++) {
				loc += temp[i].ToPrintableChar();
			}

			return loc;
		}

		/// <summary>
		/// Converts a integer to a hex string
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToHexString(this int value) {
			var temp = BitConverter.GetBytes(value);
			return temp.ToHexString();
		}

		/// <summary>
		/// Converts a hex string to a integer
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int ToIntAsHex(this string value) {
			byte[] bytes = value.ToBytesAsHex();
			if (bytes.Length >= 2) {
				return BitConverter.ToInt16(bytes, 0);
			}

			return int.MinValue;
		}
	}
}
