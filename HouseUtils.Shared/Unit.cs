namespace HouseUtils.Shared;

public readonly struct Unit : IEquatable<Unit>
{
   public static readonly Unit Value = new();

   public override string ToString () => "()";
   public override int GetHashCode () => 0;
   public bool Equals (Unit other) => true;
   public override bool Equals (object? obj) => obj is Unit unit && Equals (unit);
}
