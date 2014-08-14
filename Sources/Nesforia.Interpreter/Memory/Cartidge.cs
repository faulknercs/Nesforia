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
using Nesforia.Core.Loaders;
using Nesforia.Core.Memory;

namespace Nesforia.Interpreter.Memory
{
    public class Cartidge : ICartridge
    {
        public Cartidge(RomData romData)
        {
            
        }
        
        public bool HasSaveRam { get; private set; }
        public bool HasTrainer { get; private set; }
        
        public byte ReadPrg(int address)
        {
            throw new System.NotImplementedException();
        }

        public byte ReadChr(int address)
        {
            throw new System.NotImplementedException();
        }

        public void WritePrg(int address, byte value)
        {
            throw new System.NotImplementedException();
        }

        public void WriteChr(int address, byte value)
        {
            throw new System.NotImplementedException();
        }
    }
}