namespace ViceCity.Core.Contracts
{
    internal interface IPlayer
    {
        object GunRepository { get; }
        bool IsAlive { get; }
        object LifePoints { get; }
    }
}