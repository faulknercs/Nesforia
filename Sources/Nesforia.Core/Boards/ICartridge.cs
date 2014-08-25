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

namespace Nesforia.Core.Boards
{
    /// <summary>
    /// NES Cartridge board interface
    /// </summary>
    public interface ICartridge
    {
        bool HasSaveRam { get; }

        bool HasTrainer { get; }

        /// <summary>
        /// Handles reads from 0x8000 - 0xFFFF prg-rom addresses
        /// </summary>
        /// <param name="address">PRG-ROM address</param>
        /// <returns>Value at given address</returns>
        byte ReadPrg(int address);

        /// <summary>
        /// Handles reads from Expansion ROM (0x5000 - 0x5FFF). Mostly used with MMC 5 boards
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Value at given address</returns>
        byte ReadExpansion(int address);

        /// <summary>
        /// Handles reads from SRAM (0x6000 - 0x7FFF).
        /// </summary>
        /// <param name="address">SRAM Address</param>
        /// <returns>Value at given address</returns>
        byte ReadSram(int address);

        byte ReadChr(int address);

        /// <summary>
        /// Handles writes to 0x8000 - 0xFFFF prg-rom addresses
        /// </summary>
        /// <param name="address">PRG-ROM address</param>
        /// <param name="value">Value to write</param>
        void WritePrg(int address, byte value);

        /// <summary>
        /// Handles writes to Expansion ROM (0x5000 - 0x5FFF). Mostly used with MMC 5 boards
        /// </summary>
        /// <param name="address">Expansion ROM address</param>
        /// <param name="value">Value to write</param>
        void WriteExpansion(int address, byte value);

        /// <summary>
        /// Handles writes to SRAM (0x6000 - 0x7FFF).
        /// </summary>
        /// <param name="address">SRAM address</param>
        /// <param name="value">Value to write</param>
        void WriteSram(int address, byte value);

        void WriteChr(int address, byte value);
    }
}