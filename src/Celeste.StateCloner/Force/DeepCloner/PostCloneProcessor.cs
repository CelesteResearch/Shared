using Force.DeepCloner.Helpers;

namespace Force.DeepCloner
{
    public delegate object PostCloneProcessor(object sourceObj, object clonedObj, DeepCloneState deepCloneState);
}
