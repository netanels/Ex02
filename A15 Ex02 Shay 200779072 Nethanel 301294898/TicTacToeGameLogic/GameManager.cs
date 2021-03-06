﻿namespace TicTacToeGameLogic
{
    public class GameManager
    {
        private GameLogic m_GameLogic;

        public Enums.eGameFinishState GameState
        {
            get { return m_GameLogic.GameState; }
        }

        public Enums.eGameType GameType
        {
            get { return m_GameLogic.GameType; }
        }

        public int BoardSize
        {
            get { return m_GameLogic.BoradSize; }
        }

        public Board.BoardGameCell[,] BoardCells
        {
            get { return m_GameLogic.BoradCells; }
        }

        public int PlayerOnePoints
        {
            get { return m_GameLogic.FirstPlayerPoints; }
        }

        public int PlayerTwoPoints
        {
            get { return m_GameLogic.SecondePlayerPoints; }
        }

        public Enums.ePlayer CurrentPlayerTurn
        {
            get { return m_GameLogic.CurrentPlayerTurn; }
        }

        public void InitializeGame(int i_BoardSize, Enums.eGameType i_GameType, ref string io_ErrorMessage)
        {
            if (i_BoardSize < GameLogic.k_MinimumBoardSize || i_BoardSize > GameLogic.k_MaximumBoardSize)
            {
                io_ErrorMessage = "Board size is illegal!";
            }
            else if (i_GameType != Enums.eGameType.PlayerVsComputer
                     && i_GameType != Enums.eGameType.PlayerVsPlayer)
            {
                io_ErrorMessage = "Game type is illegal!";
            }
            else
            {
                m_GameLogic = new GameLogic(i_BoardSize, i_GameType);
            }
        }

        public void InitializeRound()
        {
            m_GameLogic.InitializeRound();
        }

        public void SetNextMove(int i_RowIndex, int i_ColumnIndex, ref string io_ErrorMessage, out bool o_RoundIsOver)
        {
            if (i_RowIndex < 0 || i_RowIndex >= BoardSize || i_ColumnIndex < 0 || i_ColumnIndex >= BoardSize)
            {
                io_ErrorMessage = "You selected a cell outside of the board boundaries!";
                o_RoundIsOver = false;
            }
            else
            {
                Board.BoardGameCell wantedBoardGameCell = BoardCells[i_RowIndex, i_ColumnIndex];
                if (!wantedBoardGameCell.IsFree)
                {
                    io_ErrorMessage = "This cell is already taken!";
                    o_RoundIsOver = false;
                }
                else
                {
                    m_GameLogic.NextPlayerMove(wantedBoardGameCell, out o_RoundIsOver);
                }
            }
        }

        public void UserQuit()
        {
            m_GameLogic.UserQuit();
        }
    }
}