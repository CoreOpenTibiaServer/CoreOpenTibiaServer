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

	}
}
