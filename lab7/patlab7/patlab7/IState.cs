public interface IState
{
    void Turn(Mixer context, double angle, string which); // which = "cold" or "hot"
    void SwitchToSpout(Mixer context);
    void SwitchToShower(Mixer context);
    void RestoreWater(Mixer context);
    string Name { get; }
}