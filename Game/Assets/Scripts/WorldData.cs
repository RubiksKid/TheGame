﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

public class WorldData : MonoBehaviour
{

    private static List<LocationData.Location> locationList;
    public static int currentLoc = 0;

    public static void initializeLocations()
    {

        #region replace with XML
        if (locationList == null)
        {
            locationList = new List<LocationData.Location>();
            locationList.Add(new LocationData.Location("LocA", "Location A", 0, new int[2]
            {
                1,
                2
            }, new string[2]
            {
                "southwest",
                "southeast"
            }));
            locationList.Add(new LocationData.Location("LocB", "Location B", 1, new int[4]
            {
                0,
                2,
                3,
                4
            }, new string[4]
            {
                "northeast",
                "east",
                "south",
                "southeast"
            }));
            locationList.Add(new LocationData.Location("LocC", "Location C", 2, new int[4]
            {
                0,
                1,
                3,
                4
            }, new string[4]
            {
                "northwest",
                "west",
                "southwest",
                "south"
            }));
            locationList.Add(new LocationData.Location("LocD", "Location D", 3, new int[3]
            {
                1,
                2,
                4
            }, new string[3]
            {
                "north",
                "northeast",
                "east"
            }));
            locationList.Add(new LocationData.Location("LocE", "Location E", 4, new int[3]
            {
                1,
                2,
                3
            }, new string[3]
            {
                "northwest",
                "north",
                "west"
            }));
        }
        #endregion
    }

    public static string Go(string[] command)
    {
        if (command.Length <= 1)
        {
            return "Go Where?";
        }
        else
        {
            foreach (LocationData.Location a in locationList)
            {
                if (a.getNodeNumber() == currentLoc)
                {
                    for (int i = 0; i < a.getAdjacentNodes().Length; i++)
                    {
                        if (a.getAdjacentDirections() [i].Equals(command[1]))
                        {
                            currentLoc = a.getAdjacentNodes() [i];
                            return "Going: " + a.getAdjacentDirections() [i];
                        }
                    }
                }

            }
            return "Location does not exist";
        }
    }

    public static string Look(string[] command)
    {
        if (command.Length == 1)
        {
            return "look where?";
        }
        else if (command.Length <= 3)
        {
            if (command [1].Equals("around") && command.Length == 2)
            {
                foreach (LocationData.Location a in locationList)
                {
                    if (a.getNodeNumber() == currentLoc)
                    {
                        string directions = "From here you can go: ";
                        for (int i = 0; i < a.getAdjacentDirections().Length; i++)
                        {
                            directions = directions + a.getAdjacentDirections()[i] + " ";
                        }
                        return a.getDescription() + "\n"+directions + "\n" + Inventory.itemsAtLocation(currentLoc);
                        //test
                    }
                }
            }
            else if (command [1].Equals("at"))
            {
                if (command.Length == 2)
                {
                    return "Look at what?";
                }

                foreach (ItemData.Item a in Inventory.items)
                {
                    if (a.getName().Equals(command [2]) && (a.getLocation() == currentLoc || a.getLocation() == -1))
                    {
                        if (a.getWeight() < 999)
                        {
                            return a.getDescription() + "\nWeight: " + a.getWeight();
                        }
                        else
                        {
                            //this prevents "world objects / switches" from displaying their weight
                            return a.getDescription();
                        }


                    }
                }

                return "Object does not exist at current location";
            }
        }
        else if (command.Length > 3)
        {
            return "Too many args";
        }
       
        return "Invalid modifier";
     
    }
}
