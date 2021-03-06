﻿using System;
using System.Collections.Generic;

namespace DlibDotNet
{

    public sealed class ContainerBridgeRepository
    {

        #region Fields

        private static readonly Dictionary<Type, IContainerBridge> SupportTypes = new Dictionary<Type, IContainerBridge>();

        #endregion

        #region Methods

        public static void Add<T>(ContainerBridge<T> bridge)
        {
            if (bridge == null)
                throw new ArgumentNullException(nameof(bridge));

            var type = typeof(T);
            if (!SupportTypes.ContainsKey(type))
            {
                SupportTypes.Add(type, bridge);
            }
            else
            {
                SupportTypes[type] = bridge;
            }
        }

        public static ContainerBridge<T> Get<T>()
        {
            var type = typeof(T);
            if (!SupportTypes.TryGetValue(type, out var bridge))
                throw new NotSupportedException();

            return (ContainerBridge<T>)bridge;
        }

        #endregion

    }

}
