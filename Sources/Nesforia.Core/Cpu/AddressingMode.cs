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
namespace Nesforia.Core.Cpu
{
    /// <summary>
    /// Addressing modes of MOS6502 processor
    /// </summary>
    /// <remarks>
    /// Detailed description of addressing modes: http://www.obelisk.demon.co.uk/6502/addressing.html
    /// </remarks>
    public enum AddressingMode
    {
        /// <summary>
        /// The source and destination of the information to be manipulated is implied directly by the function of the instruction itself
        /// and no further operand needs to be specified.
        /// </summary>
        Implicit,

        /// <summary>
        /// Instruction operates directly with accumulator register.
        /// </summary>
        Accumulator,

        /// <summary>
        /// Instruction operates with directly specified 8 bit constant.
        /// </summary>
        Immediate,

        /// <summary>
        /// An instruction using zero page addressing mode has only an 8 bit address operand. This limits it to addressing only the first 256 bytes of memory.
        /// </summary>
        ZeroPage,

        /// <summary>
        /// The address to be accessed by an instruction using indexed zero page addressing is calculated by taking the 8 bit zero page address from the instruction 
        /// and adding the current value of the X register to it.
        /// </summary>
        ZeroPageX,

        /// <summary>
        /// The address to be accessed by an instruction using indexed zero page addressing is calculated by taking the 8 bit zero page address from the instruction 
        /// and adding the current value of the Y register to it.
        /// </summary>
        ZeroPageY,

        /// <summary>
        /// Relative addressing mode is used by branch instructions which contain a signed 8 bit relative offset (e.g. -128 to +127) 
        /// which is added to program counter if the condition is true. As the program counter itself is incremented during instruction execution by two the effective address range 
        /// for the target instruction must be with -126 to +129 bytes of the branch.
        /// </summary>
        Relative,

        /// <summary>
        /// Instructions using absolute addressing contain a full 16 bit address to identify the target location.
        /// </summary>
        Absolute,

        /// <summary>
        /// The address to be accessed by an instruction using X register indexed absolute addressing is computed by taking the 16 bit address 
        /// from the instruction and added the contents of the X register.
        /// </summary>
        AbsoluteX,

        /// <summary>
        /// The address to be accessed by an instruction using Y register indexed absolute addressing is computed by taking the 16 bit address 
        /// from the instruction and added the contents of the Y register.
        /// </summary>
        AbsoluteY,

        /// <summary>
        /// JMP is the only 6502 instruction to support indirection. The instruction contains a 16 bit address which identifies the 
        /// location of the least significant byte of another 16 bit memory address which is the real target of the instruction.
        /// </summary>
        Indirect,

        /// <summary>
        /// Indexed indirect addressing is normally used in conjunction with a table of address held on zero page. 
        /// The address of the table is taken from the instruction and the X register added to it (with zero page wrap around) 
        /// to give the location of the least significant byte of the target address.
        /// </summary>
        IndirectX,

        /// <summary>
        /// Indirect indirect addressing is the most common indirection mode used on the 6502. 
        /// In instruction contains the zero page location of the least significant byte of 16 bit address. 
        /// The Y register is dynamically added to this value to generated the actual target address for operation.
        /// </summary>
        IndirectY
    }
}