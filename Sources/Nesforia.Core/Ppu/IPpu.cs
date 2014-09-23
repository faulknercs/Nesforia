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
namespace Nesforia.Core.Ppu
{
    /// <summary>
    /// Interface of NES Picture Processing Unit
    /// </summary>
    /// <remarks>
    /// Detailed description: http://wiki.nesdev.com/w/index.php/PPU
    /// </remarks>
    public interface IPpu
    {
        void Clock();

        /// <summary>
        /// Sets type of emulated video system
        /// </summary>
        /// <param name="tvSystem">Type of video system</param>
        void SetTvSystem(TvSystem tvSystem);

        /// <summary>
        /// Reads status register of PPU (PPUSTATUS)
        /// </summary>
        /// <returns>PPU status</returns>
        byte Read2002();

        /// <summary>
        /// Reads PPU OAM data port. Reads during vertical or forced blanking return the value from OAM at that address from OAMADDR without it increment.
        /// </summary>
        /// <returns>OAM data at address from OAMADDR</returns>
        byte Read2004();

        /// <summary>
        /// Reads VRAM data register at address from PPUADDR.  After access, the video memory address will increment by an amount determined by bit 2 of PPUCTRL register.
        /// </summary>
        /// <returns>Value of VRAM at address from PPUADDR</returns>
        byte Read2007();

        /// <summary>
        /// Writes to PPU Controller register (PPUCTRL)
        /// </summary>
        /// <param name="value">Various flags controlling PPU operation</param>
        void Write2000(byte value);

        /// <summary>
        /// Writes to PPU Mask register (PPUMASK)
        /// </summary>
        /// <param name="value">Flags, which controls screen enable, masking, and intensity</param>
        void Write2001(byte value);

        /// <summary>
        /// Writes to PPU OAM (Object Attribute Memory) register (OAMADDR)
        /// </summary>
        /// <param name="value">Address of OAM you want to access</param>
        void Write2003(byte value);

        /// <summary>
        /// Writes to PPU OAM data port (OAMDATA), writes will increment OAMADDR after the write
        /// </summary>
        /// <param name="value"></param>
        void Write2004(byte value);

        /// <summary>
        /// Writes to PPU scroll register (PPUSCROLL). First write writes horizontal offset, Second - vertical offset. 
        /// </summary>
        /// <param name="value">Scrolling offset</param>
        void Write2005(byte value);

        /// <summary>
        /// Writes to PPU Address register (PPUADDR). Write the 16-bit address of VRAM you want to access here, upper byte first.
        /// </summary>
        /// <param name="value">Byte of 16-bit address of VRAM</param>
        void Write2006(byte value);

        /// <summary>
        /// Writes to VRAM Data register (PPUDATA) at address from PPUADDR. After access, the video memory address will increment by an amount determined by bit 2 of PPUCTRL register.
        /// </summary>
        /// <param name="value">Value to write in VRAM at address from PPUADDR</param>
        void Write2007(byte value);
    }
}