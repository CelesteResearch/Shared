namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private global::Celeste.Core.Mathematics.ISourceVectorArithmetic VectorArithmetic =>
            ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engineContext).VectorArithmetic;
    }
}
