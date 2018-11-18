namespace Assets.Scripts.Core
{
    public class DamageFeature : Feature
    {
        public DamageFeature(Context context) : base(context)
        {
            // описывают что происходит после коллизии. (по факту стали системами что начисляют дамаг, т.к. визуализации никакой не делал, такого варианта пока достаточно)
            AddSystem(new SphericalCollisionSystem(context));
            AddSystem(new LinearCollisionSystem(context));
            AddSystem(new FakeCollisionSystem(context));
            // чекает что происходит после нанесения дамага.
            AddSystem(new PostDamageSystem(context));
        }
    }
}