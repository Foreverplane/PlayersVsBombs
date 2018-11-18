using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlayerSpawnOnClickSystem : OnClickSystem<SpawnPlayerAtPointEvent>
    {
        public PlayerSpawnOnClickSystem(Context context) : base(context)
        {
        }

        protected override bool GetInput()
        {

            return Input.GetMouseButtonDown(0);

        }
    }
}
