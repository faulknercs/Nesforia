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

using System;
using System.IO;

namespace Nesforia.Core.Loaders
{
    /// <summary>
    /// Interface for rom loaders
    /// </summary>
    public interface IRomLoader
    {
        /// <summary>
        /// Loads rom from stream, wrapped into binary reader
        /// </summary>
        /// <param name="reader">Binary reader, wrapped over data stream</param>
        /// <returns>Content of NES rom in <see cref="RomData"/> structure</returns>
        /// <exception cref="Nesforia.Core.Exceptions.BadRomException">Throws, when loader cann't read rom data</exception>
        RomData LoadRom(BinaryReader reader);

        /// <summary>
        /// Name of supported format
        /// </summary>
        String FormatName { get; }

        /// <summary>
        /// Array of supported file extensions of this format
        /// </summary>
        String[] FileExtensions { get; }

        /// <summary>
        /// Header value, which marks supported format
        /// </summary>
        byte[] Header { get; }
    }
}