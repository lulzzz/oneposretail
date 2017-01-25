using System;

namespace OnePos.Framework.Domain
{
    public interface IUniqueIdentifierGenerator
    {
        /// <summary>
        /// Generates the new identifier.
        /// </summary>
        /// <returns>A new <see cref="Guid"/>.</returns>
        Guid GenerateNewId();
    }
}
