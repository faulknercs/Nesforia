#region License
/****************************************************************************
* Nesforia.Interpreter - NES/Famicom emulator interpreter implementation
*
* Copyright (C) 2014 Nesforia authors
*
* Authors: Artem Stepanyuk <faulknercs@yandex.ru>
*
* This file is part of Nesforia.Interpreter.
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
using System.Collections.Generic;
using Nesforia.Core.Memory;

namespace Nesforia.Interpreter.Memory
{
    public class Ram : IMemory
    {
        private readonly byte[] _systemRam = new byte[0x2000];

        private readonly IDictionary<int, Func<byte>> _readMapping;
        private readonly IDictionary<int, Action<byte>> _writeMapping;

        public void Map(int address, Func<byte> readCallback, Action<byte> writeCallback)
        {
            _readMapping[address] = readCallback;
            _writeMapping[address] = writeCallback;
        }

        public void Map(int startAdress, int endAdress, Func<int, byte> readCallback, Action<int, byte> writeCallback)
        {
            throw new NotImplementedException();
        }

        public byte Read(int address)
        {
            return _readMapping[address]();
        }

        public void Write(int address, byte value)
        {
            _writeMapping[address](value);
        }
    }
}