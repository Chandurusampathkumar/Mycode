using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace System.Text.TagResolvers
{
	/// <summary>
	/// this class implements <see cref="ITagResolver"/> interface
	/// </summary>
	internal class ObjectPropertyTagResolver : ITagResolver
	{
		private const string PropertyTag = "prop";

		private readonly IFormatProvider _formatProvider;
		private readonly object _value;
		private readonly Type _valueType;

		/// <summary>
		/// Initializes a new instance of the <see cref="ObjectPropertyTagResolver"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="formatProvider">The format provider.</param>
		public ObjectPropertyTagResolver(object value, IFormatProvider formatProvider = null) {
			Guard.NotNull(value, "value");
			_value = value;
			_valueType = (value is Type) ? (Type)value : value.GetType();
			_formatProvider = formatProvider;
		}

		/// <summary>
		/// Gets the list of supported tags.
		/// </summary>
		/// <value>The tags.</value>
		public IEnumerable<string> SupportedTags {
			get { yield return PropertyTag; }
		}

		/// <summary>
		/// Converts the specified tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <param name="input">The input.</param>
		/// <returns>
		/// Returns the resolved input string, or null if the input cannot be resolved.
		/// </returns>
		/// <exception cref="UnsupportedTagException"><c>UnsupportedTagException</c>.</exception>
		public string Resolve(string tag, string input) {
			if (tag.ToLower(CultureInfo.InvariantCulture) != PropertyTag) {
				throw new UnsupportedTagException(tag);
			}

			Guard.NotNullOrEmpty(input, "input");

			//look for : for a format function
			string format = string.Empty;
			int nextColon = input.IndexOf(':');
			if (nextColon >= 0) {
				format = input.Substring(nextColon + 1);
				input = input.Substring(0, nextColon);
			}

			PropertyInfo propertyInfo = _valueType.GetProperty(input,
			                                                   BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
			                                                   | BindingFlags.IgnoreCase);
			if (propertyInfo == null) {
				return null;
			}
			object propValue = propertyInfo.GetValue(_value, null);

			format = (format.Length > 0) ? string.Format("{{0:{0}}}", format) : "{0}";
			return string.Format(_formatProvider, format, propValue);
		}
	}
}