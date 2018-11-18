using System;
using Assets.Scripts.Events;
using Assets.Scripts.Logger;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class OnClickSystem<TSpawnEvent> : ContextSystem, IEventListenerSystem<StartGameEvent>
        where TSpawnEvent : SpawnEvent

    {
        protected OnClickSystem(Context context) : base(context)
        {
        }

        void IEventListenerSystem<StartGameEvent>.OnEvent(StartGameEvent contextEvent)
        {
            DOVirtual.DelayedCall(0, ClickCheck).SetLoops(-1);
        }

        private void ClickCheck()
        {
            if (GetInput())
            {
                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                if (Physics.Raycast(ray, out hit))
                {

                    ConditionalLogger.Log($"User click on {hit.point}");
                    var spawnEvent = (TSpawnEvent)Activator.CreateInstance(typeof(TSpawnEvent), hit.point);
                    context.FireEvent(spawnEvent);

                }
            }
        }

        protected abstract bool GetInput();
    }
}