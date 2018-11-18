using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class LinearBombOnClickSpawnSystem : BombSpawnOnClickSystem<SpawnLinearBombAtPointEvent>
    {
        public LinearBombOnClickSpawnSystem(Context context) : base(context)
        {
        }

        protected override bool GetInput()
        {
            return Input.GetKeyDown(KeyCode.Alpha2);
        }
    }
}