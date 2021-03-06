﻿#region License
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
    /// Loader for UNIF
    /// </summary>
    public class UnifFormatLoader : IRomLoader
    {
        /// <summary>
        /// Loads rom from UNIF file, wrapped into binary reader.
        /// </summary>
        /// <param name="reader">Binary reader, wrapped over data stream</param>
        /// <returns>Content of NES rom in <see cref="RomData"/> structure</returns>
        public RomData LoadRom(BinaryReader reader)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Name of supported format
        /// </summary>
        public String FormatName
        {
            get { return "Universal NES Image Format"; }
        }

        /// <summary>
        /// Array of supported file extensions of UNIF
        /// </summary>
        public String[] FileExtensions
        {
            get { return new[] { "unf", "unif" }; }
        }

        /// <summary>
        /// Header value, which marks supported format. For UNIF it is "UNIF", not null-terminated (0x55 0x4E 0x49 0x46)
        /// </summary>
        public byte[] Header
        {
            get { return new byte[] { 0x55, 0x4E, 0x49, 0x46 }; }
        }
    }
}