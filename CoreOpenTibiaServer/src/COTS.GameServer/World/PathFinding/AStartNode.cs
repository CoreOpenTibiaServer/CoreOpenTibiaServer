namespace COTS.GameServer.World.PathFinding {

    public sealed class AStartNode {
        public readonly uint X;
        public readonly uint Y;
        public int Priority;
        public int QueueIndex;
    }
}