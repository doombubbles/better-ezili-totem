using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using BetterEziliTotem;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

[assembly: MelonInfo(typeof(BetterEziliTotemMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BetterEziliTotem;

public class BetterEziliTotemMod : BloonsTD6Mod
{
    private static readonly ModSettingDouble AbilityCooldown = new(60)
    {
        displayName = "Totem Ability Cooldown",
        min = 0,
        icon = VanillaSprites.SacrificialTotemAA,
        description = "In case you think the ability should have a longer cooldown to compensate for being more powerful."
    };

    public override void OnNewGameModel(GameModel gameModel)
    {
        for (var i = 7; i <= 20; i++)
        {
            var towerModel = gameModel.GetTowerFromId(TowerType.Ezili + " " + i);
            var ability = towerModel.GetAbilities().First(b => b.name.Contains("Totem"));

            ability.livesCost = 0;
            ability.Cooldown = AbilityCooldown;
        }
    }
}