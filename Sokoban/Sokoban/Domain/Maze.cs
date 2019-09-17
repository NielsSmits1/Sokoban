﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public class Maze
    {
       // private int _amountOfChars = 0;
        private Spot[] _maze { get; set; }
        private Truck _truck { get; set; }
        private Spot _first { get; set; }
        public List<Crate> Crates { get; }
        private int _destinationAmount;
        public Maze(string[] maze)
        {
            
            Crates = new List<Crate>();
            linkSpots(maze);
        }

        public Spot[] allSpots
        {
            get
            {
                return _maze;
            }
        }

        public Truck Truck
        {
            get
            {
                return _truck;
            }
        }

        public Spot First
        {
            get
            {
                return _first;
            }
        }

        public void linkSpots(string[] maze)
        {
            Spot[,] spots = new Spot[maze.Length, getLongestLine(maze)];
            int x = 0;
            int y = 0;

            foreach(String line in maze)
            {
                y = 0;
                foreach(char symbol in line.ToCharArray())
                {
                    Spot spot = null;
                    switch (symbol)
                    {
                        case 'x':
                            spot = new Destination();
                            _destinationAmount++;
                            break;

                        case '.':
                            spot = new Floor();
                            break;
                        case 'o':
                            spot = new Floor();
                            Crate crate = new Crate(spot);
                            spot.Occupied = crate;
                            Crates.Add(crate);
                            break;
                        case '@':
                            spot = new Floor();
                            Truck truck = new Truck(spot);
                            spot.Occupied = truck;
                            _truck = truck;
                            break;
                        case '#':
                            spot = new Wall();
                            break;
                        case '0':
                            spot = new Destination();
                            crate = new Crate(spot);
                            spot.Occupied = crate;
                            Crates.Add(crate);
                            break;
                        case ' ':
                            spot = new Empty();
                            break;

                    }

                    spots[x, y] = spot;
                    y++;
                }
                x++;
            }

            for (int i = 0; i < spots.GetLength(0); i++)
            {
                for (int j = 0; j < spots.GetLength(1); j++)
                {
                    Spot spot = spots[i, j];

                    if(spot == null)
                    {
                        continue;
                    }

                    spot.UpSpot = getSpot(spots, i - 1, j);
                    spot.RightSpot = getSpot(spots, i, j + 1);
                    spot.DownSpot = getSpot(spots, i + 1, j);
                    spot.LeftSpot = getSpot(spots, i, j - 1);

                    if (i == 0 && j == 0)
                    {
                       _first = spot;
                    }
                }
            }
        }

        private Spot getSpot(Spot[,] spots, int x, int y)
        {
            Spot spot;

            if (x >= spots.GetLength(0) || x < 0 || y >= spots.GetLength(1) || y < 0)
            {
                return null;
            }

            spot = spots[x, y];

            return spot;
        }

        private int getLongestLine(string[] array)
        {
            int longestLine = 0;

            foreach (String line in array)
            {
                if (line.Length > longestLine)
                {
                    longestLine = line.Length;
                }
            }

            return longestLine;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "down":
                    CheckForCrate(Truck.MoveableSpot.DownSpot, direction);
                    Truck.MoveableSpot.DownSpot.Occupied = Truck;
                    Truck.MoveableSpot.Occupied = null;
                    Truck.MoveableSpot = Truck.MoveableSpot.DownSpot;
                    break;
                case "up":
                    CheckForCrate(Truck.MoveableSpot.UpSpot, direction);
                    Truck.MoveableSpot.UpSpot.Occupied = Truck;
                    Truck.MoveableSpot.Occupied = null;
                    Truck.MoveableSpot = Truck.MoveableSpot.UpSpot;
                    break;
                case "right":
                    CheckForCrate(Truck.MoveableSpot.RightSpot, direction);
                    Truck.MoveableSpot.RightSpot.Occupied = Truck;
                    Truck.MoveableSpot.Occupied = null;
                    Truck.MoveableSpot = Truck.MoveableSpot.RightSpot;
                    break;
                case "left":
                    CheckForCrate(Truck.MoveableSpot.LeftSpot, direction);
                    Truck.MoveableSpot.LeftSpot.Occupied = Truck;
                    Truck.MoveableSpot.Occupied = null;
                    Truck.MoveableSpot = Truck.MoveableSpot.LeftSpot;
                    break;
            }
        }

        public void CheckForCrate(Spot NextToSpot, string direction)
        {
            if(NextToSpot.Occupied != null)
            {
                switch (direction)
                {
                    case "down":
                        if (NextToSpot.DownSpot.Occupied != null)
                        {
                            throw new Exception_TwoCratesInARow();
                        }
                        else
                        {
                            NextToSpot.DownSpot.Occupied = NextToSpot.Occupied;
                            GetCrate((Crate)NextToSpot.Occupied).MoveableSpot = NextToSpot.DownSpot;
                            NextToSpot.Occupied = null;
                        }
                        break;
                    case "up":
                        if (NextToSpot.UpSpot.Occupied != null)
                        {
                            throw new Exception_TwoCratesInARow();
                        }
                        else
                        {
                            NextToSpot.UpSpot.Occupied = NextToSpot.Occupied;
                            GetCrate((Crate)NextToSpot.Occupied).MoveableSpot = NextToSpot.UpSpot;
                            NextToSpot.Occupied = null;
                        }
                        break;
                    case "right":
                        if (NextToSpot.RightSpot.Occupied != null)
                        {
                            throw new Exception_TwoCratesInARow();
                        }
                        else
                        {
                            NextToSpot.RightSpot.Occupied = NextToSpot.Occupied;
                            GetCrate((Crate)NextToSpot.Occupied).MoveableSpot = NextToSpot.RightSpot;
                            NextToSpot.Occupied = null;
                        }
                        break;
                    case "left":
                        if (NextToSpot.LeftSpot.Occupied != null)
                        {
                            throw new Exception_TwoCratesInARow();
                        }
                        else
                        {
                            NextToSpot.LeftSpot.Occupied = NextToSpot.Occupied;
                            GetCrate((Crate)NextToSpot.Occupied).MoveableSpot = NextToSpot.LeftSpot;
                            NextToSpot.Occupied = null;
                        }
                        break;
                }
            }
            
        }

        public Crate GetCrate(Crate Crate)
        {
            for (int i = 0; i < Crates.Count; i++)
            {
                if(Crates[i] == Crate)
                {
                    return Crates[i];
                }
            }
            return null;
            
        }
    }
}