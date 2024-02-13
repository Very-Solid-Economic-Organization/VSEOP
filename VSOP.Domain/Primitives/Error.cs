using System.Net;

namespace VSOP.Domain.Primitives;

/// <summary>Объект ошибки</summary>
public class Error : ValueObject //Осознать необъодимость
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Error"/> класса.
    /// </summary>
    /// <param name="message">Текст ошибки.</param>

    public Error(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Получение текста ошибки.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Создает пустой объект ошибки.
    /// </summary>
    internal static Error None => new Error(string.Empty);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Message;
    }
}