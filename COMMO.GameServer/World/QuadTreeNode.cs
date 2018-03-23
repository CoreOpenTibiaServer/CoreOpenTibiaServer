namespace COMMO.GameServer.World {

	public class QuadTreeNode {
		public readonly QuadTreeNode[] Children = new QuadTreeNode[4];

		private const int SignalBit = unchecked((int)0b10000000_00000000_00000000_00000000);
		private const int XRightShift = 0b00000000_00001111;
		private const int YRightShift = 0b00000000_00001110;

		public readonly bool IsLeaf;

		protected QuadTreeNode(bool isLeaf) {
			IsLeaf = isLeaf;
		}

		public QuadTreeNode()
			: this(isLeaf: false) { }

		public bool TryGetLeaf(int x, int y, out QuadTreeLeafNode leaf) {
			if (IsLeaf) {
				leaf = (QuadTreeLeafNode)this;
				return true;
			}

			var node = Children[ComputeChildrenIndex(x, y)];
			if (node != null)
				return node.TryGetLeaf(x << 1, y << 1, out leaf);

			// Node not created yet
			leaf = null;
			return false;
		}

		public QuadTreeLeafNode CreateLeafOrGetReference(int leafXCoordinate, int leafYCoordinate, int leaftZoomLevel) {
			if (IsLeaf)
				return (QuadTreeLeafNode)this;

			var childIndex = ComputeChildrenIndex(leafXCoordinate, leafYCoordinate);

			if (Children[childIndex] == null) {
				// Oughta create a new child
				if (leaftZoomLevel == Floor.FloorBits) {
					Children[childIndex] = new QuadTreeLeafNode();
				} else {
					Children[childIndex] = new QuadTreeNode();
				}
			} else {
				// Child is already not null, no need to do anything
			}

			return Children[childIndex].CreateLeafOrGetReference(leafXCoordinate << 1, leafYCoordinate << 1, leaftZoomLevel - 1);
		}

		/// <remarks>
		/// If <paramref name="x"/> >= 0, then 
		/// (<paramref name="x"/> & <see cref="SignalBit"/>) >> <see cref="XRightShift"/> 
		/// ==
		/// 0b00000000_00000000_00000000_00000000
		/// else
		/// 0b00000000_00000000_00000000_00000001
		/// 
		/// If <paramref name="y"/> >= 0, then
		/// (<paramref name="y"/> & <see cref="SignalBit"/>) >> <see cref="YRightShift"/>
		/// ==
		/// 0b00000000_00000000_00000000_00000000
		/// else
		/// 0b00000000_00000000_00000000_00000010
		/// 
		/// Therefore, if <paramref name="x"/> >=   0 and <paramref name="y"/> >=   0, return 0
		/// else,      if <paramref name="x"/> ==   0 and <paramref name="y"/> &lt  0, return 3
		/// else,	   if <paramref name="x"/> &lt  0 and <paramref name="y"/> >=   0, return 1
		/// else	      <paramref name="x"/> &lt  0 and <paramref name="y"/> &lt  0, return 2
		/// </remarks>
		private static int ComputeChildrenIndex(int x, int y) {
			return
				((x & SignalBit) >> XRightShift)
				|
				((y & SignalBit) >> YRightShift);
		}
	}
}