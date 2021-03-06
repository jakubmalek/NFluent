﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendableCheckLink.cs" company="">
//   Copyright 2013 Cyrille DUPUYDAUBY
//   //   Licensed under the Apache License, Version 2.0 (the "License");
//   //   you may not use this file except in compliance with the License.
//   //   You may obtain a copy of the License at
//   //       http://www.apache.org/licenses/LICENSE-2.0
//   //   Unless required by applicable law or agreed to in writing, software
//   //   distributed under the License is distributed on an "AS IS" BASIS,
//   //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   //   See the License for the specific language governing permissions and
//   //   limitations under the License.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NFluent
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides an specific implementation for IEnumerable fluent check. Required to implement IEnumerable fluent API.
    /// </summary>
    /// <typeparam name="T">
    /// Type managed by this extension.
    /// </typeparam>
    /// <typeparam name="U">Type of the reference comparand.</typeparam>
    internal class ExtendableCheckLink<T, U> : CheckLink<ICheck<T>>, IExtendableCheckLink<T, U>
    {
        private readonly U originalComparand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendableCheckLink{T,U}"/> class. 
        /// </summary>
        /// <param name="previousCheck">
        /// The previous fluent check.
        /// </param>
        /// <param name="originalComparand">
        /// Comparand used for the first check.
        /// </param>
        public ExtendableCheckLink(IMustImplementIForkableCheckWithoutDisplayingItsMethodsWithinIntelliSense previousCheck, U originalComparand) : base(previousCheck)
        {
            this.originalComparand = originalComparand;
        }

        /// <summary>
        /// Gets the initial list that was used in Contains.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// Temporary to bi completed.
        /// </exception>
        /// <value>
        /// Initial list that was used in Contains.
        /// </value>
        public U OriginalComparand
        {
            get
            {
                return this.originalComparand;
            }
        }
    }

    /// <summary>
    /// Provides an specific implementation for IEnumerable fluent check. Required to implement IEnumerable fluent API.
    /// </summary>
    /// <typeparam name="T">
    /// Type managed by this extension.
    /// </typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal class ExtendableCheckLink<T> : ExtendableCheckLink<T, T>, IExtendableCheckLink<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendableCheckLink{T}"/> class. 
        /// </summary>
        /// <param name="previousCheck">
        /// The previous fluent check.
        /// </param>
        /// <param name="originalComparand">
        /// Comparand used for the first check.
        /// </param>
        public ExtendableCheckLink(IMustImplementIForkableCheckWithoutDisplayingItsMethodsWithinIntelliSense previousCheck, T originalComparand) : base(previousCheck, originalComparand)
        {
        }
    }
}