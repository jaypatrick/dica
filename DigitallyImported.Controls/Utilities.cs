namespace DigitallyImported.Controls
{
    using System;
    using System.Diagnostics;

	/// <summary>
	/// Static utility methods
	/// </summary>
	public class Utilities
	{
		private Utilities() { }

		/// <summary>
		/// Splits a string up based on capital letters, i.e. ThisString becomes This String
		/// </summary>
		/// <param name="name">The string to split</param>
		/// <returns></returns>
		public static string SplitName(string name)
		{
			char[] buffer = name.ToCharArray();

			foreach (char c in buffer)
			{
				if (char.IsUpper(c))
				{
					name = name.Replace(c.ToString(), " " + c.ToString());
				}
			}
			return name.Trim();
		}

		/// <summary>
		/// Starts a process based on the file extension of the string passed in
		/// </summary>
		/// <param name="processToStart">The name of the process to start</param>
		public static void StartProcess(string processToStart)
		{
			if (processToStart != null && processToStart != string.Empty)
			{
				Process.Start(processToStart);
			}
		}
    }
}
