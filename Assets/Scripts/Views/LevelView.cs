namespace Assets.Scripts.Views
{
    public class LevelView : ViewsHandler
    {

        // Чтобы в ручную не накидывать рефы.
        void OnValidate()
        {
            _views = GetComponentsInChildren<View>();
        }
    }
}