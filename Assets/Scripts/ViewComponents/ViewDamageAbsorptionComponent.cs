using UnityEngine;

namespace Assets.Scripts.ViewComponents
{
    public class ViewDamageAbsorptionComponent : ViewDataComponent
    {
        [SerializeField]
        private Vector3 _anisotropicPower;
        public Vector3 AnisotropicPower => _anisotropicPower;

        [SerializeField]
        private bool _isCustomPower;
        // просто чтобы руками это не заполнять.
        private void OnValidate()
        {
            if (!_isCustomPower)
                _anisotropicPower = gameObject.transform.localScale;
        }

    }
}