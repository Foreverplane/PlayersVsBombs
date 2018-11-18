using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ViewsLibrary", menuName = "ViewsLibrary", order = 0)]
public class ViewsLibrary : ScriptableObject, IResourceProvider
{
    [SerializeField]
    private View[] _views;
    T IResourceProvider.GetResourceView<T>()
    {
        return (T)_views.FirstOrDefault(_ => _ is T);
    }

    IEnumerable<T> IResourceProvider.GetResourceViews<T>()
    {
        return _views.OfType<T>();
    }
}