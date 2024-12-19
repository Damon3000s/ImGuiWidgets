namespace ktsu.ImGuiWidgets;

using System.Numerics;
using ImGuiNET;
using ktsu.ImGuiStyler;

/// <summary>
/// Provides custom ImGui widgets.
/// </summary>
public static partial class ImGuiWidgets
{
	/// <summary>
	/// Displays the specified text.
	/// </summary>
	/// <param name="text">The text to display.</param>
	public static void Text(string text) => TextImpl.Show(text);

	/// <summary>
	/// Displays the specified text centered within the available space.
	/// </summary>
	/// <param name="text">The text to display.</param>
	public static void TextCentered(string text) => TextImpl.Centered(text);

	/// <summary>
	/// Displays the specified text centered horizontally within the given bounds.
	/// </summary>
	/// <param name="text">The text to display.</param>
	/// <param name="containerSize">The size of the container within which the text will be centered.</param>
	public static void TextCenteredWithin(string text, Vector2 containerSize) => TextImpl.CenteredWithin(text, containerSize);

	internal static class TextImpl
	{
		public static void Show(string text) => ImGui.TextUnformatted(text);

		public static void Centered(string text)
		{
			var textSize = ImGui.CalcTextSize(text);
			using (new Alignment.Center(textSize))
			{
				ImGui.TextUnformatted(text);
			}
		}

		public static void CenteredWithin(string text, Vector2 containerSize) => CenteredWithin(text, containerSize, false);

		public static void CenteredWithin(string text, Vector2 containerSize, bool clip)
		{
			if (clip)
			{
				text = Clip(text, containerSize);
			}

			var textSize = ImGui.CalcTextSize(text);
			using (new Alignment.CenterWithin(textSize, containerSize))
			{
				ImGui.TextUnformatted(text);
			}
		}

		public static string Clip(string text, Vector2 containerSize)
		{
			float textWidth = ImGui.CalcTextSize(text).X;
			if (textWidth <= containerSize.X)
			{
				return text;
			}

			string ellipsis = "...";
			float ellipsisWidth = ImGui.CalcTextSize(ellipsis).X;

			while (textWidth + ellipsisWidth > containerSize.X && text.Length > 0)
			{
				text = text[..^1];
				textWidth = ImGui.CalcTextSize(text).X;
			}

			return text + ellipsis;
		}
	}
}
