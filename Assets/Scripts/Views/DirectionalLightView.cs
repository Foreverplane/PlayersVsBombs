using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Assets.Scripts.Views
{
    public class DirectionalLightView : View
    {
        [SerializeField]
        private Light _dLight;
        public Light DirectionalLight => _dLight;
    }
}