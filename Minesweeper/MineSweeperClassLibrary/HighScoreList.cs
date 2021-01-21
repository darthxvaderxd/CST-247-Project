/*
 * Minesweeper Milestone 6
 * Shawn Fradet
 * CST-227
 * 9/20/2020
 *
 * This is my own work.
 *
 * This class is a static list of high scores to be accessed anywhere in the program
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperClassLibrary
{
    public static class HighScoreList
    {
        // Static high score list that can be accessed anywhere
        public static List<PlayerStats> highScoreList = new List<PlayerStats>();
    }
}
