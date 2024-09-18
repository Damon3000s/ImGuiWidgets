namespace ktsu.ImGuiWidgets;

public static partial class ImGuiWidgets
{
	/// <summary>
	/// A zone that can be resized by dragging a divider.
	/// For use inside DividerContainer.
	/// </summary>
	public class DividerZone
	{
		/// <summary>
		/// The unique identifier for this zone.
		/// </summary>
		public string Id { get; private set; }
		/// <summary>
		/// The size of this zone.
		/// </summary>
		public float Size { get; set; }
		/// <summary>
		/// Whether this zone can be resized.
		/// </summary>
		public bool Resizable { get; } = true;
		private Action<float>? TickDelegate { get; }
		internal float InitialSize { get; init; }

		/// <summary>
		/// Create a new divider zone.
		/// </summary>
		/// <param name="id">The unique identifier for this zone.</param>
		/// <param name="size">The size of this zone.</param>
		public DividerZone(string id, float size)
		{
			Id = id;
			Size = size;
			InitialSize = size;
			Resizable = true;
		}

		/// <summary>
		/// Create a new resizable divider zone with a tick delegate.
		/// </summary>
		/// <param name="id">The unique identifier for this zone.</param>
		/// <param name="size">The size of this zone.</param>
		/// <param name="tickDelegate">The delegate to call every frame.</param>
		public DividerZone(string id, float size, Action<float> tickDelegate)
		{
			Id = id;
			Size = size;
			InitialSize = size;
			TickDelegate = tickDelegate;
		}

		/// <summary>
		/// Create a new divider zone that is optionally resizable  with a tick delegate.
		/// </summary>
		/// <param name="id">The unique identifier for this zone.</param>
		/// <param name="size">The size of this zone.</param>
		/// <param name="resizable">Whether this zone can be resized.</param>
		/// <param name="tickDelegate">The delegate to call every frame.</param>
		public DividerZone(string id, float size, bool resizable, Action<float> tickDelegate)
		{
			Id = id;
			Size = size;
			InitialSize = size;
			Resizable = resizable;
			TickDelegate = tickDelegate;
		}

		/// <summary>
		/// Create a new divider zone that is optionally resizable.
		/// </summary>
		/// <param name="id">The unique identifier for this zone.</param>
		/// <param name="size">The size of this zone.</param>
		/// <param name="resizable">Whether this zone can be resized.</param>
		public DividerZone(string id, float size, bool resizable)
		{
			Id = id;
			Size = size;
			InitialSize = size;
			Resizable = resizable;
		}

		internal void Tick(float dt) => TickDelegate?.Invoke(dt);
	}
}
