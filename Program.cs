using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> grid = new List<string>{"1","2","3","4","5","6","7","8","9"};
            bool playing = true;
            int turn = 1;
            while (playing) {
                printGrid(grid);

                promptUser(grid, turn);
                bool checkWin = checkIfWin(grid, turn);
                bool isTie = checkIfTie(grid);
                if(checkWin || isTie) {
                    playing = false;
                }

                turn++;
                
            }

            
        }

        static bool checkIfTie(List<string> grid) {
            bool turnsLeft = false;

            for (int i = 0; i < 9; i++) {
                char currBox = char.Parse(grid[i]);
                if(char.IsDigit(currBox)) {
                    turnsLeft = true;
                    break;
                }
            }

            if(turnsLeft){
                return false;
            } else {
                Console.WriteLine("It's a tie!");
                return true;
            }
            
            
        }

        static void printGrid(List<string> grid) {
            Console.WriteLine($"{grid[0]}|{grid[1]}|{grid[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{grid[3]}|{grid[4]}|{grid[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{grid[6]}|{grid[7]}|{grid[8]}");

        }

        static List<string> promptUser(List<string> grid, int turn) {
            //If number is odd
            string player = "x";
            if(turn % 2 != 0) {
                player = "x";
            }
            else {
                player = "o";
            }

            Console.WriteLine($"{player}'s turn to choose a square (1-9): ");
            string prompt = Console.ReadLine();
            int play = Int32.Parse(prompt);
            int playSpot = play - 1;

            //Update grid List
            grid[playSpot] = player;
            
            return grid;
        }

        static bool checkIfWin(List<string> grid, int turn) {

            string player = "x";
            if(turn % 2 != 0) {
                player = "x";
            }
            else {
                player = "o";
            }

            if ((grid[0] == player && grid[1] == player && grid[2] == player)
                || (grid[3] == player && grid[4] == player && grid[5] == player)
                || (grid[6] == player && grid[7] == player && grid[8] == player)
                || (grid[0] == player && grid[3] == player && grid[6] == player)
                || (grid[1] == player && grid[4] == player && grid[7] == player)
                || (grid[2] == player && grid[5] == player && grid[8] == player)
                || (grid[0] == player && grid[4] == player && grid[8] == player)
                || (grid[2] == player && grid[4] == player && grid[6] == player)
                )
            {   
                Console.WriteLine(player + " wins the game!");
                return true;
                
            } else {
                return false;
            }

            
        }
        
    }
}