using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Celeste.Core.Components;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Modules.Updating;
using Celeste.Formats.Map.Binary.Source;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Scene.Following;

namespace Celeste.Everest.Content.Extensions.Collectibles
{
// The installed registry's static state belongs to one actual process instance.
    public class InstalledStrawberryRegistryState
    {
        public class RegisteredBerry
        {
            public Type berryClass;
            public string entityName;
            public bool isTracked;
            public bool blocksNormalCollection;

            public RegisteredBerry(Type type, string name, bool tracked, bool blockCollect)
            {
                berryClass = type;
                entityName = name;
                isTracked = tracked;
                blocksNormalCollection = blockCollect;
            }
        }

        private readonly HashSet<RegisteredBerry> registeredBerries;
        private ReadOnlyCollection<RegisteredBerry> getRegisteredBerries;
        private ReadOnlyCollection<RegisteredBerry> getTrackableBerries;
        private ReadOnlyCollection<Type> getBerryTypes;
        private ReadOnlyCollection<string> getBerryNames;
        private HashSet<string> trackedBerryNames;
        private HashSet<string> berryNamesHashSet;

        public InstalledStrawberryRegistryState()
        {
            registeredBerries =
            [
                new(typeof(OriginalStrawberryState), "strawberry", true, false),
                new(typeof(OriginalStrawberryState), "goldenBerry", false, true),
                new(typeof(OriginalStrawberryState), "memorialTextController", false, true),
            ];
        }

        public ReadOnlyCollection<RegisteredBerry> GetRegisteredBerries()
        {
            if (getRegisteredBerries == null)
                getRegisteredBerries = registeredBerries.ToList().AsReadOnly();
            return getRegisteredBerries;
        }

        public ReadOnlyCollection<RegisteredBerry> GetTrackableBerries()
        {
            if (getTrackableBerries == null)
                getTrackableBerries = registeredBerries.ToList().FindAll(berry => berry.isTracked).AsReadOnly();
            return getTrackableBerries;
        }

        public ReadOnlyCollection<Type> GetBerryTypes()
        {
            if (getBerryTypes == null)
            {
                var types = new List<Type>();
                foreach (var berry in registeredBerries)
                    if (!types.Contains(berry.berryClass))
                        types.Add(berry.berryClass);
                getBerryTypes = types.AsReadOnly();
            }

            return getBerryTypes;
        }

        public ReadOnlyCollection<string> GetBerryNames()
        {
            if (getBerryNames == null)
            {
                var names = new List<string>(registeredBerries.Count);
                foreach (var berry in registeredBerries)
                    names.Add(berry.entityName);
                getBerryNames = names.AsReadOnly();
            }

            return getBerryNames;
        }

        public void Register(Type type, string entityName, bool tracked, bool blocksNormalCollection)
        {
            registeredBerries.Add(new(type, entityName, tracked, blocksNormalCollection));
            InvalidateRegistrationViews();
        }

        public IDisposable RegisterOwned(Type type, string entityName, bool tracked, bool blocksNormalCollection)
        {
            var berry = new RegisteredBerry(type, entityName, tracked, blocksNormalCollection);
            registeredBerries.Add(berry);
            InvalidateRegistrationViews();
            return new RegistrationUndo(() =>
            {
                if (registeredBerries.Remove(berry)) InvalidateRegistrationViews();
            });
        }

        private void InvalidateRegistrationViews()
        {
            getRegisteredBerries = null;
            getTrackableBerries = null;
            getBerryTypes = null;
            getBerryNames = null;
            trackedBerryNames = null;
            berryNamesHashSet = null;
        }

        public void Register(Type type, bool tracked, bool blocksNormalCollection)
        {
            if (Attribute.IsDefined(type, typeof(CustomEntityAttribute)))
            {
                var ids =
                    (Attribute.GetCustomAttribute(type, typeof(CustomEntityAttribute)) as CustomEntityAttribute)
                    .IDs;
                for (var i = 0; i < ids.Length; i++)
                    Register(type, ids[i], tracked, blocksNormalCollection);
            }
        }

        public bool TrackableContains(string name)
        {
            if (trackedBerryNames == null)
                trackedBerryNames = /* ReSharper disable once UseCollectionExpression */
                    GetTrackableBerries().Select(berry => berry.entityName).ToHashSet();
            return trackedBerryNames.Contains(name);
        }

        public bool TrackableContains(BinaryPackerElement element)
        {
            if (element.AttrBool("moon"))
                return false;
            return TrackableContains(element.Name);
        }

        public bool IsRegisteredBerry(string name)
        {
            if (berryNamesHashSet == null)
                berryNamesHashSet = /* ReSharper disable once UseCollectionExpression */ GetBerryNames().ToHashSet();
            return berryNamesHashSet.Contains(name);
        }

        public bool IsFirstStrawberry(ISourceOwnedComponentList entity)
        {
            var follower = entity.OwnedComponents.Get<FollowerState>();
            if (follower == null)
                return false;
            var berries = registeredBerries.ToList();
            var types = GetBerryTypes();
            for (var i = follower.FollowIndex - 1; i >= 0; i--)
            {
                // Preserve the per-iteration predicate capture before the first lookup.
                var match = new BerryTypeMatch();
                var previous = follower.Leader.Followers[i].Entity;
                match.type = previous.GetType();
                var berry = berries.Find(match.Matches);
                _ = types.Contains(previous.GetType());
                var blocks = false;
                if (berry != null)
                    blocks = berry.blocksNormalCollection;
                var golden = false;
                if (previous is OriginalStrawberryState)
                    golden = (previous as OriginalStrawberryState).Golden;
                if (types.Contains(previous.GetType()) && !blocks && !golden)
                    return false;
            }

            return true;
        }

        private sealed class BerryTypeMatch
        {
            public Type type;

            public bool Matches(RegisteredBerry berry)
            {
                return berry.berryClass == type;
            }
        }
    }
}
