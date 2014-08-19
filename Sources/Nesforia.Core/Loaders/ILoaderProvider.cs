#region License
/****************************************************************************
* Nesforia.Core - NES/Famicom emulator core libraries
*
* Copyright (C) 2014 Nesforia authors
*
* Authors: Artem Stepanyuk <faulknercs@yandex.ru>
*
* This file is part of Nesforia.Core.
*
* This library is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published
* by the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this library. If not, see <http://www.gnu.org/licenses/>.
*****************************************************************************/
#endregion

using System.Collections.Generic;
using System.IO;

namespace Nesforia.Core.Loaders
{
    /// <summary>
    /// Interface of rom loaders provider, helps to manage loaders.
    /// </summary>
    public interface ILoaderProvider
    {
        /// <summary>
        /// Gets avalaible loaders for current provider
        /// </summary>
        /// <returns>Available loaders</returns>
        IEnumerable<IRomLoader> GetAvailableLoaders();

        /// <summary>
        /// Gets loader for file header. Should not change stream position.
        /// </summary>
        /// <param name="reader">Wrapped into reader data stream</param>
        /// <returns>Rom loader according to file header</returns>
        IRomLoader GetLoaderByHeader(BinaryReader reader);

        /// <summary>
        /// Add available loader to provider
        /// </summary>
        /// <param name="romLoader">NES rom loader</param>
        void AddLoader(IRomLoader romLoader);

        /// <summary>
        /// Add available loaders to provider
        /// </summary>
        /// <param name="romLoaders">NES rom loaders</param>
        void AddLoaders(IEnumerable<IRomLoader> romLoaders);
    }
}