using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA14
{
    class Player
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public int ClubId { get; set; }
        public int LeagueId { get; set; }
        public int NationId { get; set; }

        public int Height { get; set; }
        public string Foot { get; set; }

        public int AttackWorkrate { get; set; }
        public int DefensiveWorkrate { get; set; }

        public int WeakFoot { get; set; }
        public int SkillMoves { get; set; }

        #region Skills

        public int BallControl { get; set; }
        public int Crossing { get; set; }
        public int Curve { get; set; }
        public int Dribbling { get; set; }
        public int Finishing { get; set; }
        public int FreeKickAcc { get; set; }
        public int HeadingAcc { get; set; }
        public int LongPassing { get; set; }
        public int LongShots { get; set; }
        public int Marking { get; set; }
        public int Penalties { get; set; }
        public int ShortPassing { get; set; }
        public int ShotPower { get; set; }
        public int SlidingTackle { get; set; }
        public int StandingTackle { get; set; }
        public int Volleys { get; set; }

        #endregion

        #region Physical

        public int Acceleration { get; set; }
        public int Agility { get; set; }
        public int Balance { get; set; }
        public int Jumping { get; set; }
        public int Reactions { get; set; }
        public int SprintSpeed { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }

        #endregion

        #region Mental

        public int Aggression { get; set; }
        public int Positioning { get; set; }
        public int Interceptions { get; set; }
        public int Vision { get; set; }

        #endregion

        public int Overall { get; set; }

        public int PAC { get; set; }
        public int SHO { get; set; }
        public int PAS { get; set; }
        public int DRI { get; set; }
        public int DEF { get; set; }
        public int HEA { get; set; }

        public int TotalStats { get; set; }

        public int PriceOnPlayStation { get; set; }
        public int PriceOnXbox { get; set; }
        public int PriceOnPC { get; set; }

    }
}
