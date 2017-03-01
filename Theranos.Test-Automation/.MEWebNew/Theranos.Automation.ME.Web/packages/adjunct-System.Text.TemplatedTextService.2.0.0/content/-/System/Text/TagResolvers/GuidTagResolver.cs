using System.Collections.Generic;
using System.Globalization;

namespace System.Text.TagResolvers
{
	/// <summary>
	/// this class implements <see cref="ITagResolver"/> interface
	/// </summary>
	internal class GuidTagResolver : ITagResolver
	{
		private const string GuidTag = "guid";

		private readonly Dictionary<string, string> _namedGuids = new Dictionary<string, string>();
		private string _last = Guid.Empty.ToString();

		/// <summary>
		/// Gets the list of supported tags.
		/// </summary>
		/// <value>The tags.</value>
		public IEnumerable<string> SupportedTags {
			get { yield return GuidTag; }
		}

		/// <summary>
		/// Converts the specified tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <param name="input">The input.</param>
		/// <returns>a <see cref="string"/></returns>
		/// <exception cref="UnsupportedTagException"><c>UnsupportedTagException</c>.</exception>
		public string Resolve(string tag, string input) {
			if (tag.ToLower(CultureInfo.InvariantCulture) != GuidTag) {
				throw new UnsupportedTagException(tag);
			}

			switch (input.ToLower(CultureInfo.InvariantCulture)) {
				case "new":
					_last = Guid.NewGuid().ToString().ToUpper();
					return _last;

				case "last":
					return _last;

				default:
					if (!_namedGuids.ContainsKey(input)) {
						_namedGuids.Add(input, Guid.NewGuid().ToString().ToUpper());
					}
					return _namedGuids[input];
			}
		}
	}
}