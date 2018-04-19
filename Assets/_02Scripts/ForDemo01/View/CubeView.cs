using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;

public class CubeView : View 
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    private Text scoreText;

    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        dispatcher.Dispatch(Demo01MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
