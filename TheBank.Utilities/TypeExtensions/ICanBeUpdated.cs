using System;
using System.Collections.Generic;

namespace TheBank.Utilities.TypeExtensions
{
    public interface ICanBeUpdated
    {
        IEnumerable<string> PropertiesToIgnore();
    }
}
