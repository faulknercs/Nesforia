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
using System.Linq;
using Nesforia.Core.Exceptions;

namespace Nesforia.Core.Loaders
{
    /// <summary>
    /// Rom loaders provider
    /// </summary>
    public class LoaderProvider : ILoaderProvider
    {
        private readonly List<IRomLoader> _romLoaders = new List<IRomLoader>();

        /// <summary>
        /// Gets avalaible loaders for current provider
        /// </summary>
        /// <returns>Available loaders</returns>
        public IEnumerable<IRomLoader> GetAvailableLoaders()
        {
            
            return new List<IRomLoader>(_romLoaders);
        }

        /// <summary>
        /// Gets loader for file header. Reset stream position to original value after reading of header.
        /// </summary>
        /// <param name="reader">Wrapped into reader data stream</param>
        /// <returns>Rom loader according to file header</returns>
        /// <exception cref="BadRomException">Throws, when there is no suitable loaders for given rom</exception>
        public IRomLoader GetLoaderByHeader(BinaryReader reader)
        {
            long streamPosition = reader.BaseStream.Position;

            foreach (var romLoader in _romLoaders)
            {
                byte[] supportedHeader = romLoader.Header;
                byte[] fileHeader = reader.ReadBytes(supportedHeader.Length);

                reader.BaseStream.Position = streamPosition;

                if (fileHeader.SequenceEqual(supportedHeader))
                    return romLoader;
            }

            throw new BadRomException("Rom format is not supported");
        }

        /// <summary>
        /// Add available loader to provider
        /// </summary>
        /// <param name="romLoader">NES rom loader</param>
        public void AddLoader(IRomLoader romLoader)
        {
            _romLoaders.Add(romLoader);
        }

        /// <summary>
        /// Add available loaders to provider
        /// </summary>
        /// <param name="romLoaders">NES rom loaders</param>
        public void AddLoaders(IEnumerable<IRomLoader> romLoaders)
        {
            _romLoaders.AddRange(romLoaders);
        }
    }
}