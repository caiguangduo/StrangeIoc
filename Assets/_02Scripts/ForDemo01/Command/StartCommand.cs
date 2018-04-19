using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class StartCommand : Command 
{
    public override void Execute()
    {
        Debug.Log("Start Command Execute");
    }
}
