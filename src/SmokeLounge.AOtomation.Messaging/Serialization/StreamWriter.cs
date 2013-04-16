// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamWriter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StreamWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    public sealed class StreamWriter : IDisposable
    {
        #region Fields

        private readonly Stream stream;

        private readonly BinaryWriter writer;

        #endregion

        #region Constructors and Destructors

        public StreamWriter(Stream stream)
        {
            this.stream = stream;
            this.writer = new BinaryWriter(this.stream);
        }

        #endregion

        #region Public Properties

        public long Position
        {
            get
            {
                return this.stream.Position;
            }

            set
            {
                this.stream.Position = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Dispose()
        {
            this.writer.Dispose();
            this.stream.Dispose();
        }

        public void WriteByte(byte value)
        {
            this.writer.Write(value);
        }

        public void WriteBytes(byte[] buffer)
        {
            this.writer.Write(buffer);
        }

        public void WriteInt16(short value)
        {
            this.writer.Write(IPAddress.HostToNetworkOrder(value));
        }

        public void WriteInt32(int value)
        {
            this.writer.Write(IPAddress.HostToNetworkOrder(value));
        }

        public void WriteInt64(long value)
        {
            this.writer.Write(IPAddress.HostToNetworkOrder(value));
        }

        public void WriteSingle(float value)
        {
            var single = BitConverter.GetBytes(value);
            Array.Reverse(single);
            this.writer.Write(single);
        }

        public void WriteString(string str, int? padToLength = null)
        {
            var bytes = new byte[padToLength ?? str.Length];
            var length = str.Length > bytes.Length ? bytes.Length : str.Length;
            Encoding.ASCII.GetBytes(str, 0, length, bytes, 0);
            this.writer.Write(bytes);
        }

        public void WriteUInt16(ushort value)
        {
            var bigEndian = IPAddress.HostToNetworkOrder(value) >> 16;
            this.writer.Write((ushort)bigEndian);
        }

        public void WriteUInt32(uint value)
        {
            var bigEndian = IPAddress.HostToNetworkOrder(value) >> 32;
            this.writer.Write((uint)bigEndian);
        }

        #endregion
    }
}