// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Appearance.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Appearance type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Messaging.GameData
{
    using SmokeLounge.AOtomation.Messaging.Serialization.MappingAttributes;

    public class Appearance
    {
        #region Fields

        private Breed breed;

        private Fatness fatness;

        private Gender gender;

        private uint race;

        private Side side;

        private uint value;

        #endregion

        #region AoMember Properties

        [AoMember(0)]
        public uint Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                this.UpdateStats();
            }
        }

        #endregion

        #region Public Properties

        public Breed Breed
        {
            get
            {
                return this.breed;
            }

            set
            {
                this.breed = value;
                this.UpdateValue();
            }
        }

        public Fatness Fatness
        {
            get
            {
                return this.fatness;
            }

            set
            {
                this.fatness = value;
                this.UpdateValue();
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
                this.UpdateValue();
            }
        }

        public uint Race
        {
            get
            {
                return this.race;
            }

            set
            {
                this.race = value;
                this.UpdateValue();
            }
        }

        public Side Side
        {
            get
            {
                return this.side;
            }

            set
            {
                this.side = value;
                this.UpdateValue();
            }
        }

        #endregion

        #region Methods

        private void UpdateStats()
        {
            var sideValue = this.value & 7;
            this.side = (Side)sideValue;
            var fatnessValue = (this.value & 31) >> 3;
            this.fatness = (Fatness)fatnessValue;
            var breedValue = (this.value & 255) >> 5;
            this.breed = (Breed)breedValue;
            var genderValue = (this.value & 1023) >> 8;
            this.gender = (Gender)genderValue;
            var raceValue = this.value >> 10;
            this.race = raceValue;
        }

        private void UpdateValue()
        {
            var sideValue = (uint)this.side;
            var fatnessValue = (uint)this.fatness << 3;
            var breedValue = (uint)this.breed << 5;
            var genderValue = (uint)this.gender << 8;
            var raceValue = this.race << 10;
            this.value = sideValue + fatnessValue + breedValue + genderValue + raceValue;
        }

        #endregion
    }
}