using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email{ get; set; }
        public string Phone { get; set; }
        public User() { }
        public User(string name,string surname,string email,string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }
        public void ShowUser()
        {
            Console.WriteLine($"Fullname: {Name} {Surname}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {Phone}");
        }
    }
    class Doctor
    {
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public int PracticeYear { get; set; } = 0;

        public ArrayList Times = new ArrayList();

        public int[] Indexs { get; set; }
        public int IndexCount { get; set; } = 0;
        public Doctor(){}
        public Doctor(string name,string surname,int practiceYear)
        {
            Name = name;
            Surname = surname;
            PracticeYear = practiceYear;           
        }
        public void AddTimes(string[] times)
        {            
            foreach (var time in times)
            {
                Times.Add(time);
            }
        }
        public void AddReservedIndexs(int index)
        {
            int[] temp = new int[IndexCount + 1];
            if (IndexCount != 0)
            {
                Indexs.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = index;
            Indexs = temp;
            ++IndexCount;
        }
        public void RemoveTime(int index)
        {
            Times.RemoveAt(index);
        }
        public void ShowDoctors()
        {
            Console.WriteLine($"Doctor: {Name} {Surname}");           
            Console.WriteLine($"Practice : {PracticeYear} year");
            Console.WriteLine("Free Time: ");                    
            Console.WriteLine("\n");
        }
       public void ShowTimes()
       {
            for (int i = 0; i < Times.Count; i++)
            {
                Console.Write($"[{i + 1}]  ");
                Console.WriteLine($"{Times[i]}");
            }
       }
       
    }
    class Section
    {
        public string Name { get; set; } = String.Empty;
        public List<Doctor> Doctors = new List<Doctor>();
        public Section()
        {}
        public Section(string name)
        {
            Name = name;
        }
        public void AddDoctor(Doctor doctor)
        {
            
            Doctors.Add(doctor);

        }
        public void ShowSection()
        {
            Console.WriteLine($@"                               Section: {Name}");            
        }
    }
    class Hospital
    {
        public string Name { get; set; }
        public List<Section> Sections = new List<Section>();
        public List<User> Users { get; set; } = new List<User>();
        
        public Hospital()
        {}
        public Hospital(string name)
        {
            Name = name;
        }
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public void AddSections(Section section)
        {
            Sections.Add(section);
        }
        public void ShowHospital()
        {
            Console.WriteLine($@"              <<<<<<<<<<<<< {Name} >>>>>>>>>>>>");
            for (int i = 0; i < Sections.Count; i++)
            {
                Console.Write($"[{i+1}] ");
                Sections[i].ShowSection();
            }            
        }
    }

   
    class Run
    {
       
        public void CreatObjects(User user)
        {
            Hospital hospital = new Hospital
            {
                Name = "Avrasiya Hospital"
            };
            FileHelper FH = new FileHelper();
            if (File.Exists("HOSPITAL.json"))            {
                
                FH.JsonDeserializeWorker(hospital);
                Console.Clear();
                Display2(hospital);
            }
            else
            {
                Doctor doctor1 = new Doctor
                {
                    Name = "Terlan",
                    Surname = "Eyyubov",
                    PracticeYear = 10
                };
                Doctor doctor2 = new Doctor
                {
                    Name = "Naile",
                    Surname = "Elekberova",
                    PracticeYear = 7
                };
                Doctor doctor3 = new Doctor
                {
                    Name = "Murad",
                    Surname = "Dadasov",
                    PracticeYear = 1
                };
                Doctor doctor4 = new Doctor
                {
                    Name = "Aylin",
                    Surname = "Elekberova",
                    PracticeYear = 15
                };
                Doctor doctor5 = new Doctor
                {
                    Name = "Safura",
                    Surname = "Eliyeva",
                    PracticeYear = 8
                };
                Doctor doctor6 = new Doctor
                {
                    Name = "Turxan",
                    Surname = "Hesenov",
                    PracticeYear = 3
                };
                Doctor doctor7 = new Doctor
                {
                    Name = "Ayxan",
                    Surname = "Dadasov",
                    PracticeYear = 7
                };

                string time1 = "09:00-11:00";
                string time2 = "12:00-14:00";
                string time3 = "15:00-17:00";

                string[] times = new string[3] { time1, time2, time3 };
                doctor1.AddTimes(times);
                doctor2.AddTimes(times);
                doctor3.AddTimes(times);
                doctor4.AddTimes(times);
                doctor5.AddTimes(times);
                doctor6.AddTimes(times);
                doctor7.AddTimes(times);

                Section sec1 = new Section
                {
                    Name = "Pediatriya"
                };
                sec1.AddDoctor(doctor1);
                sec1.AddDoctor(doctor2);
                sec1.AddDoctor(doctor3);
                sec1.AddDoctor(doctor4);

                Section sec2 = new Section
                {
                    Name = "Travmatologiya"
                };
                sec2.AddDoctor(doctor5);
                sec2.AddDoctor(doctor6);

                Section sec3 = new Section
                {
                    Name = "Stamatologiya"
                };
                sec3.AddDoctor(doctor7);

               
                hospital.AddSections(sec1);
                hospital.AddSections(sec2);
                hospital.AddSections(sec3);
                hospital.AddUser(user);
                Console.Clear();
                Display2(hospital);
            }

            FH.JsonSerializationWorker(hospital.Sections);
        }
        public void Display1()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            User user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Phone = phone
            };
                       
            CreatObjects(user);
        }
        public void Display2(Hospital hospital)
        {
            hospital.ShowHospital();
            Console.Write("Choose section: ");
            string ch = Console.ReadLine();
            int index = int.Parse(ch);
            Console.Clear();

            if (index > 0 || index <= hospital.Sections.Count) 
            {
                hospital.Sections[index - 1].ShowSection();
                var doctors = hospital.Sections[index - 1].Doctors;
                for (int i = 0; i < doctors.Count; i++)
                {
                    Console.Write($"[{i + 1}] ");
                    doctors[i].ShowDoctors();
                }

                Console.WriteLine("[0] Back ");
                Console.Write("Enter : ");
                string c = Console.ReadLine();
                if (c == "0")
                {
                    Console.Clear();
                    Display2(hospital);
                }
                else
                {
                    int ind = int.Parse(c);
                    var doctor = doctors[ind - 1];
                    Console.Clear();
                    Display3(doctor,hospital);
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong enter...");
                Console.ForegroundColor = ConsoleColor.White;
                Display2(hospital);
            }
            
        }
       public void Display3(Doctor doctor,Hospital h)
        {
           
            Console.WriteLine($"{doctor.Name} {doctor.Surname}\n");
            doctor.ShowTimes();
            Console.WriteLine("[0] Back ");         
            Console.Write("Enter : ");
            string c = Console.ReadLine();
            if (c == "0")
            {
                Console.Clear();
                Display2(h);
            }
            else
            {
                int index = int.Parse(c);
                if (index > 0 || index <= doctor.Times.Count)
                {
                    var reserved = doctor.Indexs;
                    bool control = true;
                    for (int i = 0; i < doctor.IndexCount; i++)
                    {                        
                        if (reserved[i] == index - 1)
                        {
                            control = false;
                        }
                    }
                    if (control == true)
                    {
                      var time = doctor.Times[index - 1];
                        var t = time;
                      time = time + " Reserved";
                      doctor.Times[index - 1] = time;
                      doctor.AddReservedIndexs(index - 1);
                      Console.Clear();

                        var user = h.Users[0];
                        Console.WriteLine($@"           Thank you {user.Name} {user.Surname}.
                                    You have registered for a {doctor.Name} {doctor.Surname} doctor's appointment .
                                    Time: {t}

                                    ");

                        Console.WriteLine("[0] Back ");
                        Console.Write("Enter : ");
                        string choi = Console.ReadLine();
                        if (choi == "0")
                        {
                            Console.Clear();
                            Display2(h);
                        }
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Time reserved. Choose another ...\n\n");
                        Display3(doctor,h);
                    }

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong enter...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Display3(doctor,h);
                }
            }
           

       }
        
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Run run = new Run();
            run.Display1();
        }
    }
}
