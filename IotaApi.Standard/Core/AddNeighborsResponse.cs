﻿namespace Iota.Api.Core
{

    /// <summary>
    /// Response of <see cref="AddNeighborsRequest"/>
    /// </summary>
    public class AddNeighborsResponse
    {
        /// <summary>
        /// Gets the number of added neighbors.
        /// </summary>
        /// <value>
        /// The number of added neighbors.
        /// </value>
        public long AddedNeighbors { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{nameof(AddedNeighbors)}: {AddedNeighbors}";
        }
    }
}