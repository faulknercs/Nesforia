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
using Nesforia.Core.IO;
using Nesforia.Core.Memory;
using Nesforia.Core.Ppu;

namespace Nesforia.Interpreter.Ppu
{
    public class Ppu : IPpu
    {
        private readonly IMemory _vram;
        private readonly IGraphicsDevice _graphicsDevice;

        public Ppu(IGraphicsDevice graphicsDevice, IMemory vram)
        {
            _graphicsDevice = graphicsDevice;
            _vram = vram;
        }

        public byte Read2002()
        {
            throw new System.NotImplementedException();
        }

        public byte Read2004()
        {
            throw new System.NotImplementedException();
        }

        public byte Read2007()
        {
            throw new System.NotImplementedException();
        }

        public void Write2000(byte value)
        {
            throw new System.NotImplementedException();
        }

        public void Write2001(byte value)
        {
            throw new System.NotImplementedException();
        }

        public void Write2003(byte value)
        {
            throw new System.NotImplementedException();
        }

        public void Write2004(byte value)
        {
            throw new System.NotImplementedException();
        }

        public void Write2005(byte value)
        {
            throw new System.NotImplementedException();
        }

        public void Write2006(byte value)
        {
            throw new System.NotImplementedException();
        }

        public void Write2007(byte value)
        {
            throw new System.NotImplementedException();
        }
    }
}