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
using Nesforia.Core.Memory;
using Nesforia.Core.Ppu;

namespace Nesforia.Core.Loaders
{
    /// <summary>
    /// Represents the read data from NES ROM
    /// </summary>
    public sealed class RomData
    {
        /// <summary>
        /// Gets or sets TV System of Rom
        /// </summary>
        public TvSystem TvSystem { get; set; }

        /// <summary>
        /// Gets or sets mirroring mode of rom
        /// </summary>
        public Mirroring Mirroring { get; set; }

        /// <summary>
        /// Indicated, if rom is corrupted
        /// </summary>
        public bool IsCorrupted { get; set; }

        /// <summary>
        /// Gets or sets rom Prg banks dump
        /// </summary>
        public byte[] PrgRomDump { get; set; }

        /// <summary>
        /// Gets or sets rom Chr banks dump
        /// </summary>
        public byte[] ChrRomDump { get; set; }

        /// <summary>
        /// Gets or sets rom trainer dump. Returns null, if there is no trainer
        /// </summary>
        public byte[] TrainerDump { get; set; }

        /// <summary>
        /// Indicates, is this rom for playchoice system
        /// </summary>
        public bool IsPlaychoice { get; set; }

        /// <summary>
        /// Indicates, is this rom for Vs Unisystem
        /// </summary>
        public bool IsVsUnisystem { get; set; }

        /// <summary>
        /// Gets or sets Rom name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets iNES mapper number
        /// </summary>
        public int MapperNumber { get; set; }

        /// <summary>
        /// Gets or sets mapper name, used, when there is no mapper number (for example, in unif roms)
        /// </summary>
        public String MapperName { get; set; }
    }
}