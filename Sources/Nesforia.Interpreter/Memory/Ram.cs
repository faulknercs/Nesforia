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
using System.Linq;
using Nesforia.Core.Memory;

namespace Nesforia.Interpreter.Memory
{
    public class Ram : IMemory
    {
        private readonly byte[] _systemRam = new byte[0x800];

        private readonly IDictionary<int, Func<byte>> _readMapping = new Dictionary<int, Func<byte>>();
        private readonly IDictionary<int, Action<byte>> _writeMapping = new Dictionary<int, Action<byte>>();

        private readonly IDictionary<int, Func<int, byte>> _readRangeMapping = new Dictionary<int, Func<int, byte>>();
        private readonly IDictionary<int, Action<int, byte>> _writeRangeMapping = new Dictionary<int, Action<int, byte>>();

        public Ram()
        {
            Map(0x0000, 0x1FFF, ReadSystemRam, WriteSystemRam);
        }

        public void Map(int address, Func<byte> readCallback, Action<byte> writeCallback)
        {
            _readMapping[address] = readCallback;
            _writeMapping[address] = writeCallback;
        }

        public void Map(int startAddress, int endAddress, Func<int, byte> readCallback, Action<int, byte> writeCallback)
        {
            _readRangeMapping[startAddress] = _readRangeMapping[endAddress] = readCallback;

            _writeRangeMapping[startAddress] = _writeRangeMapping[endAddress] = writeCallback;
        }

        public byte Read(int address)
        {
            if (address < 0 || address > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("address", String.Format("Trying read from invalid address: {0:X}", address));
            }

            address = PrepareAddress(address);

            if (_readMapping.ContainsKey(address))
            {
                return _readMapping[address]();
            }

            var addresses = _readRangeMapping.Keys.Where(x => x <= address).ToList();

            if (!addresses.Any())
            {
                throw new ArgumentOutOfRangeException("address", String.Format("Handler for address {0:X} not found", address));
            }

            int key = addresses.Max();
            return _readRangeMapping[key](address);
        }

        public void Write(int address, byte value)
        {
            if (address < 0 || address > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("address", "Trying write to invalid address");
            }

            address = PrepareAddress(address);

            if (_readMapping.ContainsKey(address))
            {
                _writeMapping[address](value);
                return;
            }

            var addresses = _writeRangeMapping.Keys.Where(x => x <= address).ToList();

            if (!addresses.Any())
            {
                throw new ArgumentOutOfRangeException("address", String.Format("Handler for address {0:X} not found", address));
            }

            int key = addresses.Max();
            _writeMapping[key](value);
        }

        private int PrepareAddress(int address)
        {
            if (address < 0x2000)
            {
                return address & 0x07FF;
            }

            if(address < 0x4000)
            {
                return address & 0x2007;
            }

            return address;
        }

        private void WriteSystemRam(int address, byte value)
        {
            _systemRam[address] = value;
        }

        private byte ReadSystemRam(int address)
        {
            return _systemRam[address];
        }
    }
}