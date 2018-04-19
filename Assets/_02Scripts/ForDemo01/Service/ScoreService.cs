using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void RequestScore(string url)
    {
        Debug.Log("Request score from url:" + url);
        OnReceiveScore();
    }

    public void OnReceiveScore()
    {
        int score = Random.Range(0, 100);
        dispatcher.Dispatch(Demo01ServiceEvent.RequestScore, score);
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update score to url Server:" + url + " new score:" + score);
    }
}
