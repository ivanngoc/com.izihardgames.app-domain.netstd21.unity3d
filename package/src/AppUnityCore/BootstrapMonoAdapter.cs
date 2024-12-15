//using System;
//using System.Linq;
//using IziHardGames.AppConstructor;
//using IziHardGames.ApplicationLevel;
//using IziHardGames.Apps.Abstractions.Lib;
//using IziHardGames.CommonDomain.Contracts;
//using IziHardGames.CommonDomain.Events;
//using Microsoft.Extensions.DependencyInjection;
using IziHardGames.Attributes;
using UnityEngine;

namespace IziHardGames.Apps.ForUnity
{
    [Bootstrap]
    //[RequireComponent(typeof(StartupArguments))]
    //[RequireComponent(typeof(AbstractAppFactory))]
    public sealed class BootstrapMonoAdapter : MonoBehaviour
    {
//        private IziApp? app;
//        //[Header("Startup")]
//        //[SerializeField] private StartupMono? startup;
//        //[SerializeField] private ScriptableStartup? startupScriptable;
//        //[SerializeField] private StartupArguments? arguments;
//        //[Header("Presets")]
//        //[SerializeField] private ProjectPresets? presets;
//        //[Space]
//        //[Header("App")]
//        //[SerializeField] private AbstractAppFactory? factory;
//        //[Space]
//        //[Header("Enter Point")]
//        //[SerializeField] private ScriptableEnterPoint? scriptableEnterPoint;
//        //[SerializeField] private AbstractUnityEnterPointMono? unityEnterPointMono;
//        //[Space]
//        [SerializeField] private IziAppScheme scheme;
//        [SerializeField] private bool isAsyncStartup = true;

//        //public ProjectPresets Presets => presets!;

//        private async void Awake()
//        {
//#if UNITY_EDITOR 
//            //GetComponent<MonoCleanup>()?.Cleanup(); //static class IziHardGames.Apps.ForUnity./
//#endif
//            if (isAsyncStartup)
//            {
//                IziAppBuilder builder = new IziAppBuilder(scheme);
//                var app = builder.Build((x) =>
//                  {
//                      var services = (x as IServiceCollection) ?? throw new InvalidCastException(x.GetType().AssemblyQualifiedName);
//                      RegistratorForHandler.Discover(services);
//                      services.AddSingleton<IDomainEventPublisher, DomainEventPublisher>();

//                      var asms = AppDomain.CurrentDomain.GetAssemblies();
//                      foreach (var asm in asms)
//                      {
//                          var startups = asm.GetTypes().Where(x => x.GetInterfaces().Any(y => y == typeof(IStartup))).Select(x => x as IStartup);
//                          foreach (var startup in startups)
//                          {
//                              startup!.ConfigureStartup(x);
//                          }
//                      }
//                  });

//                var sp = (app.ServiceProvider as IIziServiceProvider);
//                var eventBus = sp.GetRequiredService<IDomainEventPublisher>();
//                var domEvent = new DomainEventOnAppBuilded();
//                eventBus.Publish(domEvent);

//                //                //IIziAppBuilder.Singleton = builder;

//                //                Task earlyStartupMono = Task.CompletedTask;
//                //                Task earlyStartupScriptable = Task.CompletedTask;

//                //                if (startup != null)
//                //                {
//                //                    earlyStartupMono = startup.StartAsync(builder);
//                //                }

//                //                if (startupScriptable != null)
//                //                {
//                //                    earlyStartupScriptable = startupScriptable.StartAsync(builder, this.gameObject, arguments!);
//                //                }
//                //                await Task.WhenAll(earlyStartupMono, earlyStartupScriptable).ConfigureAwait(true);

//                //                Task lateStartupMono = Task.CompletedTask;
//                //                Task lateStartupScriptable = Task.CompletedTask;

//                //                if (startup != null)
//                //                {
//                //                    lateStartupMono = startup.LateStartupAsync();
//                //                }
//                //                if (startupScriptable != null)
//                //                {
//                //                    lateStartupScriptable = startupScriptable.LateStartupAsync();
//                //                }
//                //                await Task.WhenAll(lateStartupMono, lateStartupScriptable).ConfigureAwait(true);

//                //                var app = await factory!.CreateAsync(builder).ConfigureAwait(true);

//                //                //startup?.FinishStartup(app);
//                //                //startupScriptable?.FinishStartup(app);
//                //                //IStartup.FinishStartupGlobal();
//                //#if UNITY_EDITOR||DEBUG
//                //                Debug.Log("Startup funished", this);
//                //#endif
//                //                await app.StartAsync().ConfigureAwait(true);
//                //#if UNITY_EDITOR || DEBUG
//                //                Debug.Log("App Started Async", this);
//                //#endif
//                //                if (scriptableEnterPoint != null)
//                //                {
//                //                    scriptableEnterPoint.Run();
//                //                }
//                //                if (unityEnterPointMono != null)
//                //                {
//                //                    await unityEnterPointMono.RunAsync();
//                //                }
//            }
//            else
//            {
//                throw new System.NotImplementedException();
//            }
//        }

//        public void OnValidate()
//        {
//            //startup = GetComponent<StartupMono>();
//            //if (startup == null && startupScriptable == null)
//            //{
//            //    Debug.LogError($"Startup is Empty. You must specify Startup!", this);
//            //}
//            //factory = factory ?? GetComponent<AbstractAppFactory>();
//        }
    }
}