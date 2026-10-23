using Force.DeepCloner.Helpers;

namespace Force.DeepCloner
{
    public delegate object PreCloneProcessor(object sourceObj, DeepCloneState deepCloneState);
}
