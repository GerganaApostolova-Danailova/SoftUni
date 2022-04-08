﻿namespace AquaShop.Utilities.Messages
{
    using System;

    public static class ExceptionMessages
    {
        public const string InvalidFishType = "Invalid fish type.";

        public const string InvalidFishName = "Fish name cannot be null or empty.";//

        public const string InvalidFishSpecies = "Fish species cannot be null or empty.";//

        public const string InvalidFishPrice = "Fish price cannot be below or equal to 0.";//

        public const string InexistentFish = "There isn’t a fish with the name {0} in {1}.";

        public const string InvalidAquariumType = "Invalid aquarium type.";

        public const string InvalidAquariumName = "Aquarium name cannot be null or empty.";//

        public const string InvalidAquariumCapacity = "Aquarium capacity cannot be below or equal to 0.";

        public const string InvalidDecorationType = "Invalid decoration type.";

        public const string InexistentDecoration = "There isn’t a decoration of type {0}.";
    }
}
