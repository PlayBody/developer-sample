using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> typeBindings = new Dictionary<Type, Type>();
        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("The provided interfaceType must be an interface.");
            }

            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException("The provided implementationType must implement the interfaceType.");
            }

            typeBindings[interfaceType] = implementationType;
        }
        public T Get<T>()
        {
            if (!typeBindings.TryGetValue(typeof(T), out var implementationType))
            {
                throw new InvalidOperationException($"No binding found for interface {typeof(T)}");
            }

            return (T)Activator.CreateInstance(implementationType);
        }
    }
}