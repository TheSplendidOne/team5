using System;

namespace thegame.Models
{
    public class GameDto
    {
        public GameDto(GameBoard board, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score)
        {
            Board = board;
            MonitorKeyboard = monitorKeyboard;
            MonitorMouseClicks = monitorMouseClicks;
            Width = width;
            Height = height;
            Id = id;
            IsFinished = isFinished;
            Score = score;
        }

        public GameBoard Board;
        public int Width;
        public int Height;
        public bool MonitorKeyboard;
        public bool MonitorMouseClicks;
        public Guid Id;
        public bool IsFinished;
        public int Score;
    }
}