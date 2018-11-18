using Assets.Scripts.Core;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Logger;
using Assets.Scripts.ViewComponents;
using UnityEngine;

public abstract class View : MonoBehaviour, IComponent
{
#if UNITY_EDITOR
    [SerializeField]
#pragma warning disable 414
    private bool _isInitialized;
#pragma warning restore 414
#endif

    private Context _context;
    internal void Initialize(Context context)
    {
        _context = context;
        _context.AddView(this);
        ConditionalLogger.Log($"<color=blue><b>{gameObject.name}</b></color> has been initialized!");
#if UNITY_EDITOR
        _isInitialized = true;
#endif
    }



}