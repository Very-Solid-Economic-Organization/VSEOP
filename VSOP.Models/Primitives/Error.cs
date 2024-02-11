using System.Net;

namespace VSOP.Models.Primitives;

/// <summary>Объект ошибки</summary>
public class Error
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Error"/> класса.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Текст ошибки.</param>

    public Error(HttpStatusCode code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Получение кода ошибки.
    /// </summary>
    public HttpStatusCode Code { get; }

    /// <summary>
    /// Получение текста ошибки.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Создает пустой объект ошибки.
    /// </summary>
    internal static Error None => new Error(HttpStatusCode.BadRequest, string.Empty);
}