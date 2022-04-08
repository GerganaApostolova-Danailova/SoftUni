namespace PersonInfo
{
    public interface IFerrari
    {
        string Name { get; }

        string Model { get; }

        string PushGasPedal();

        string PushDown();
    }
}

