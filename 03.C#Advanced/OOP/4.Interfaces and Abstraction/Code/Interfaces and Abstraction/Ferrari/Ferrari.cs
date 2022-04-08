namespace PersonInfo
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string name)
        {
            Name = name;
            Model = "488-Spider";
        }

        public string Name { get; }

        public string Model { get; }

        public string PushDown()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.PushDown()}/{this.PushGasPedal()}/{this.Name}";
        }
    }
}
