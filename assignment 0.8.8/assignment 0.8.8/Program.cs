using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace assignment_0._8._8
{
    class Program
    {
        private int count;
        private string filePath;
        private string attendancePath;
        private string[] idRead = new string[10];
        private string[] nameRead = new string[10];
        private string[] semRead = new string[10];
        private string[] cgpaRead = new string[10];
        private string[] deptRead = new string[10];
        private string[] uniRead = new string[10];
        public string idWrite;
        private string nameWrite;
        public string semWrite;
        public string cgpaWrite;
        public string deptWrite;
        public string uniWrite;
        private bool eCheck;
        private bool uniqueCheck;
        private string[] attendanceRead = new string[10];
        private Dictionary<string, string> attendanceDict = new Dictionary<string, string>();
        public Program()
        {
            count = 0;
            filePath = @"C:\Users\SMile\Desktop\0.8.8.txt";
            attendancePath = @"C:\Users\SMile\Desktop\attendance.txt";
            idWrite = "";
            nameWrite = "";
            semWrite = "";
            cgpaWrite = "";
            deptWrite = "";
            uniWrite = "";
            eCheck = false;
            uniqueCheck = false;
        }
        public void EmptyRemoval()
        {
            idRead = idRead.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            nameRead = nameRead.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            semRead = semRead.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            cgpaRead = cgpaRead.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            deptRead = deptRead.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            uniRead = uniRead.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        public void AttendanceReader()
        {
            using (StreamReader sr = new StreamReader(attendancePath))
            {
                for (int i = 0; i < count; i++)
			    {
			        
                    attendanceRead[i] = sr.ReadLine();
                    Console.WriteLine("Student ID: " + idRead[i] + "\tHours Present: " + attendanceRead[i]);
                    //attendanceDict.Add(idRead[i],attendanceRead[i]);
                    //Console.WriteLine("Student ID: " + idRead[i] + "\tHours Present: " + attendanceDict[idRead[i]]);
			    }
            }
        }
        public void AttendanceMarker()
        {
            string attTemp = "";
            Console.WriteLine("Enter Attendance for student: ");
            attTemp = Console.ReadLine();
            try
            {
                using (StreamWriter sw = File.AppendText(attendancePath))
                {
                    sw.WriteLine(attTemp);
                    Console.WriteLine("Attendance Added!\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing attendance! " + e.Message);
            }
        }

        public void ClassToppers()
        {
            Console.WriteLine("==================");
            Console.WriteLine("ID: " + idRead[Array.IndexOf(cgpaRead, cgpaRead.Max())]);
            Console.WriteLine("Name: " + nameRead[Array.IndexOf(cgpaRead, cgpaRead.Max())]);
            Console.WriteLine("Semester: " + semRead[Array.IndexOf(cgpaRead, cgpaRead.Max())]);
            Console.WriteLine("CGPA: " + cgpaRead[Array.IndexOf(cgpaRead, cgpaRead.Max())]);
            Console.WriteLine("Department: " + deptRead[Array.IndexOf(cgpaRead, cgpaRead.Max())]);
            Console.WriteLine("University: " + uniRead[Array.IndexOf(cgpaRead, cgpaRead.Max())]);
            Console.WriteLine("==================");
        }
        public void SemesterSearchDisp()
        {
            int matchCount = 0;
            string sem = "";
            Console.WriteLine("Enter Semester: ");
            sem = Console.ReadLine();
            try
            {
                for (int index = 0; index < count; index++)
                {
                    if (semRead[index] == sem)
                    {
                        Console.WriteLine("==================");
                        Console.WriteLine("ID: " + idRead[index]);
                        Console.WriteLine("Name: " + nameRead[index]);
                        Console.WriteLine("Semester: " + semRead[index]);
                        Console.WriteLine("CGPA: " + cgpaRead[index]);
                        Console.WriteLine("Department: " + deptRead[index]);
                        Console.WriteLine("University: " + uniRead[index]);
                        Console.WriteLine("==================");
                        matchCount++;
                    }
                }
                if (matchCount == 0)
                {
                    Console.WriteLine("Semester not found!");
                }
                else
                {
                    Console.WriteLine("Total matches: " + matchCount + "\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void NameSearchDisp()
        {
            Console.WriteLine("Enter Name: ");
            try
            {
                int index = Array.IndexOf(nameRead, Console.ReadLine());
                Console.WriteLine("==================");
                Console.WriteLine("ID: " + idRead[index]);
                Console.WriteLine("Name: " + nameRead[index]);
                Console.WriteLine("Semester: " + semRead[index]);
                Console.WriteLine("CGPA: " + cgpaRead[index]);
                Console.WriteLine("Department: " + deptRead[index]);
                Console.WriteLine("University: " + uniRead[index]);
                Console.WriteLine("==================");
            }
            catch (Exception)
            {
                Console.WriteLine("Name not found!");
            }
        }
        //public void IDDeleteDisp()
        //{
        //    Console.WriteLine("Enter ID: ");
        //    int index = Array.IndexOf(idRead, Console.ReadLine());

        //}
        public void IDSearchDisp()
        {
            Console.WriteLine("Enter ID: ");
            try
            {
                int index = Array.IndexOf(idRead, Console.ReadLine());
                Console.WriteLine("==================");
                Console.WriteLine("ID: " + idRead[index]);
                Console.WriteLine("Name: " + nameRead[index]);
                Console.WriteLine("Semester: " + semRead[index]);
                Console.WriteLine("CGPA: " + cgpaRead[index]);
                Console.WriteLine("Department: " + deptRead[index]);
                Console.WriteLine("University: " + uniRead[index]);
                Console.WriteLine("==================");
            }
            catch (Exception)
            {
                Console.WriteLine("ID not found!");
            }
        }
        public void UserInput()
        {
            Console.WriteLine("Enter ID:");
            idWrite = Console.ReadLine();
            Console.WriteLine("Enter Name:");
            nameWrite = Console.ReadLine();
            Console.WriteLine("Enter Semester:");
            semWrite = Console.ReadLine();
            Console.WriteLine("Enter CGPA:");
            cgpaWrite = Console.ReadLine();
            Console.WriteLine("Enter Department:");
            deptWrite = Console.ReadLine();
            Console.WriteLine("Enter University:");
            uniWrite = Console.ReadLine();
        }
        public void WriteFile()
        {
            UserInput();
            if (!idRead.Contains(idWrite))
                uniqueCheck = true;
            if (uniqueCheck == true)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(idWrite);
                        sw.WriteLine(nameWrite);
                        sw.WriteLine(semWrite);
                        sw.WriteLine(cgpaWrite);
                        sw.WriteLine(deptWrite);
                        sw.WriteLine(uniWrite);
                        Console.WriteLine("Written!\n");
                    }
                    AttendanceMarker();
                    ReadFile();
                    AttendanceReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Enter unique value");
            }
        }
        public void ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    int c = 0;
                    while (!sr.EndOfStream)
                    {
                        idRead[c] = sr.ReadLine();
                        nameRead[c] = sr.ReadLine();
                        semRead[c] = sr.ReadLine();
                        cgpaRead[c] = sr.ReadLine();
                        deptRead[c] = sr.ReadLine();
                        uniRead[c] = sr.ReadLine();
                        c++;
                    }
                    //Console.WriteLine("\nSuccessfully Read\n");
                    count = c;
                    //DashRemover();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void DisplayProfile()
        {
            for (int j = 0; j < count; j++)
            {
                Console.WriteLine("==================");
                Console.WriteLine("ID: " + idRead[j]);
                Console.WriteLine("Name: " + nameRead[j]);
                Console.WriteLine("Semester: " + semRead[j]);
                Console.WriteLine("CGPA: " + cgpaRead[j]);
                Console.WriteLine("Department: " + deptRead[j]);
                Console.WriteLine("University: " + uniRead[j]);
            }
            Console.WriteLine("==================");
            Console.WriteLine("\nScan Successful!\n");
            //Console.WriteLine(getId() + "\n" + getName() + "\n" + getSem() + "\n" + getCgpa() + "\n" + getDept() + "\n" + getUni());
        }
        public void DashRemover()
        {
            while (idRead.Contains("-") || nameRead.Contains("-") || semRead.Contains("-") || cgpaRead.Contains("-") || deptRead.Contains("-") || uniRead.Contains("-"))
            {
                //idRead = Regex.Replace(idRead, @"\-", " ");
                //nameRead = Regex.Replace(nameRead, @"\-", " ");
                //semRead = Regex.Replace(semRead, @"\-", " ");
                //cgpaRead = Regex.Replace(cgpaRead, @"\-", " ");
                //deptRead = Regex.Replace(deptRead, @"\-", " ");
                //uniRead = Regex.Replace(uniRead, @"\-", " ");
            }
        }
        public void Gui()
        {
            Console.WriteLine("1-> Write");
            Console.WriteLine("2-> Display List");
            Console.WriteLine("3-> Search by ID");
            Console.WriteLine("4-> Search by Name");
            Console.WriteLine("5-> Search by Semester");
            Console.WriteLine("6-> Highest CGPA");
            Console.WriteLine("7-> Open Attendance");
            Console.WriteLine("8-> Exit");
        }
        public void OptionSelector(int opt)
        {
            try
            {
                if (opt == 1)
                {
                    WriteFile();
                }
                else if (opt == 2)
                {
                    DisplayProfile();
                }
                else if (opt == 3)
                {
                    IDSearchDisp();
                }
                else if (opt == 4)
                {
                    NameSearchDisp();
                }
                else if (opt == 5)
                {
                    SemesterSearchDisp();
                }
                else if (opt == 6)
                {
                    ClassToppers();
                }
                else if (opt == 7)
                {
                    AttendanceReader();
                }
                else if (opt == 8)
                {
                    eCheck = true;
                }
                else
                {
                    Console.WriteLine("Chose options listed only!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool getExitVal()
        {
            return eCheck;
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Program ob = new Program();

            ob.ReadFile();
            //ob.EmptyRemoval();
            ob.Gui();
            int option = Convert.ToInt32(Console.ReadLine());
            ob.OptionSelector(option);
            while (ob.getExitVal() == false)
            {
                ob.Gui();
                option = Convert.ToInt32(Console.ReadLine());
                ob.OptionSelector(option);
            }
        }
    }
}
