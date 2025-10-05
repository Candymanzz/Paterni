using System;

public class NoWaterState : IState
{
    public string Name => "NoWater";

    public void Turn(Mixer context, double angle, string which)
    {
        // Игнорируем — нет воды
    }

    public void SwitchToSpout(Mixer context)
    {
        // Игнорируем
    }

    public void SwitchToShower(Mixer context)
    {
        // Игнорируем
    }

    public void RestoreWater(Mixer context)
    {
        // Восстанавливаем подачу — переводим в Closed (можно в предыдущий режим)
        context.SetState(new ClosedState());
    }
}