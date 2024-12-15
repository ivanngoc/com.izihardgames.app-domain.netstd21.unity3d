﻿using System;
using System.Linq;
using System.Reflection;
using IziHardGames.CommonDomain.Contracts;
//using Microsoft.Extensions.DependencyInjection;
using UnityEngine.UIElements;

namespace IziHardGames.ApplicationLevel
{
    public static class RegistratorForHandler
    {
        //public static void Discover(IServiceCollection serviceCollection)
        //{
        //    var asms = AppDomain.CurrentDomain.GetAssemblies();

        //    foreach (var asm in asms)
        //    {
        //        var types = asm.GetTypes();

        //        foreach (var type in types)
        //        {
        //            if (IsDomainEventHandler(type, out Type eventType))
        //            {
        //                serviceCollection.AddSingleton(type);
        //            }
        //        }
        //    }
        //}

        public static bool IsDomainEventHandler(Type type, out Type? eventType)
        {
            if (type.IsGenericType)
            {
                var typeOfHandler = typeof(IDomainEventHandler<>);
                var interfaceType = type.GetInterfaces().Where(x => x.IsGenericType).Where(x => x.GetGenericTypeDefinition() == typeOfHandler).FirstOrDefault();
                if (interfaceType != null)
                {
                    var constructedType = typeOfHandler.MakeGenericType(type);
                    eventType = interfaceType.GetGenericArguments().First();
                    return true;
                }
            }
            eventType = null;
            return false;
        }
    }
}