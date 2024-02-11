namespace VSOP.Domain.Primitives.Results;

/// <summary>
/// Результат какой-либо операции, с информацией о успешности с возможным значением или ошибкой.
/// </summary>
public class Result
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Result"/> класса с указанными параметрами.
    /// </summary>
    /// <param name="isSuccess">Признак указывающий успешный ли результат.</param>
    /// <param name="error">Объект ошибки.</param>

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Получает значение успешности результата.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Получает значение неуспешности результата
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Получения объекта ошибки.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Возвращает успешный результат <see cref="Result"/>.
    /// </summary>
    /// <returns>Новый экземпляр <see cref="Result"/> с указателем успешности.</returns>
    public static Result Success() => new Result(true, Error.None);

    /// <summary>
    ///  Возвращает успешный результат <see cref="Result{TValue}"/> с указанным значением.
    /// </summary>
    /// <typeparam name="TValue">Тип значения результата.</typeparam>
    /// <param name="value">Значение результата.</param>
    /// <returns>Новый экземпляр <see cref="Result{TValue}"/> с указателем успешности.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

    /// <summary>
    /// Создает новый экземпляр <see cref="Result{TValue}"/> с указанными nullable значением или ошибкой.
    /// </summary>
    /// <typeparam name="TValue">Тип значения результата.</typeparam>
    /// <param name="value">Значение результата.</param>
    /// <param name="error">Ошибка в случае если значение нулевое.</param>
    /// <returns>Новый экземпляр <see cref="Result{TValue}"/> с указанными значением или ошибкой.</returns>
    public static Result<TValue> Create<TValue>(TValue value, Error error)
        where TValue : class
        => value is null ? Failure<TValue>(error) : Success(value);

    /// <summary>
    /// Возвращает неудачный <see cref="Result"/> с указанной ошибкой.
    /// </summary>
    /// <param name="error">Ошибка.</param>
    /// <returns>Новый экземпляр <see cref="Result"/> с указанным объектом ошибки и указателем неудачи.</returns>
    public static Result Failure(Error error) => new Result(false, error);

    /// <summary>
    /// Возвращает неудачный <see cref="Result{TValue}"/> с указанной ошибкой.
    /// </summary>
    /// <typeparam name="TValue">Тип объекта результата.</typeparam>
    /// <param name="error">Объект ошибки.</param>
    /// <returns>Новый экземпляр <see cref="Result{TValue}"/> с указанным объектом ошибки и указателем неудачи.</returns>
    public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);

    /// <summary>
    /// Возвращает первую неудачу из указанного <paramref name="results"/>.
    /// Если нет неудачь, возвращается успех.
    /// </summary>
    /// <param name="results">Массив результатов.</param>
    /// <returns>
    /// Первую ошибку из указанного <paramref name="results"/> массива, или успех если ошибок нет.
    /// </returns>
    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.IsFailure)
            {
                return result;
            }
        }

        return Success();
    }
}
