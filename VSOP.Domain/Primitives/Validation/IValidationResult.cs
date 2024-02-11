using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSOP.Domain.Primitives.Validation
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new(
            System.Net.HttpStatusCode.UnprocessableContent,
            "A validation problem occurred."
            );

        Error[] Errors { get; }
    }
}
