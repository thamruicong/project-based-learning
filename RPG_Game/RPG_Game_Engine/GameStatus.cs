using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public static class GameStatus
    {
        #region Game Variables

        public enum GameVariables
        {
            ATTACK_SUCCESS,
            ATTACK_FAILURE,
            INSUFFICIENT_ITEM_QUANTITY,
            ZERO_ITEM_QUANTITY
        }

        #endregion
    }
}