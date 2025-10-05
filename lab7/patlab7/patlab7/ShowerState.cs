using System;

public class ShowerState : IState
{
    public string Name => "Shower";
    public double Angle { get; private set; }
    public string Which { get; private set; }

    public ShowerState(double angle, string which)
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
        if (context.CheckFailure())
        {
            context.SetState(new NoWaterState());
            return;
        }

        context.SetState(new SpoutState(Angle, Which));
    }

    public void SwitchToShower(Mixer context)
    {
        // уже на лейке
    }

    public void RestoreWater(Mixer context)
    {
        // аналогично SpoutState note
    }
}
