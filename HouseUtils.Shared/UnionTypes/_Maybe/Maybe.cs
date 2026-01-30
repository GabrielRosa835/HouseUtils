namespace HouseUtils.Shared.UnionTypes;

public readonly struct Maybe<TValue>
{
   private readonly TValue _value;
   private readonly bool _isPresent;

   public bool IsPresent => _isPresent;
   public bool IsEmpty => !IsPresent;

   private Maybe(bool isPresent, TValue value)
   {
      _isPresent = isPresent;
      _value = value;
   }

   public static Maybe<TValue> Present(TValue value) => new(true, value);
   public static Maybe<TValue> Empty () => new(false, default!);
   public static Maybe<TValue> Of(TValue? value) => value is null ? Empty() : Present(value);

   public TResult Either<TResult> (Func<TValue, TResult> onPresent, Func<TResult> onEmpty)
   {
      return _isPresent ? onPresent(_value) : onEmpty();
   }
}
