using SplinterLands.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLandsAPI
{
    public interface IBattlesClient
    {
        PlayerBattles GetBattlesForPlayer(string playerName);
    }
}
