
using Assets.Scripts.Core;
using Assets.Scripts.Logger;

/// <summary>
/// Базовый интерфейс для всех систем. "Спасибо кэп)"
/// </summary>
public abstract class ContextSystem
{
    protected readonly Context context;

    protected ContextSystem(Context context)
    {
        ConditionalLogger.Log($"<b>{GetType().Name}</b> has been created!");
        this.context = context;
    }
}