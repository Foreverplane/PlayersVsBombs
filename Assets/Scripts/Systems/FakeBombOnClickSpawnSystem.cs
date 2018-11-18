using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class FakeBombOnClickSpawnSystem : BombSpawnOnClickSystem<SpawnFakeBombAtPointEvent>
    {
        public FakeBombOnClickSpawnSystem(Context context) : base(context)
        {
        }

        protected override bool GetInput()
        {
            return Input.GetKeyDown(KeyCode.Alpha3);
        }
    }
}