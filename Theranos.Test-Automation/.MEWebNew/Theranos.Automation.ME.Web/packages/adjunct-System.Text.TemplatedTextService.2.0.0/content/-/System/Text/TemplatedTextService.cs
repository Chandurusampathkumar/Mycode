using System.Collections.Generic;
using System.Linq;
using System.Text.TagResolvers;

namespace System.Text
{
	/// <summary>
	/// this class implements a simple text templating engine
	/// </summary>
	internal sealed class TemplatedTextService : IDisposable
	{
		private const string EndToken = "}";
		private const string StartToken = "{$";

		private readonly Dictionary<string, string> _replacements = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

		private readonly Dictionary<string, ITagResolver> _tagResolvers =
			new Dictionary<string, ITagResolver>(StringComparer.InvariantCultureIgnoreCase);

		/// <summary>
		/// Initializes the <see cref="TemplatedTextService"/> class.
		/// </summary>
		public TemplatedTextService() {
			RegisterDefaultProviders();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TemplatedTextService"/> class.
		/// </summary>
		/// <param name="providers">The providers.</param>
		public TemplatedTextService(params ITagResolver[] providers)
			: this() {
			Guard.NotNull(providers, () => providers);
			foreach (ITagResolver provider in providers) {
				RegisterTagResolver(provider);
			}
			RegisterDefaultProviders();
		}

		/// <summary>
		/// Adds the replacement.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void AddReplacement(string key, string value) {
			Guard.NotNull(key, () => key);
			Guard.NotNull(value, () => value);
			_replacements.Add(key, value);
		}

		/// <summary>
		/// Clears the replacements.
		/// </summary>
		public void ClearReplacements() {
			_replacements.Clear();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose() {
			//? GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Registers the string tag provider.
		/// </summary>
		/// <param name="tagResolver">The tag resolver.</param>
		public void RegisterTagResolver(ITagResolver tagResolver) {
			foreach (string supportedTag in tagResolver.SupportedTags) {
				_tagResolvers[supportedTag] = tagResolver;
			}
		}

		/// <summary>
		/// Removes the replacement.
		/// </summary>
		/// <param name="key">The key.</param>
		public void RemoveReplacement(string key) {
			_replacements.Remove(key);
		}

		/// <summary>
		/// Parses the specified input.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="customReplacements">The custom replacements.</param>
		/// <returns>a resolved string</returns>
		public string Process(string input, IDictionary<string, string> customReplacements = null) {
			//todo: allow nested recursive evaluation? <- implement via start brace stack?
			//this is single pass replacement for now.

			if (string.IsNullOrEmpty(input)) {
				return input;
			}

			StringBuilder output = null;
			int position = 0;
			while (position < input.Length) {
				int start = input.IndexOf(StartToken, position);
				if (start < 0) {
					if (output == null) {
						return input;
					}
					//remaining data after last EndToken
					output.Append(input, position, input.Length - position);
					position = input.Length;
				} else {
					int end = input.IndexOf(EndToken, start + 1);
					if (end < 0) {
						if (output == null) {
							return input;
						}
						//remaining data after last EndToken
						output.Append(input, position, input.Length - position);
						position = input.Length;
						//return output.ToString();
					} else {
						string property = input.Substring(start + 2, end - start - 2);
						string replacement = GetReplacement(property, customReplacements);

						if (output == null) {
							//simple single replacement check
							if ((start == 0) && (end == input.Length - 1)) {
								return replacement ?? input;
							}
							output = new StringBuilder();
						}

						output.Append(input, position, start - position);
						if (replacement != null) {
							output.Append(replacement);
						} else {
							output.Append(input, start, end - start + 1);
						}
						position = end + 1;
					}
				}
			}

			return output.ToString();
		}

		/// <summary>
		/// Resolves the specified inputs.
		/// </summary>
		/// <param name="inputs">The inputs.</param>
		/// <param name="customReplacements">The custom replacements.</param>
		/// <returns></returns>
		public IEnumerable<string> Process(IEnumerable<string> inputs, IDictionary<string, string> customReplacements = null) {
			return inputs.Select(input => Process(input, customReplacements));
		}

		/// <summary>
		/// Unregisters the string tag provider.
		/// </summary>
		/// <param name="tagResolver">The tag resolver.</param>
		public void UnRegisterTagResolver(ITagResolver tagResolver) {
			foreach (string supportedTag in tagResolver.SupportedTags.Where(s => _tagResolvers.ContainsKey(s)))
			{
				ITagResolver registered = _tagResolvers[supportedTag];
				if ((registered != null) && (registered == tagResolver)) {
					_tagResolvers.Remove(supportedTag);
				}
			}
		}

		/// <summary>
		/// Gets the replacement string from the dictionary of string type.
		/// </summary>
		/// <param name="replaceMe">The replace me.</param>
		/// <param name="customReplacements">The custom replacements.</param>
		/// <returns>replaced string</returns>
		private string GetReplacement(string replaceMe, IDictionary<string, string> customReplacements) {
			if ((customReplacements != null) && (customReplacements.ContainsKey(replaceMe))) {
				return customReplacements[replaceMe];
			}

			if (_replacements.ContainsKey(replaceMe)) {
				return _replacements[replaceMe];
			}

			int colon = replaceMe.IndexOf(':');
			if (colon <= 0) {
				return null;
			}
			string tag = replaceMe.Substring(0, colon);
			string input = replaceMe.Substring(colon + 1);
			if (_tagResolvers.ContainsKey(tag)) {
				return _tagResolvers[tag].Resolve(tag, input);
			}

			return null;
		}

		private void RegisterDefaultProviders() {
			RegisterTagResolver(new EnvironmentTagResolver());
			RegisterTagResolver(new GuidTagResolver());
		}
	}
}