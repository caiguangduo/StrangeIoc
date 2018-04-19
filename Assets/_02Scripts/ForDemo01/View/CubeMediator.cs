using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class CubeMediator : Mediator 
{
	[Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        Debug.Log("OnRegister");

        cubeView.Init();
        dispatcher.AddListener(Demo01MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.AddListener(Demo01MediatorEvent.ClickDown, OnClickDown);

        dispatcher.Dispatch(Demo01CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo01MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo01MediatorEvent.ClickDown, OnClickDown);
    }

    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo01CommandEvent.UpdateScore);
    }
}
