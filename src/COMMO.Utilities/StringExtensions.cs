namespace COMMO.Utilities {
	using System.Text;

	public static class StringExtensions {

		/// <summary>
		/// Repeats the specified string n times.
		/// </summary>
		/// <param name="instr">The input string.</param>
		/// <param name="n">The number of times input string
		/// should be repeated.</param>
		/// <returns></returns>
		// http://weblogs.asp.net/gunnarpeipman/archive/2009/05/13/string-repeat-smaller-and-faster-version.aspx
		public static string Repeat(this string instr, int n) {
			if (string.IsNullOrEmpty(instr)) {
				return instr;
			}

			var result = new StringBuilder(instr.Length * n);
			return result.Insert(0, instr, n).ToString();
		}
	}
}
