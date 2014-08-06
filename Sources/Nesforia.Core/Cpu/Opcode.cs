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
    /// Opcodes of MOS6502 Processor
    /// </summary>
    /// <remarks>
    /// Official opcodes description: http://www.obelisk.demon.co.uk/6502/reference.html
    /// Illegal opcodes description: http://nesdev.com/undocumented_opcodes.txt
    /// </remarks>
    public enum Opcode : byte
    {
        /// <summary>
        /// Forces the generation of an interrupt request
        /// </summary>
        [OpcodeParameters(1, 7, AddressingMode.Implicit)]
        Brk = 0x00,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        Ora01 = 0x01,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill02 = 0x02,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectX)]
        IllegalSlo03 = 0x03,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        IllegalDop04 = 0x04,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Ora05 = 0x05,

        /// <summary>
        /// Arithmetic Shift Left
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        Asl06 = 0x06,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalSlo07 = 0x07,

        /// <summary>
        /// Pushes a copy of the status flags on to the stack.
        /// </summary>
        [OpcodeParameters(1, 3, AddressingMode.Implicit)]
        Php = 0x08,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        Ora09 = 0x09,

        /// <summary>
        /// Arithmetic Shift Left.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Accumulator)]
        Asl0A = 0x0A,

        /// <summary>
        /// Illegal opcode. AND byte with accumulator.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalAac0B = 0x0B,

        /// <summary>
        /// No operation (tripple NOP). The argument has no signifi-cance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        IllegalTop0C = 0x0C,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        Ora0D = 0x0D,

        /// <summary>
        /// Arithmetic Shift Left
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        Asl0E = 0x0E,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        IllegalSlo0F = 0x0F,

        /// <summary>
        /// Branch if Positive. If the negative flag is clear then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bpl = 0x10,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        Ora11 = 0x11,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill12 = 0x12,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectY)]
        IllegalSlo13 = 0x13,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        IllegalDop14 = 0x14,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        Ora15 = 0x15,

        /// <summary>
        /// Arithmetic Shift Left
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        Asl16 = 0x16,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        IllegalSlo17 = 0x17,

        /// <summary>
        /// Set the carry flag to zero.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Clc = 0x18,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        Ora19 = 0x19,

        /// <summary>
        /// Illegal No operation
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        IllegalNop1A = 0x1A,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteY)]
        IllegalSlo1B = 0x1B,

        /// <summary>
        /// Illegal opcede. No operation (tripple NOP). The argument has no signifi-cance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        IllegalTop1C = 0x1C,

        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        Ora1D = 0x1D,

        /// <summary>
        /// Arithmetic Shift Left
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        Asl1E = 0x1E,

        /// <summary>
        /// Illegal opcode. Shift left one bit in memory, then OR accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IllegalSlo1F = 0x1F,

        /// <summary>
        /// Pushes the address (minus one) of the return point on to the stack and then sets the program counter to the target memory address
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        Jsr = 0x20,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        And21 = 0x21,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill22 = 0x22,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectX)]
        IllegalRla23 = 0x23,

        /// <summary>
        /// Used to test if one or more bits are set in a target memory location.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Bit24 = 0x24,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        And25 = 0x25,

        /// <summary>
        /// Move each of the bits in either A or M one place to the right. Bit 7 is filled with the current value of the carry flag whilst the old bit 0 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        Rol26 = 0x26,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalRla27 = 0x27,

        /// <summary>
        /// Pull Processor Status
        /// </summary>
        [OpcodeParameters(1, 4, AddressingMode.Implicit)]
        Plp = 0x28,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        And29 = 0x29,

        /// <summary>
        /// Move each of the bits in either A or M one place to the left. Bit 0 is filled with the current value of the carry flag whilst the old bit 7 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Accumulator)]
        Rol2A = 0x2A,

        /// <summary>
        /// Illegal opcode. AND byte with accumulator.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalAac2B = 0x2B,

        /// <summary>
        /// Used to test if one or more bits are set in a target memory location.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.Absolute)]
        Bit2C = 0x2C,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        And2D = 0x2D,

        /// <summary>
        /// Move each of the bits in either A or M one place to the left. Bit 0 is filled with the current value of the carry flag whilst the old bit 7 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        Rol2E = 0x2E,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalRla2F = 0x2F,

        /// <summary>
        /// If the negative flag is set then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bmi = 0x30,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        And31 = 0x31,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill32 = 0x32,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectY)]
        IllegalRla33 = 0x33,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        IllegalDop34 = 0x34,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        And35 = 0x35,

        /// <summary>
        /// Move each of the bits in either A or M one place to the left. Bit 0 is filled with the current value of the carry flag whilst the old bit 7 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        Rol36 = 0x36,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        IllegalRla37 = 0x37,

        /// <summary>
        /// Set the carry flag to one.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Sec = 0x38,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        And39 = 0x39,

        /// <summary>
        /// Illegal No operation
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        IllegalNop3A = 0x3A,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteY)]
        IllegalRla3B = 0x3B,

        /// <summary>
        /// Illegal opcede. No operation (tripple NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        IllegalTop3C = 0x3C,

        /// <summary>
        /// Logical AND
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        And3D = 0x3D,

        /// <summary>
        /// Move each of the bits in either A or M one place to the left. Bit 0 is filled with the current value of the carry flag whilst the old bit 7 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        Rol3E = 0x3E,

        /// <summary>
        /// Illegal opcode. Rotate one bit left in memory, then AND accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IllegalRla3F = 0x3F,

        /// <summary>
        /// Used at the end of an interrupt processing routine. It pulls the processor flags from the stack followed by the program counter.
        /// </summary>
        [OpcodeParameters(1, 6, AddressingMode.Implicit)]
        Rti = 0x40,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        Eor41 = 0x41,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill42 = 0x42,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectX)]
        IllegalSre43 = 0x43,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        IllegalDop44 = 0x44,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Eor45 = 0x45,

        /// <summary>
        /// Each of the bits in A or M is shift one place to the right. The bit that was in bit 0 is shifted into the carry flag. Bit 7 is set to zero.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        Lsr46 = 0x46,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalSre47 = 0x47,

        /// <summary>
        /// Pushes a copy of the accumulator on to the stack.
        /// </summary>
        [OpcodeParameters(1, 3, AddressingMode.Implicit)]
        Pha = 0x48,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        Eor49 = 0x49,

        /// <summary>
        /// Each of the bits in A or M is shift one place to the right. The bit that was in bit 0 is shifted into the carry flag. Bit 7 is set to zero.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Accumulator)]
        Lsr4A = 0x4A,

        /// <summary>
        /// Illegal opcode. AND byte with accumulator, then shift right one bit in accumulator.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalAsr = 0x4B,

        /// <summary>
        /// Sets the program counter to the address specified by the operand.
        /// </summary>
        [OpcodeParameters(3, 3, AddressingMode.Absolute)]
        Jmp4C = 0x4C,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        Eor4D = 0x4D,

        /// <summary>
        /// Each of the bits in A or M is shift one place to the right. The bit that was in bit 0 is shifted into the carry flag. Bit 7 is set to zero.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        Lsr4E = 0x4E,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        IllegalSre4F = 0x4F,

        /// <summary>
        /// If the overflow flag is clear then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bvc = 0x50,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        Eor51 = 0x51,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill52 = 0x52,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectY)]
        IllegalSre53 = 0x53,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        IllegalDop54 = 0x54,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        Eor55 = 0x55,

        /// <summary>
        /// Each of the bits in A or M is shift one place to the right. The bit that was in bit 0 is shifted into the carry flag. Bit 7 is set to zero.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        Lsr56 = 0x56,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        IllegalSre57 = 0x57,

        /// <summary>
        /// Clears the interrupt disable flag allowing normal interrupt requests to be serviced.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Cli = 0x58,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        Eor59 = 0x59,

        /// <summary>
        /// Illegal No operation
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        IllegalNop5A = 0x5A,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteY)]
        IllegalSre5B = 0x5B,

        /// <summary>
        /// Illegal opcede. No operation (tripple NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        IllegalTop5C = 0x5C,

        /// <summary>
        /// Exclusive OR
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        Eor5D = 0x5D,

        /// <summary>
        /// Each of the bits in A or M is shift one place to the right. The bit that was in bit 0 is shifted into the carry flag. Bit 7 is set to zero.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        Lsr5E = 0x5E,

        /// <summary>
        /// Illegal opcode. Shift right one bit in memory, then EOR accumulator with memory.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IllegalSre5F = 0x5F,

        /// <summary>
        /// Used at the end of a subroutine to return to the calling routine. It pulls the program counter (minus one) from the stack.
        /// </summary>
        [OpcodeParameters(1, 6, AddressingMode.Implicit)]
        Rts = 0x60,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        Adc61 = 0x61,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill62 = 0x62,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectX)]
        IllegalRra63 = 0x63,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        IllegalDop64 = 0x64,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Adc65 = 0x65,

        /// <summary>
        /// Move each of the bits in either A or M one place to the right. Bit 7 is filled with the current value of the carry flag whilst the old bit 0 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        Ror66 = 0x66,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalRra67 = 0x67,

        /// <summary>
        /// Pulls an 8 bit value from the stack and into the accumulator. The zero and negative flags are set as appropriate.
        /// </summary>
        [OpcodeParameters(1, 4, AddressingMode.Implicit)]
        Pla = 0x68,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        Adc69 = 0x69,

        /// <summary>
        /// Move each of the bits in either A or M one place to the right. Bit 7 is filled with the current value of the carry flag whilst the old bit 0 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Accumulator)]
        Ror6A = 0x6A,

        /// <summary>
        /// Illegal opcode. AND byte with accumulator, then rotate one bit right in accumulator and check bit 5 and 6.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalArr = 0x6B,

        /// <summary>
        /// Sets the program counter to the address specified by the operand.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.Indirect)]
        Jmp6C = 0x6C,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        Adc6D = 0x6D,

        /// <summary>
        /// Move each of the bits in either A or M one place to the right. Bit 7 is filled with the current value of the carry flag whilst the old bit 0 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        Ror6E = 0x6E,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        IllegalRra6F = 0x6F,

        /// <summary>
        /// If the overflow flag is set then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bvs = 0x70,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        Adc71 = 0x71,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill72 = 0x72,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectY)]
        IllegalRra73 = 0x73,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        IllegalDop74 = 0x74,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        Adc75 = 0x75,

        /// <summary>
        /// Move each of the bits in either A or M one place to the right. Bit 7 is filled with the current value of the carry flag whilst the old bit 0 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        Ror76 = 0x76,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        IllegalRra77 = 0x77,

        /// <summary>
        /// Set the interrupt disable flag to one.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Sei = 0x78,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        Adc79 = 0x79,

        /// <summary>
        /// Illegal No operation
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        IllegalNop7A = 0x7A,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteY)]
        IllegalRra7B = 0x7B,

        /// <summary>
        /// Illegal opcede. No operation (tripple NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        IllegalTop7C = 0x7C,

        /// <summary>
        /// Add with Carry
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        Adc7D = 0x7D,

        /// <summary>
        /// Move each of the bits in either A or M one place to the right. Bit 7 is filled with the current value of the carry flag whilst the old bit 0 becomes the new carry flag value.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        Ror7E = 0x7E,

        /// <summary>
        /// Illegal opcode. Rotate one bit right in memory, then add memory to accumulator (with carry).
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IllegalRra7F = 0x7F,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.Immediate)]
        IllegalDop80 = 0x80,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        Sta81 = 0x81,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.Immediate)]
        IllegalDop82 = 0x82,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator and store result in memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        IllegalAax83 = 0x83,

        /// <summary>
        /// Stores the contents of the Y register into memory.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Sty84 = 0x84,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Sta85 = 0x85,

        /// <summary>
        /// Stores the contents of the X register into memory.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        Stx86 = 0x86,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator and store result in memory.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        IllegalAax87 = 0x87,

        /// <summary>
        /// Decrement Y Register
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Dey = 0x88,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.Immediate)]
        IllegalDop89 = 0x89,

        /// <summary>
        /// Copies the current contents of the X register into the accumulator.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Txa = 0x8A,

        /// <summary>
        /// Illegal opcede. Exact operation unknown. Read the referenced documents for more information and observations.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalXaa = 0x8B,

        /// <summary>
        /// Stores the contents of the Y register into memory.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        Sty8C = 0x8C,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        Sta8D = 0x8D,

        /// <summary>
        /// Stores the contents of the X register into memory.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        Stx8E = 0x8E,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator and store result in memory.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        IllegalAax8F = 0x8F,

        /// <summary>
        /// If the carry flag is clear then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bcc = 0x90,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectY)]
        Sta91 = 0x91,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKill92 = 0x92,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator then AND result with 7 and store in memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectY)]
        IllegalAxa93 = 0x93,

        /// <summary>
        /// Stores the contents of the Y register into memory.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        Sty94 = 0x94,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        Sta95 = 0x95,

        /// <summary>
        /// Stores the contents of the X register into memory.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageY)]
        Stx96 = 0x96,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator and store result in memory.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageY)]
        IllegalAax97 = 0x97,

        /// <summary>
        /// Copies the current contents of the Y register into the accumulator.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Tya = 0x98,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.AbsoluteY)]
        Sta99 = 0x99,

        /// <summary>
        /// Copies the current contents of the X register into the stack register.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Txs = 0x9A,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator and store result in stack pointer, then AND stack pointer with the high byte of the target address of theargument + 1. Store result in memory.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.AbsoluteY)]
        IllegalXas = 0x9B,

        /// <summary>
        /// Illegal opcode. AND Y register with the high byte of the target address of the argument + 1. Store the result in memory.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.AbsoluteX)]
        IllegalSya = 0x9C,

        /// <summary>
        /// Stores the contents of the accumulator into memory.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.AbsoluteX)]
        Sta9D = 0x9D,

        /// <summary>
        /// Illegal opcode. AND X register with the high byte of the target address of the argument + 1. Store the result in memory.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.AbsoluteY)]
        IllegalSxa = 0x9E,

        /// <summary>
        /// Illegal opcede. AND X register with accumulator then AND result with 7 and store in memory.
        /// </summary>
        [OpcodeParameters(3, 5, AddressingMode.AbsoluteY)]
        IllegalAxa9F = 0x9F,

        /// <summary>
        /// Loads a byte of memory into the Y register.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        LdyA0 = 0xA0,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        LdaA1 = 0xA1,

        /// <summary>
        /// Loads a byte of memory into the X register.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        LdxA2 = 0xA2,

        /// <summary>
        /// Illegal opcode. Load accumulator and X register with memory.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        IllegalLaxA3 = 0xA3,

        /// <summary>
        /// Loads a byte of memory into the Y register.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        LdyA4 = 0xA4,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        LdaA5 = 0xA5,

        /// <summary>
        /// Loads a byte of memory into the X register.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        LdxA6 = 0xA6,

        /// <summary>
        /// Illegal opcode. Load accumulator and X register with memory.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        IllegalLaxA7 = 0xA7,

        /// <summary>
        /// Copies the current contents of the accumulator into the Y register.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Tay = 0xA8,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        LdaA9 = 0xA9,

        /// <summary>
        /// Copies the current contents of the accumulator into the X register.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Tax = 0xAA,

        /// <summary>
        /// Illegal opcode. AND byte with accumulator, then transfer accumulator to X register.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalAtx = 0xAB,

        /// <summary>
        /// Loads a byte of memory into the Y register.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        LdyAc = 0xAC,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        LdaAd = 0xAD,

        /// <summary>
        /// Loads a byte of memory into the X register.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        LdxAe = 0xAE,

        /// <summary>
        /// Illegal opcode. Load accumulator and X register with memory.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        IllegalLaxAf = 0xAF,

        /// <summary>
        /// If the carry flag is set then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bcs = 0xB0,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        LdaB1 = 0xB1,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKillB2 = 0xB2,

        /// <summary>
        /// Illegal opcode. Load accumulator and X register with memory.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        IllegalLaxB3 = 0xB3,

        /// <summary>
        /// Loads a byte of memory into the Y register.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        LdyB4 = 0xB4,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        LdaB5 = 0xB5,

        /// <summary>
        /// Loads a byte of memory into the X register.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageY)]
        LdxB6 = 0xB6,

        /// <summary>
        /// Illegal opcode. Load accumulator and X register with memory.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageY)]
        IllegalLaxB7 = 0xB7,

        /// <summary>
        /// Clears the overflow flag.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Clv = 0xB8,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        LdaB9 = 0xB9,

        /// <summary>
        /// Copies the current contents of the stack register into the X register.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Tsx = 0xBA,

        /// <summary>
        /// Illegal opcode. AND memory with stack pointer, transfer result to accumulator, X register and stack pointer.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        IllegalLar = 0xBB,

        /// <summary>
        /// Loads a byte of memory into the Y register.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        LdyBc = 0xBC,

        /// <summary>
        /// Loads a byte of memory into the accumulator.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        LdaBd = 0xBD,

        /// <summary>
        /// Loads a byte of memory into the X register.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        LdxBe = 0xBE,

        /// <summary>
        /// Illegal opcode. Load accumulator and X register with memory.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        IllegalLaxBf = 0xBF,

        /// <summary>
        /// Compares the contents of the Y register with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        CpyC0 = 0xC0,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        CmpC1 = 0xC1,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.Immediate)]
        IllegalDopC2 = 0xC2,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectX)]
        IllegalDcpC3 = 0xC3,

        /// <summary>
        /// Compares the contents of the Y register with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        CpyC4 = 0xC4,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        CmpC5 = 0xC5,

        /// <summary>
        /// Subtracts one from the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        DecC6 = 0xC6,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalDcpC7 = 0xC7,

        /// <summary>
        /// Adds one to the Y register setting.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Iny = 0xC8,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        CmpC9 = 0xC9,

        /// <summary>
        /// Subtracts one from the X register setting.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Dex = 0xCA,

        /// <summary>
        /// AND X register with accumulator and store result in X regis-ter, then subtract byte from X register (without borrow).
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalAxs = 0xCB,

        /// <summary>
        /// Compares the contents of the Y register with another memory held value.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        CpyCc = 0xCC,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        CmpCd = 0xCD,

        /// <summary>
        /// Subtracts one from the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        DecCe = 0xCE,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        IllegalDcpCf = 0xCF,

        /// <summary>
        /// If the zero flag is clear then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Bne = 0xD0,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        CmpD1 = 0xD1,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKillD2 = 0xD2,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectY)]
        IllegalDcpD3 = 0xD3,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        IllegalDopD4 = 0xD4,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        CmpD5 = 0xD5,

        /// <summary>
        /// Subtracts one from the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        DecD6 = 0xD6,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(2, 7, AddressingMode.ZeroPageX)]
        IllegalDcpD7 = 0xD7,

        /// <summary>
        /// Sets the decimal mode flag to zero.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Cld = 0xD8,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        CmpD9 = 0xD9,

        /// <summary>
        /// Illegal No operation
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        IllegalNopDa = 0xDA,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteY)]
        IllegalDcpDb = 0xDB,

        /// <summary>
        /// Illegal opcede. No operation (tripple NOP). The argument has no signifi-cance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        IllegalTopDc = 0xDC,

        /// <summary>
        /// Compares the contents of the accumulator with another memory held value.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        CmpDd = 0xDD,

        /// <summary>
        /// Subtracts one from the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        DecDe = 0xDE,

        /// <summary>
        /// Illegal opcode. Subtract 1 from memory (without borrow).
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IllegalDcpDf = 0xDF,

        /// <summary>
        /// Compares the contents of the X register with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        CpxE0 = 0xE0,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.IndirectX)]
        SbcE1 = 0xE1,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.Immediate)]
        IllegalDopE2 = 0xE2,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectX)]
        IllegalIscE3 = 0xE3,

        /// <summary>
        /// Compares the contents of the X register with another memory held value.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        CpxE4 = 0xE4,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(2, 3, AddressingMode.ZeroPage)]
        SbcE5 = 0xE5,

        /// <summary>
        /// Adds one to the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IncE6 = 0xE6,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.ZeroPage)]
        IllegalIscE7 = 0xE7,

        /// <summary>
        /// Adds one to the X register.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Inx = 0xE8,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        SbcE9 = 0xE9,

        /// <summary>
        /// The NOP instruction causes no changes to the processor other than the normal incrementing of the program counter to the next instruction.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Nop = 0xEA,

        /// <summary>
        /// Illegal opcode. The same as the legal opcode <see cref="SbcE9"/>
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Immediate)]
        IllegalSbc = 0xEB,

        /// <summary>
        /// Compares the contents of the X register with another memory held value.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        CpxEc = 0xEC,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.Absolute)]
        SbcEd = 0xED,

        /// <summary>
        /// Adds one to the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        IncEe = 0xEE,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(3, 6, AddressingMode.Absolute)]
        IllegalIscEf = 0xEF,

        /// <summary>
        /// If the zero flag is set then add the relative displacement to the program counter to cause a branch to a new location.
        /// </summary>
        [OpcodeParameters(2, 2, AddressingMode.Relative)]
        Beq = 0xF0,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(2, 5, AddressingMode.IndirectY)]
        SbcF1 = 0xF1,

        /// <summary>
        /// Illegal opcode. Stop program counter (processor lock up).
        /// </summary>
        [OpcodeParameters(1, 0, AddressingMode.Implicit)]
        IllegalKillF2 = 0xF2,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(2, 8, AddressingMode.IndirectY)]
        IllegalIscF3 = 0xF3,

        /// <summary>
        /// Illegal opcode. No operation (double NOP). The argument has no significance.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        IllegalDopF4 = 0xF4,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(2, 4, AddressingMode.ZeroPageX)]
        SbcF5 = 0xF5,

        /// <summary>
        /// Adds one to the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        IncF6 = 0xF6,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(2, 6, AddressingMode.ZeroPageX)]
        IllegalIscF7 = 0xF7,

        /// <summary>
        /// Set the decimal mode flag to one.
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        Sed = 0xF8,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteY)]
        SbcF9 = 0xF9,

        /// <summary>
        /// Illegal No operation
        /// </summary>
        [OpcodeParameters(1, 2, AddressingMode.Implicit)]
        IllegalNopFa = 0xFA,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteY)]
        IllegalIscFb = 0xFb,

        /// <summary>
        /// Illegal opcede. No operation (tripple NOP). The argument has no signifi-cance.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        IllegalTopFc = 0xFC,

        /// <summary>
        /// Subtracts the contents of a memory location to the accumulator together with the not of the carry bit.
        /// </summary>
        [OpcodeParameters(3, 4, AddressingMode.AbsoluteX)]
        SbcFd = 0xFD,

        /// <summary>
        /// Adds one to the value held at a specified memory location.
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IncFe = 0xFE,

        /// <summary>
        /// Illegal opcode. Increase memory by one, then subtract memory from accumulator (withborrow).
        /// </summary>
        [OpcodeParameters(3, 7, AddressingMode.AbsoluteX)]
        IllegalIscFf = 0xFF,
    }
}