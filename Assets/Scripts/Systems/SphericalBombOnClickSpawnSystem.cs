using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class SphericalBombOnClickSpawnSystem : BombSpawnOnClickSystem<SpawnSphericalBombAtPointEvent> {
        public SphericalBombOnClickSpawnSystem(Context context) : base(context)
        {
        }

        protected override bool GetInput()
        {
            return Input.GetKeyDown(KeyCode.Alpha1);
        }
    }
}