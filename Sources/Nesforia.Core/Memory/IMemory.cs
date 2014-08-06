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

namespace Nesforia.Core.Memory
{
    /// <summary>
    /// Basic interface of NES memory
    /// </summary>
    public interface IMemory
    {
        /// <summary>
        /// Maps <paramref name="address"/> to specific read and write functions
        /// </summary>
        /// <param name="address">Address for mapping</param>
        /// <param name="readCallback">Read function for given address</param>
        /// <param name="writeCallback">Write function for given address</param>
        void Map(int address, Func<byte> readCallback, Action<byte> writeCallback);

        /// <summary>
        /// Maps address range from <paramref name="startAdress"/> to <paramref name="endAdress"/> to specific read and write functions
        /// </summary>
        /// <param name="startAdress">First address of range</param>
        /// <param name="endAdress">Last address of range</param>
        /// <param name="readCallback">Read function for given address, accepts address as param</param>
        /// <param name="writeCallback">Write function for given address, accepts address and value as params</param>
        void Map(int startAdress, int endAdress, Func<int, byte> readCallback, Action<int, byte> writeCallback);

        /// <summary>
        /// Read byte from given address
        /// </summary>
        /// <param name="address">16-bit address in memory (using int for CLS-compliance)</param>
        /// <returns>Value at <paramref name="address"/></returns>
        byte Read(int address);

        /// <summary>
        /// Write byte at given address
        /// </summary>
        /// <param name="address">16-bit address in memory (using int for CLS-compliance)</param>
        /// <param name="value">Value for write</param>
        void Write(int address, byte value);
    }
}