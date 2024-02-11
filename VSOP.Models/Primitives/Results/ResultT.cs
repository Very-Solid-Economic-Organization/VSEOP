namespace VSOP.Models.Primitives.Results;

/// <summary>
/// Результат какой-либо операции, с информацией о успешности с возможным значением или ошибкой.
/// </summary>
/// <typeparam name="TValue">Тип значения результата.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue _value;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Result{TValueType}"/> класса с указанными параметрами.
    /// </summary>
    /// <param name="value">Объект результата.</param>
    /// <param name="isSuccess">Указатель успешности или неуспешности результата.</param>
    /// <param name="error">Объект ошибки.</param>

    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
        => _value = value;

    public static implicit operator Result<TValue>(TValue value) => Success(value);

    /// <summary>
    /// Получает объект успешного результата или выдает исключение.
    /// </summary>
    /// <returns>Объект успешного результата если он успешный.</returns>
    /// <exception cref="InvalidOperationException"> когда <see cref="Result.IsFailure"/> is true.</exception>
    public TValue Value => IsSuccess
        ? _value
       : throw new InvalidOperationException("The value of a failure result can not be accessed.");
}