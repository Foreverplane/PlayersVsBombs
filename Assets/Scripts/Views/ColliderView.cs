using Assets.Scripts.ViewComponents;
using UnityEngine;

public abstract class ColliderView : View
{
    [SerializeField]
    private Collider _collider;
    public Collider Collider => _collider;

    [SerializeField]
    private ViewDataComponent[] _viewDataComponents;
    public T GetViewData<T>() where T : ViewDataComponent
    {
        for (var index = 0; index < _viewDataComponents.Length; index++)
        {
            var viewData = _viewDataComponents[index];
            if (viewData is T)
                return viewData as T;
        }

        return null;
    }

    private void OnValidate()
    {
        _viewDataComponents = GetComponentsInChildren<ViewDataComponent>();
    }
}