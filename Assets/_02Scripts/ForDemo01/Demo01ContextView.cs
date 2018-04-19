using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class Demo01ContextView : ContextView 
{
	void Awake()
    {
        this.context = new Demo01MVCSContext(this);
    }
}
