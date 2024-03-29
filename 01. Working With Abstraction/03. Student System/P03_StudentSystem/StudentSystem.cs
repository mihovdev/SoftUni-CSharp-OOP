﻿using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            Repo = new Dictionary<string, Student>();
            repo = this.Repo;
        }

        public Dictionary<string, Student> Repo { get; set; }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();
            var command = args[0];
            string name = string.Empty;

            switch (command.ToLower())
            {
                case "create":
                    name = args[1];
                    var age = int.Parse(args[2]);
                    var grade = double.Parse(args[3]);
                    if (!repo.ContainsKey(name))
                    {
                        var student = new Student(name, age, grade);
                        Repo[name] = student;
                    }
                    break;
                case "show":
                    name = args[1];
                    if (Repo.ContainsKey(name))
                    {
                        var student = Repo[name];
                        string view = $"{student.Name} is {student.Age} years old.";

                        if (student.Grade >= 5.00)
                        {
                            view += " Excellent student.";
                        }
                        else if (student.Grade < 5.00 && student.Grade >= 3.50)
                        {
                            view += " Average student.";
                        }
                        else
                        {
                            view += " Very nice person.";
                        }

                        Console.WriteLine(view);
                    }
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
