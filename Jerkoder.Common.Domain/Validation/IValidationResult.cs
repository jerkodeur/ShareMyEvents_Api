using Jerkoder.Common.Domain.Exceptions;

namespace Jerkoder.Common.Domain.Validation;
public interface IValidationResult
{
    Error[] Errors { get; }
}
