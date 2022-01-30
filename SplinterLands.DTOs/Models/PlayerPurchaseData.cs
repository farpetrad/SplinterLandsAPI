namespace SplinterLands.DTOs.Models
{
    public class PlayerPurchaseData
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Join_Date { get; set; } = null;
        public int Rating { get; set; } = -1;
        public int Battles { get; set; } = -1;
        public int Wins { get; set; } = -1;
        public int Current_Streak { get; set; } = -1;
        public int Longest_Streak { get; set; } = -1;
        public int Max_Rating { get; set; } = -1;
        public int Max_Rank { get; set; } = -1;
        public int Champion_Points { get; set; } = -1;
        public int Capture_Rate { get; set; } = -1;
        public Int64 Last_Reward_Block { get; set; } = -1;
        public DateTime? Last_Reward_Time { get; set; } = null;
        public string? Guild { get; set; } = null;
        public string? Guild_Name { get; set; } = null;
        public string? Guild_Motto { get; set; } = null;
        public string? Guild_Data { get; set; } = null;
        public string? Guild_Level { get; set; } = null;
        public string? Guild_Quest_Lodge_Level { get; set; } = null;
        public bool Starter_Pack_Purchase { get; set; } = false;
        public int Avatar_Id { get; set; } = -1;
        public string? Display_Name { get; set; } = null;
        public string? Title_Pre { get; set; } = null;
        public string? Title_Post { get; set; } = null;
        public int Collection_Power { get; set; } = -1;
        public int League { get; set; } = -1;
        public bool Adv_Msg_Sent { get; set; } = false;
        public string? Alt_Name { get; set; } = null;
    }
}
