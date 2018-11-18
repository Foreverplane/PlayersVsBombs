using Assets.Scripts.Components;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Events;
using Assets.Scripts.Logger;
using Assets.Scripts.ViewComponents;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class BombCollisionSystem<TCollisionEvent, TDamageComponent> : ContextSystem, IEventListenerSystem<TCollisionEvent>
    where TCollisionEvent : BombCollisionEvent
    where TDamageComponent : DamageSourceComponent
    {
        private const float ABSORPTION_ABSOLUTE_MULT = 1.05f;
        private readonly AfterDamageEvent afterDamage = new AfterDamageEvent();

        protected BombCollisionSystem(Context context) : base(context)
        {
        }

        void IEventListenerSystem<TCollisionEvent>.OnEvent(TCollisionEvent contextEvent)
        {
            var damageSource = contextEvent.Entity.GetComponent<TDamageComponent>();
            var damagables = SelectDamagables(damageSource, contextEvent);
            foreach (var damagable in damagables.ToArray())
            {
                ApplyDamage(damagable, damageSource, contextEvent);
            }
            context.FireEvent(afterDamage);
        }

        protected virtual void ApplyDamage(IEntity damagable, TDamageComponent damageSource, TCollisionEvent collisionEvent)
        {
            ConditionalLogger.Log($"{damagable.GetComponent<View>().transform.name} receive damage from {collisionEvent.Entity.GetComponent<View>()}!");
            var healthComp = damagable.GetComponent<HealthComponent>();
            var damage = damageSource.power;

            var sourceDamageSourcePoint = collisionEvent.Entity.GetComponent<ColliderView>().Collider.transform.position;
            var damagablePoint = damagable.GetComponent<ColliderView>().Collider.transform.position;
            var dir = damagablePoint - sourceDamageSourcePoint;
            var dist = Vector3.Distance(sourceDamageSourcePoint, damagablePoint);

            DistanceInfluence(ref damage, dist, damageSource.range);
            DamageAbsorption(ref damage, dir, dist, sourceDamageSourcePoint, damagablePoint);

            if (damage <= 0)
                return;
            healthComp.AddDelta(-damage);
            ConditionalLogger.Log($"Apply <b> {damage}</b> of damage for <b> {damagable.GetComponent<View>().name} </b>");
        }
        protected virtual IList<IEntity> SelectDamagables(TDamageComponent damageSource, TCollisionEvent contextEvent)
        {
            var bombView = contextEvent.Entity.GetComponent<View>();
            ConditionalLogger.Log($"Try select damagables around spherical bomb collision at point <b> {bombView.transform.position} </b>");

            // тут уже в зависимости от теоретического количества объектов может быть и быстрее делать выборку и через PhysicsOverlapSphere.
            var entities = context.GetEntitiesWithComponents(typeof(HealthComponent));
            var properEntities = entities.Where(_ => Vector3.Distance(_.GetComponent<View>().transform.position, bombView.transform.position) <= damageSource.range).ToList();
            contextEvent.Entity.AddComponent(new HealthComponent(0));

            ConditionalLogger.Log($"Select all {properEntities.Count} entities!");
            return properEntities;
        }
        // дамаг поглащается в зависимости от препятствий.
        private void DamageAbsorption(ref float damagePower, Vector3 dir, float dist, Vector3 sourcePoint, Vector3 receivePoint)
        {
            Debug.DrawLine(sourcePoint, receivePoint, Color.blue, 10f);
            var hits = Physics.RaycastAll(sourcePoint, dir, dist);
            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    // если уже весь дамаг поглащён, то смысл дальше считать что.
                    if (damagePower <= 0)
                        break;
                    var absorptionComp = hit.transform.parent?.GetComponent<ColliderView>()?.GetViewData<ViewDamageAbsorptionComponent>();
                    if (absorptionComp == null)
                        continue;
                    // была мысль чтобы дамаг поглащался анизотропно, но что-то пошло не так. так что по-простому тут.
                    var anisotropicAbsorption = absorptionComp.AnisotropicPower * ABSORPTION_ABSOLUTE_MULT;
                    ConditionalLogger.Log($"Damage absorbed <b>{hit.transform.parent.name}</b> by {anisotropicAbsorption.sqrMagnitude}");
                    damagePower -= anisotropicAbsorption.sqrMagnitude;
                }
            }
            else
            {
                ConditionalLogger.Log("<color=red>There is no hits for absorption.</color>");
            }
        }
        // дамаг уменьшается в зависимости от дистанции.
        private void DistanceInfluence(ref float damagePower, float dist, float range)
        {
            damagePower = Mathf.Lerp(damagePower, 0, dist / range);
            ConditionalLogger.Log($"Damage after <b> {dist} </b> units of distance is <b> {damagePower} </b>");
        }
    }
}