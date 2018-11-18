namespace Assets.Scripts.Core
{
    internal interface IEventListenerSystem<in T>
    {
        void OnEvent(T contextEvent);
    }
}