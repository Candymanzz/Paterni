public class Mixer
{
    private IState _state;
    private readonly Random _rnd = new Random();

    // Атрибуты
    public double MaxColdPressure { get; set; }
    public double MaxHotPressure { get; set; }
    // Вероятность отказа при попытке открыть (0..1)
    public double FailureProbability { get; set; }

    public Mixer(double maxCold = 5.0, double maxHot = 5.0, double failureProb = 0.05)
    {
        MaxColdPressure = maxCold;
        MaxHotPressure = maxHot;
        FailureProbability = failureProb;
        _state = new ClosedState();
    }

    public string StateName => _state.Name;

    internal bool CheckFailure()
    {
        return _rnd.NextDouble() < FailureProbability;
    }

    public void SetState(IState newState)
    {
        _state = newState;
    }

    // Операции, вызываемые клиентом (например, UI)
    public void Turn(double angle, string which)
    {
        _state.Turn(this, angle, which);
    }

    public void SwitchToSpout()
    {
        _state.SwitchToSpout(this);
    }

    public void SwitchToShower()
    {
        _state.SwitchToShower(this);
    }

    public void RestoreWater()
    {
        _state.RestoreWater(this);
    }
}