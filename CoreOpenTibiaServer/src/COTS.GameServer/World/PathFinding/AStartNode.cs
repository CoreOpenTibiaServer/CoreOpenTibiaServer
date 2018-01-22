namespace COTS.GameServer.World.PathFinding {

    public sealed class AStartNode {
        public readonly uint X;
        public readonly uint Y;
        public float Priority;
        public int QueueIndex;
    }
}