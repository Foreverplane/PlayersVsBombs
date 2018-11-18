using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public abstract class ViewsHandler : View
    {
        [SerializeField]
        protected View[] _views;

        public T GetView<T>() where T : View
        {
            
            // тут может быть узкое место, потому и фор. иначе бы был бы линк. фор шустрее форича и линка всё же будет.
            for (var index = 0; index < _views.Length; index++)
            {
                var view = _views[index];
                if (view is T)
                    return view as T;
            }

            return null;
        }

        public List<T> GetViews<T>() where T : View
        {
            var list = new List<T>();
            for (var index = 0; index < _views.Length; index++)
            {
                var view = _views[index];
                if (view is T)
                    list.Add(view as T);
            }

            return list;
        }
    }
}