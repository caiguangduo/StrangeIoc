using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

public interface IScoreService 
{
    IEventDispatcher dispatcher { get; set; }

    /// <summary>
    /// 向服务器端取得数据
    /// </summary>
    /// <param name="url"></param>
    void RequestScore(string url);
    /// <summary>
    /// 收到从服务器端传回的数据
    /// </summary>
    void OnReceiveScore();
    /// <summary>
    /// 将本地数据更新到服务器端
    /// </summary>
    /// <param name="url"></param>
    /// <param name="score"></param>
    void UpdateScore(string url, int score);
}
