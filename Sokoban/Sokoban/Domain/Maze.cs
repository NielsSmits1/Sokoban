using System;
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
        private List<Crate> Crates { get; }
        private List<Destination> Destinations { get; }
        private int _destinationAmount;
        public Maze(string[] maze)
        {
            
            Crates = new List<Crate>();
            Destinations = new List<Destination>();
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
                            Destinations.Add((Destination)spot);
                            break;

                        case '.':
                            spot = new Floor();
                            break;
                        case 'o':
                            spot = new Floor();
                            Crate crate = new Crate(spot);
                            spot.ContainsItem = crate;
                            Crates.Add(crate);
                            break;
                        case '@':
                            spot = new Floor();
                            Truck truck = new Truck(spot);
                            spot.ContainsItem = truck;
                            _truck = truck;
                            break;
                        case '#':
                            spot = new Wall();
                            break;
                        case '0':
                            spot = new Destination();
                            Destinations.Add((Destination)spot);
                            crate = new Crate(spot);
                            spot.ContainsItem = crate;
                            Crates.Add(crate);
                            break;
                        case ' ':
                            spot = new Floor();
                            spot.IsEmpty = true;
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
            Spot current = Truck.MoveableSpot;
            switch (direction)
            {
                case "down":
                    Truck.MoveableSpot.DownSpot.SetItem(Truck, "down");
                    break;
                case "up":
                    Truck.MoveableSpot.UpSpot.SetItem(Truck, "up");
                    break;
                case "right":
                    Truck.MoveableSpot.RightSpot.SetItem(Truck, "right");
                    break;
                case "left":
                    Truck.MoveableSpot.LeftSpot.SetItem(Truck, "left");
                    break;
            }
            current.ContainsItem = null;
        }

        public int AmountOfDestinationsContainingCrates()
        {
            int count = 0;
            foreach (Destination destination in Destinations)
            {
                if(destination.CrateOnDestination == true)
                {
                    count++;
                }
            }
            return count;
        }

        public int AmountOfCrates()
        {
            return Crates.Count;
        }

        //public void CheckForCrate(Spot NextToSpot, string direction)
        //{
        //    if(NextToSpot.ContainsItem != null)
        //    {
        //        switch (direction)
        //        {
        //            case "down":
        //                if (NextToSpot.DownSpot.ContainsItem != null)
        //                {
        //                    throw new Exception_TwoCratesInARow();
        //                }
        //                else
        //                {
        //                    NextToSpot.DownSpot.ContainsItem = NextToSpot.ContainsItem;
        //                    GetCrate((Crate)NextToSpot.ContainsItem).MoveableSpot = NextToSpot.DownSpot;
        //                    NextToSpot.ContainsItem = null;
        //                }
        //                break;
        //            case "up":
        //                if (NextToSpot.UpSpot.ContainsItem != null)
        //                {
        //                    throw new Exception_TwoCratesInARow();
        //                }
        //                else
        //                {
        //                    NextToSpot.UpSpot.ContainsItem = NextToSpot.ContainsItem;
        //                    GetCrate((Crate)NextToSpot.ContainsItem).MoveableSpot = NextToSpot.UpSpot;
        //                    NextToSpot.ContainsItem = null;
        //                }
        //                break;
        //            case "right":
        //                if (NextToSpot.RightSpot.ContainsItem != null)
        //                {
        //                    throw new Exception_TwoCratesInARow();
        //                }
        //                else
        //                {
        //                    NextToSpot.RightSpot.ContainsItem = NextToSpot.ContainsItem;
        //                    GetCrate((Crate)NextToSpot.ContainsItem).MoveableSpot = NextToSpot.RightSpot;
        //                    NextToSpot.ContainsItem = null;
        //                }
        //                break;
        //            case "left":
        //                if (NextToSpot.LeftSpot.ContainsItem != null)
        //                {
        //                    throw new Exception_TwoCratesInARow();
        //                }
        //                else
        //                {
        //                    NextToSpot.LeftSpot.ContainsItem = NextToSpot.ContainsItem;
        //                    GetCrate((Crate)NextToSpot.ContainsItem).MoveableSpot = NextToSpot.LeftSpot;
        //                    NextToSpot.ContainsItem = null;
        //                }
        //                break;
        //        }
        //    }
            
        //}

        //public Crate GetCrate(Crate Crate)
        //{
        //    for (int i = 0; i < Crates.Count; i++)
        //    {
        //        if(Crates[i] == Crate)
        //        {
        //            return Crates[i];
        //        }
        //    }
        //    return null;
            
        //}
    }
}