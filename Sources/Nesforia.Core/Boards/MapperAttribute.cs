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

namespace Nesforia.Core.Boards
{
    /// <summary>
    /// Specifies corresponding INES mapper number for cartridge
    /// </summary>
    /// <remarks>
    /// More info about INES mappers: http://wiki.nesdev.com/w/index.php/Mapper
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MapperAttribute : Attribute
    {
        /// <summary>
        /// Initialize a new instance of the MapperAttribute class
        /// </summary>
        /// <param name="mapperNumber">INES Mapper number</param>
        public MapperAttribute(int mapperNumber)
        {
            MapperNumber = mapperNumber;
        }

        /// <summary>
        /// INES Mapper number
        /// </summary>
        public int MapperNumber { get; private set; }
    }
}