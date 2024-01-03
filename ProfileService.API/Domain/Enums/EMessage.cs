using System.ComponentModel;

namespace ProfileService.API.Domain.Enums;

public enum EMessage : ushort
{
    [Description("{0} needs to be filled.")]
    Required,

    [Description("Field {0} allows {1} chars.")]
    InvalidLength,
}
