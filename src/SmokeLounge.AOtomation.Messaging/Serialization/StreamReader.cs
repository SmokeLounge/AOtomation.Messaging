// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamReader.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the StreamReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    public sealed class StreamReader : IDisposable
    {
        #region Fields

        private readonly BinaryReader reader;

        private readonly Stream stream;

        #endregion

        #region Constructors and Destructors

        public StreamReader(Stream stream)
        {
            this.stream = stream;
            this.reader = new BinaryReader(stream);
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
            this.reader.Dispose();
            this.stream.Dispose();
        }

        public byte ReadByte()
        {
            return this.reader.ReadByte();
        }

        public short ReadInt16()
        {
            return IPAddress.NetworkToHostOrder(this.reader.ReadInt16());
        }

        public int ReadInt32()
        {
            return IPAddress.NetworkToHostOrder(this.reader.ReadInt32());
        }

        public long ReadInt64()
        {
            return IPAddress.NetworkToHostOrder(this.reader.ReadInt64());
        }

        public float ReadSingle()
        {
            var single = this.reader.ReadBytes(4);
            Array.Reverse(single);
            return BitConverter.ToSingle(single, 0);
        }

        public string ReadString(int length)
        {
            var bytes = this.reader.ReadBytes(length);
            return Encoding.ASCII.GetString(bytes);
        }

        public ushort ReadUInt16()
        {
            var littleEndian = this.reader.ReadUInt16() << 16;
            return (ushort)IPAddress.NetworkToHostOrder(littleEndian);
        }

        public uint ReadUInt32()
        {
            var littleEndian = this.reader.ReadUInt32() << 32;
            return (uint)IPAddress.NetworkToHostOrder(littleEndian);
        }

        #endregion
    }
}