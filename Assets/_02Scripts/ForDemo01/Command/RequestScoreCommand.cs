using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class RequestScoreCommand : EventCommand 
{
	[Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScoreModel scoreModel { get; set; }

    public override void Execute()
    {
        Retain();
        scoreService.dispatcher.AddListener(Demo01ServiceEvent.RequestScore,OnCompolete);
        scoreService.RequestScore("http://xx//xxx//xxxx");
    }

    private void OnCompolete(IEvent evt)
    {
        Debug.Log("Request score compolete " + evt.data);
        scoreService.dispatcher.RemoveListener(Demo01ServiceEvent.RequestScore, OnCompolete);

        scoreModel.Score = (int)evt.data;
        dispatcher.Dispatch(Demo01MediatorEvent.ScoreChange, evt.data);

        Release();
    }
}
