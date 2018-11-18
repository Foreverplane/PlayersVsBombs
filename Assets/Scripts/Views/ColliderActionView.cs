using System;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public abstract class ColliderActionView: ColliderView
 

    {
    private Action<Collision> _action;

    public void SetAction(Action<Collision> action)
    {
        _action = action;
    }

    private void OnCollisionEnter(Collision col)
    {
        _action?.Invoke(col);
    }
    }
}