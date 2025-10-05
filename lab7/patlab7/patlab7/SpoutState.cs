using System;
using System.Windows.Forms;

public class SpoutState : IState
{
    public string Name => "Spout";
    public double Angle { get; private set; }
    public string Which { get; private set; } // cold/hot

    public SpoutState(double angle, string which)
    {
        Angle = angle;
        Which = which;
    }

    public void Turn(Mixer context, double angle, string which)
    {
        if (angle <= 0)
        {
            context.SetState(new ClosedState());
            return;
        }

        // менять интенсивность — возможно отказ
        if (context.CheckFailure())
        {
            context.SetState(new NoWaterState());
            return;
        }

        Angle = angle;
        Which = which;
    }

    public void SwitchToSpout(Mixer context)
    {
        // уже на изливе — ничего
    }

    public void SwitchToShower(Mixer context)
    {
        // переключаем на лейку — если есть вода
        if (context.CheckFailure())
        {
            context.SetState(new NoWaterState());
            return;
        }

        context.SetState(new ShowerState(Angle, Which));
    }

    public void RestoreWater(Mixer context)
    {
        // если был отказ и вызвали RestoreWater — можно оставить Spout,
        // но в нашем простом варианте RestoreWater действует только из NoWater.
    }
}