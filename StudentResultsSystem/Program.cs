using System;

namespace MiniStudentResultsProcessingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // i declared these arrays to store the student info
            // i used 3 because the question said at least 3 students
            string[] studentName = new string[3];
            string[] studentID = new string[3];
            string[] studentProgramme = new string[3];
            string[] studentLevel = new string[3];

            // this is a 2D array to store scores, 3 students and 5 courses each
            double[,] courseScores = new double[3, 5];

            // i put the course names in an array so i dont have to type them everytime
            string[] courseNames = new string[5];
            courseNames[0] = "Programming with C#";
            courseNames[1] = "Database Systems";
            courseNames[2] = "Computer Networks";
            courseNames[3] = "Web Development";
            courseNames[4] = "Mathematics for Computing";

            // this variable helps me know if the user has entered data already
            bool hasData = false;

            int option = 0;

            // keep showing the menu until the user chooses to exit
            while (option != 3)
            {
                // display the main menu
                Console.WriteLine("");
                Console.WriteLine("===== MINI STUDENT RESULTS PROCESSING SYSTEM =====");
                Console.WriteLine("1. Enter Student Results");
                Console.WriteLine("2. View Student Report");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string userInput = Console.ReadLine();

                // i used TryParse because i learned that int.Parse crashes if the user types letters
                bool isValid = int.TryParse(userInput, out option);

                if (isValid == false || option < 1 || option > 3)
                {
                    Console.WriteLine("Please enter a valid option (1, 2 or 3)");
                    option = 0; // reset so the loop continues
                    continue;
                }

                // option 1 - enter student details
                if (option == 1)
                {
                    // loop through 3 students
                    for (int i = 0; i < 3; i++)
                    {
                        int studentNumber = i + 1; // just to make it say Student 1, Student 2 etc
                        Console.WriteLine("");
                        Console.WriteLine("Enter details for Student " + studentNumber);

                        Console.Write("Enter full name: ");
                        studentName[i] = Console.ReadLine();

                        Console.Write("Enter student ID: ");
                        studentID[i] = Console.ReadLine();

                        Console.Write("Enter programme: ");
                        studentProgramme[i] = Console.ReadLine();

                        Console.Write("Enter level: ");
                        studentLevel[i] = Console.ReadLine();

                        // now collect the 5 course scores for this student
                        for (int j = 0; j < 5; j++)
                        {
                            double enteredScore = 0;
                            bool scoreOk = false;

                            // keep asking until a valid score is entered
                            while (scoreOk == false)
                            {
                                Console.Write("Enter score for " + courseNames[j] + ": ");
                                string scoreInput = Console.ReadLine();

                                // check if its actually a number first
                                bool isNumber = double.TryParse(scoreInput, out enteredScore);

                                if (isNumber == false)
                                {
                                    Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                                }
                                else if (enteredScore < 0 || enteredScore > 100)
                                {
                                    // score is a number but out of range
                                    Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                                }
                                else
                                {
                                    // score is fine, save it and exit the while loop
                                    courseScores[i, j] = enteredScore;
                                    scoreOk = true;
                                }
                            }
                        }
                    }

                    // set hasData to true so option 2 knows there is something to show
                    hasData = true;
                    Console.WriteLine("");
                    Console.WriteLine("Student results saved successfully!");
                }

                // option 2 - view the report
                else if (option == 2)
                {
                    // check if user has entered data yet
                    if (hasData == false)
                    {
                        Console.WriteLine("No data found. Please enter student results first (Option 1).");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("===== MINI STUDENT RESULTS REPORT =====");

                        // loop through all 3 students and print their report
                        for (int i = 0; i < 3; i++)
                        {
                            // calculate total score by adding all 5 course scores
                            double totalScore = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                totalScore = totalScore + courseScores[i, j];
                            }

                            // average is total divided by number of courses
                            double averageScore = totalScore / 5;

                            // use if-else to find the grade based on the grading table
                            string grade = "";
                            if (averageScore >= 80)
                            {
                                grade = "A";
                            }
                            else if (averageScore >= 70)
                            {
                                grade = "B";
                            }
                            else if (averageScore >= 60)
                            {
                                grade = "C";
                            }
                            else if (averageScore >= 50)
                            {
                                grade = "D";
                            }
                            else
                            {
                                // below 50 is F
                                grade = "F";
                            }

                            // determine academic status
                            string academicStatus = "";
                            if (averageScore >= 50)
                            {
                                academicStatus = "Passed";
                            }
                            else
                            {
                                academicStatus = "Failed";
                            }

                            // print the student report
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Student Name : " + studentName[i]);
                            Console.WriteLine("Student ID   : " + studentID[i]);
                            Console.WriteLine("Programme    : " + studentProgramme[i]);
                            Console.WriteLine("Level        : " + studentLevel[i]);
                            Console.WriteLine("");

                            // print each course and its score
                            for (int j = 0; j < 5; j++)
                            {
                                Console.WriteLine("  " + courseNames[j] + ": " + courseScores[i, j]);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Total Score   : " + totalScore);

                            // round to 1 decimal place using Math.Round
                            double roundedAverage = Math.Round(averageScore, 1);
                            Console.WriteLine("Average Score : " + roundedAverage);
                            Console.WriteLine("Grade         : " + grade);
                            Console.WriteLine("Status        : " + academicStatus);
                            Console.WriteLine("------------------------------------------");
                        }
                    }
                }

                // option 3 - exit the program
                else if (option == 3)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Thank you for using the Mini Student Results Processing System.");
                }

            } // end of while loop

        } // end of Main method

    } // end of class
}