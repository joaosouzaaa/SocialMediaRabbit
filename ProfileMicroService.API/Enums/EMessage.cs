using System.ComponentModel;

namespace ProfileMicroService.API.Enums;

public enum EMessage : ushort
{
    [Description("{0} needs to be filled.")]
    Required,

    [Description("Field {0} allows {1} chars.")]
    InvalidLength,

    [Description("{0} is with invalid format.")]
    InvalidFormat,

    [Description("{0} was not found.")]
    NotFound,

    [Description("{0} already exists.")]
    Exists, 

    [Description("An unexpected error happened.")]
    UnexpectedError
}
