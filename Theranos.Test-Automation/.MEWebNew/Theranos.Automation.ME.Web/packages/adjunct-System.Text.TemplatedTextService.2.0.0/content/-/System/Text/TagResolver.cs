using System.Collections.Generic;

namespace System.Text
{
	/// <summary>
	/// Tag Resolver Interface
	/// </summary>
	internal interface ITagResolver
	{
		/// <summary>
		/// Gets the list of supported tags.
		/// </summary>
		/// <value>The tags.</value>
		IEnumerable<string> SupportedTags { get; }

		/// <summary>
		/// Converts the specified tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <param name="input">The input.</param>
		/// <returns>Returns the resolved input, or null if the input cannot be resolved.</returns>
		string Resolve(string tag, string input);
	}

	/// <summary>
	/// This class defines the exceptions thrown when tag of string is not supported
	/// </summary>
	internal class UnsupportedTagException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnsupportedTagException"/> class.
		/// </summary>
		/// <param name="tag">The tag.</param>
		public UnsupportedTagException(string tag)
			: base(string.Format("Unsupported tag: {0}", tag))
		{
			Tag = tag;
		}

		/// <summary>
		/// Gets or sets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public string Tag { get; private set; }
	}

	/// <summary>
	/// This class defines the exceptions thrown when input tag of string is not supported
	/// </summary>
	internal class UnsupportedTagInputException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UnsupportedTagInputException"/> class.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <param name="input">The input.</param>
		public UnsupportedTagInputException(string tag, string input)
			: base(string.Format("Unsupported input [{0}] for tag [{1}]", input, tag))
		{
			Tag = tag;
			Input = input;
		}

		/// <summary>
		/// Gets the input.
		/// </summary>
		/// <value>The input.</value>
		public string Input { get; private set; }

		/// <summary>
		/// Gets the tag.
		/// </summary>
		/// <value>The tag.</value>
		public string Tag { get; private set; }
	}
}