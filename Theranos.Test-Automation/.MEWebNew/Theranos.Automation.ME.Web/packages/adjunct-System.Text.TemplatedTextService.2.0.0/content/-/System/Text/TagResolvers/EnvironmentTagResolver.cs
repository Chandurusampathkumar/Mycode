using System.Collections.Generic;
using System.Globalization;

namespace System.Text.TagResolvers
{
	/// <summary>
	/// this class implements <see cref="ITagResolver"/> interface
	/// </summary>
	internal class EnvironmentTagResolver : ITagResolver
	{
		private const string EnvironmentTag = "env";

		/// <summary>
		/// Gets the list of supported tags.
		/// </summary>
		/// <value>The tags.</value>
		public IEnumerable<string> SupportedTags {
			get { yield return EnvironmentTag; }
		}

		/// <summary>
		/// Converts the specified tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <param name="input">The input.</param>
		/// <returns>a <see cref="string"/></returns>
		/// <exception cref="UnsupportedTagException"><c>UnsupportedTagException</c>.</exception>
		public string Resolve(string tag, string input) {
			if (tag.ToLower(CultureInfo.InvariantCulture) != EnvironmentTag) {
				throw new UnsupportedTagException(tag);
			}

			switch (input.ToLower(CultureInfo.InvariantCulture)) {
				case "date":
					return DateTime.Today.ToShortDateString();

				case "time":
					return DateTime.Now.ToShortTimeString();

#if !CompactFramework && !SILVERLIGHT
				case "user":
					return Environment.UserName;

				case "machine":
					return Environment.MachineName;

				default:
					return Environment.GetEnvironmentVariable(input);
#else
				default:
					return null;
#endif
			}
		}
	}
}