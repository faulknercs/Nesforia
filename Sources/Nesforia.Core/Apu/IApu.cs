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
namespace Nesforia.Core.Apu
{
    /// <summary>
    /// Interface of Audio Processing Unit in the NES console, which is responsible for generating sound for games.
    /// </summary>
    /// <remarks>
    /// Detailed description: http://wiki.nesdev.com/w/index.php/APU
    /// </remarks>
    public interface IApu
    {
        /// <summary>
        /// Duty (D), envelope loop / length counter halt (L), constant volume (C), volume/envelope (V) for square wave 1
        /// </summary>
        /// <param name="value">DDLC NNNN</param>
        void Write4000(byte value);

        /// <summary>
        /// Sweep unit for square wave 1: enabled (E), period (P), negate (N), shift (S) 
        /// </summary>
        /// <param name="value">EPPP NSSS</param>
        void Write4001(byte value);

        /// <summary>
        /// Low byte of period for square wave 1 
        /// </summary>
        /// <param name="value">Value of low byte</param>
        void Write4002(byte value);

        /// <summary>
        /// High byte of period (T) and length counter (L) value for square wave 1
        /// </summary>
        /// <param name="value">LLLL LTTT</param>
        void Write4003(byte value);

        /// <summary>
        /// Duty (D), envelope loop / length counter halt (L), constant volume (C), volume/envelope (V) for square wave 2
        /// </summary>
        /// <param name="value">DDLC NNNN</param>
        void Write4004(byte value);

        /// <summary>
        /// Sweep unit for square wave 2: enabled (E), period (P), negate (N), shift (S) 
        /// </summary>
        /// <param name="value">EPPP NSSS</param>
        void Write4005(byte value);

        /// <summary>
        /// Low byte of period for square wave 2
        /// </summary>
        /// <param name="value">Value of low byte</param>
        void Write4006(byte value);

        /// <summary>
        /// High byte of period (T) and length counter (L) value for square wave 2
        /// </summary>
        /// <param name="value">LLLL LTTT</param>
        void Write4007(byte value);

        /// <summary>
        /// Length counter halt / linear counter control (C), linear counter load (R) for triangle wave
        /// </summary>
        /// <param name="value">CRRR RRRR</param>
        void Write4008(byte value);

        /// <summary>
        /// Low byte of period for triangle wave
        /// </summary>
        /// <param name="value">Value of low byte</param>
        void Write400A(byte value);

        /// <summary>
        /// High byte of period (T) and length counter (L) value for triangle wave
        /// </summary>
        /// <param name="value">LLLL LTTT</param>
        void Write400B(byte value);

        /// <summary>
        /// Envelope loop / length counter halt (L), constant volume (C), volume/envelope (V) for noise generator
        /// </summary>
        /// <param name="value">--LC VVVV</param>
        void Write400C(byte value);

        /// <summary>
        /// Loop noise (L), noise period (P) for noise generator
        /// </summary>
        /// <param name="value">L--- PPPP</param>
        void Write400E(byte value);

        /// <summary>
        /// Length counter load (L) for noise generator
        /// </summary>
        /// <param name="value">LLLL L---</param>
        void Write400F(byte value);

        /// <summary>
        /// IRQ enable (I), loop (L), frequency (R) for DMC channel
        /// </summary>
        /// <param name="value">IL-- RRRR</param>
        void Write4010(byte value);

        /// <summary>
        /// Load counter (D) for DMC channel
        /// </summary>
        /// <param name="value">-DDD DDDD</param>
        void Write4011(byte value);

        /// <summary>
        /// Writes start of DMC waveform (at address $C000 + $40*$xx)
        /// </summary>
        /// <param name="value">Part of adress (11xxxxxx.xx000000)</param>
        void Write4012(byte value);

        /// <summary>
        /// Writes length of DMC waveform.
        /// </summary>
        /// <param name="value">Length (0000LLLL.LLLL0001)</param>
        void Write4013(byte value);

        /// <summary>
        /// Writes enable chanels flags (Enable DMC (D), noise (N), triangle (T), and pulse channels (2/1))
        /// </summary>
        /// <param name="value">---D NT21</param>
        void Write4015(byte value);

        /// <summary>
        /// Reads status of channels (DMC interrupt (I), frame interrupt (F), DMC active (D), length counter > 0 (N/T/2/1))
        /// </summary>
        /// <returns>IF-D NT21</returns>
        byte Read4015();

        /// <summary>
        /// Frame counter control (Mode (M, 0 = 4-step, 1 = 5-step), IRQ inhibit flag (I))
        /// </summary>
        /// <param name="value">MI-- ----</param>
        void Write4017(byte value);
    }
}