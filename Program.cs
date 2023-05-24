using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected ==  Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuToDelet();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("---------------------------------------- \n" +
                "Ingrese la opción a realizar: \n" +
                "1. Nueva tarea\n" +
                "2. Remover tarea\n" +
                "3. Tareas pendiente\n" +
                "4. Salir");

            // Read line
            string menuOptionSelected = Console.ReadLine();
            return Convert.ToInt32(menuOptionSelected);
        }

        public static void ShowMenuToDelet()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowTaskList();

                string taskToKill = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskToKill) - 1;
                if (indexToRemove < 0 || indexToRemove > (TaskList.Count - 1))
                {
                    Console.WriteLine("La tarea no existe");
                } else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo completar la acción");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskToAdd = Console.ReadLine();
                TaskList.Add(taskToAdd);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
                Console.WriteLine("Se ha producido un error al crear la nueva tarea");
            }
        }

        public static void ShowTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                int indexTask = 1;
                TaskList.ForEach(p => Console.WriteLine((indexTask++) + ". " + p));
                Console.WriteLine("----------------------------------------");
            }
        }

        public enum Menu
        {
            Add = 1,

            Remove = 2,

            List = 3,

            Exit = 4,
        }
    }

}
