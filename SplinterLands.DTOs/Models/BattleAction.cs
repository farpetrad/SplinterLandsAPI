﻿using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public class BattleAction
    {
        public string Type { get; set; } = string.Empty;
        public string? Result { get; set; } = null;
        public string? Initiator { get; set; } = null;
        public string Target { get; set; } = string.Empty;
        public int? Damage { get; set; } = null;
        public BattleActionState? State { get; set; } = null;
        public string? Hit_Chance { get; set; } = null;
        public double? Hit_Value { get; set; } = null;
    }
}
