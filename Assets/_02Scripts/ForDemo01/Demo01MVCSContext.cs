using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class Demo01MVCSContext : MVCSContext 
{
    public Demo01MVCSContext(MonoBehaviour view) : base(view)
    { }

    protected override void mapBindings()
    {
        Debug.Log("mapBindings");

        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

        commandBinder.Bind(Demo01CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo01CommandEvent.UpdateScore).To<UpdateScoreCommand>();

        mediationBinder.Bind<CubeView>().To<CubeMediator>();

        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
