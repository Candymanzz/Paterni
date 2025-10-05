using System;

public class ClosedState : IState
{
    public string Name => "Closed";

    public void Turn(Mixer context, double angle, string which)
    {
        if (angle <= 0)
        {
            // остаёмся закрытыми
            return;
        }

        // попытка открыть: может случиться отказ
        if (context.CheckFailure())
        {
            context.SetState(new NoWaterState());
            return;
        }

        // по умолчанию первое открытие идёт через излив (Spout)
        context.SetState(new SpoutState(angle, which));
    }

    public void SwitchToSpout(Mixer context)
    {
        // Переключение режима без открытия — остаёмся закрытыми (можно запомнить режим)
    }

    public void SwitchToShower(Mixer context)
    {
        // Аналогично: остаёмся закрытыми
    }

    public void RestoreWater(Mixer context)
    {
        // если вода была, остаёмся Closed
    }
}