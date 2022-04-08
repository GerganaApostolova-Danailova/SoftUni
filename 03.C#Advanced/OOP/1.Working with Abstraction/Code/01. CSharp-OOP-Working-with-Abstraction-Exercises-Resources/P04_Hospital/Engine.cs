using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();
                var departament = inputArgs[0];
                var firstName = inputArgs[1];
                var secondName = inputArgs[2];
                var patient = inputArgs[3];

                var fullName = firstName + secondName;

                AddDoctors(fullName);

                AddDepartment(departament);

                bool isFree = departments[departament]
                    .SelectMany(x => x)
                    .Count() < 60;

                if (isFree)
                {

                    doctors[fullName].Add(patient);

                    AddPatientToRoom(departament, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    var allPatientInDepartment = departments[args[0]]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)
                        .ToArray();

                    Console.WriteLine(string.Join(Environment.NewLine, allPatientInDepartment));
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);
                    if (isRoom)
                    {
                        var allPatientInRoom = departments[args[0]][room - 1]
                            .OrderBy(x => x)
                            .ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, allPatientInRoom));
                    }
                    else
                    {
                        var allPatientOfDoctor = doctors[args[0] + args[1]]
                            .OrderBy(x => x)
                            .ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, allPatientOfDoctor));
                    }
                }
                command = Console.ReadLine();
            }
        }

        private void AddPatientToRoom(string departament, string patient)
        {
            int room = 0;

            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            departments[departament][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctors(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
