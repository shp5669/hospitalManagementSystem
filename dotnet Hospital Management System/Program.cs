using dotnet_Hospital_Management_System;
using System.Collections;

public class Program
{
    public static void heading()
    {
        Console.WriteLine("\n");
        Console.WriteLine("|-----------------------------------------|");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|    DOTNET Hospital Management System    |");
        Console.WriteLine("|                                         |");
        Console.WriteLine("|-----------------------------------------|");
    }

    static string ReadPassword()
    {
        string password = "";
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter) break;

            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else
            {
                Console.Write('*');
                password += key.KeyChar;
            }
        }
        return password;
    }


    public static void Main(string[] args)
    {
        string firstName, lastName, email, phone, streetNumber, street, city, state, password;
        List<Doctor> doctorlist = new List<Doctor>();
        List<Patient> patientlist = new List<Patient>();
        List<Appointment> appointmentlist = new List<Appointment>();
        Patient p;
        int adminID = 100;
        string pass = "password";
        
        try
        {
            string patientsFilePath = Path.Combine(Environment.CurrentDirectory, "patients.txt");
            string[] patientLines = File.ReadAllLines(patientsFilePath);

            foreach (string line in patientLines)
            {
                string[] data = line.Split(',');

                if (data.Length == 10)
                {
                    int id;
                    if (int.TryParse(data[0], out id))
                    {
                        Patient patient = new Patient(id, data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);

                        patientlist.Add(patient);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid ID: {data[0]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading data from file: {ex.Message}");
        }
        try
        {
            string doctorsFilePath = Path.Combine(Environment.CurrentDirectory, "doctors.txt");
            string[] doctorLines = File.ReadAllLines(doctorsFilePath);

            foreach (string line in doctorLines)
            {
                string[] data = line.Split(',');

                if (data.Length == 10)
                {
                    int id;
                    if (int.TryParse(data[0], out id))
                    {
                        Doctor doctor = new Doctor(id, data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);

                        doctorlist.Add(doctor);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid ID: {data[0]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading data from file: {ex.Message}");
        }

        {
            Console.WriteLine("1. Patient");
            Console.WriteLine("2. Doctor");
            Console.WriteLine("3. Administrator");
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.Clear();
                heading();
                
                Console.WriteLine("         Login        ");
                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Password: ");
                password = ReadPassword();

                for (int i = 0; i < patientlist.Count; i++)
                {
                    if (patientlist[i].ID.Equals(id) && patientlist[i].Password.Equals(password))
                    {
                        Console.WriteLine("Valid Credentials");
                        
                    }
                    p = patientlist[i];
                }

                while (true)

                {
                    heading();
                    Console.WriteLine("         Patient Menu        ");
                    Console.WriteLine("Welcome to DOTNET Hospital Management ");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1. List patient details");
                    Console.WriteLine("2. List my doctor details");
                    Console.WriteLine("3. List all appointments");
                    Console.WriteLine("4. Book appointment");
                    Console.WriteLine("5. Exit to login");
                    Console.WriteLine("6. Exit System");
                    Console.WriteLine("Enter your choice: ");
                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            heading();
                            Console.WriteLine("         My Details        ");
                            for (int i = 0; i < patientlist.Count; i++)
                            {
                                if (patientlist[i].ID.Equals(id))
                                {
                                    Console.WriteLine("Patient ID: " + patientlist[i].ID);
                                    Console.WriteLine("Full Name: " + patientlist[i].FirstName + patientlist[i].Name);
                                    Console.WriteLine("Address: " + patientlist[i].StreetNumber + patientlist[i].Street + "," + patientlist[i].City + patientlist[i].State);
                                    Console.WriteLine("Email: " + patientlist[i].Email);
                                    Console.WriteLine("Phone: " + patientlist[i].Phone);
                                }
                            }
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;

                        case 2:
                            heading();
                            Console.WriteLine("         My Doctor        ");
                            Console.WriteLine("Your doctor:");
                            Console.WriteLine("Name                     | Email Address               | Phone             | Address                 ");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < patientlist.Count; i++)
                            {
                                if (patientlist[i].ID.Equals(id))
                                {
                                    Console.WriteLine(patientlist[i].Doctor[i].FirstName + patientlist[i].Doctor[i].Name + "|" + patientlist[i].Doctor[i].Email + "|" + patientlist[i].Doctor[i].Phone + "|" + patientlist[i].Doctor[i].StreetNumber + patientlist[i].Doctor[i].Street + "," + patientlist[i].Doctor[i].City + "," + patientlist[i].Doctor[i].State);
                                }
                            }
                            break;

                        case 3:
                            heading();
                            Console.WriteLine("         My Appointments        ");
                            //Console.WriteLine("Appointments for " + p.FirstName + p.Name);
                            break;

                        case 4:
                            heading();
                            Console.WriteLine("         Book Appointment        ");
                            Console.WriteLine("You are not registered with any doctor!Please choose which doctor you should like to register with");
                            for(int i=0;i<doctorlist.Count;i++)
                            {
                                Console.WriteLine(i + " " + doctorlist[i].FirstName + " " + doctorlist[i].Name + " | " + doctorlist[i].Email + " | " + doctorlist[i].Phone + " | " + doctorlist[i].StreetNumber + " " + doctorlist[i].Street + ", " + doctorlist[i].City + ", " + doctorlist[i].State);
                            }
                            Console.WriteLine("Please choose a doctor: ");
                            int ch = Convert.ToInt32(Console.ReadLine());
                            for(int i=0;i<doctorlist.Count;i++)
                            {
                                if(i==ch)
                                {
                                    Console.WriteLine("You are booking a new appointment with " + doctorlist[i].FirstName + " " + doctorlist[i].Name);
                                }
                            }
                            Console.WriteLine("Description of the appointment: ");
                            string des = Console.ReadLine();

                            break;

                        case 5:
                            Console.WriteLine("Logging Out...");
                      
                            return;

                        case 6:
                            Environment.Exit(0);
                            return;

                        default:
                            Console.WriteLine("Invalid option!!");
                            break;
                    }
                }
            }
            if (choice == 2)
            {
                Console.Clear();
                heading();

                Console.WriteLine("         Login        ");
                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Password: ");
                password = ReadPassword();

                for (int i = 0; i < doctorlist.Count; i++)
                {
                    if (doctorlist[i].ID.Equals(id) && doctorlist[i].Password.Equals(password))
                    {
                        Console.WriteLine("Valid Credentials");

                    }
                    Doctor d = doctorlist[i];
                }
            
                while (true)
                {
                    heading();
                    Console.WriteLine("         Doctor Menu        ");
                    Console.WriteLine("Welcome to DOTNET Hospital Management ");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1. List doctor details");
                    Console.WriteLine("2. List patients");
                    Console.WriteLine("3. List appointments");
                    Console.WriteLine("4. Check particular patient");
                    Console.WriteLine("5. List appointments with patient");
                    Console.WriteLine("6. Logout");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine("Enter your choice: ");
                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    Doctor d = null;
                    switch (choice1)
                    {
                        case 1:
                            heading();
                            Console.WriteLine("         My Details        ");
                            Console.WriteLine("Name                     | Email Address               | Phone             | Address                 ");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < doctorlist.Count; i++)
                            {
                                if (doctorlist[i].ID.Equals(id))
                                {
                                    Console.WriteLine(doctorlist[i].FirstName+" "+ doctorlist[i].Name + "|" + doctorlist[i].Email + "|" + doctorlist[i].Phone + "|" + doctorlist[i].StreetNumber + doctorlist[i].Street + "," + doctorlist[i].City + "," + doctorlist[i].State);
                                }
                            }
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;

                        case 2:
                            heading();
                            for (int i = 0; i < doctorlist.Count; i++)
                            {
                                if (doctorlist[i].ID.Equals(id))
                                {
                                   d = doctorlist[i];
                                }
                            }
                            Console.WriteLine("         My Patients        ");
                            Console.WriteLine("Patients assigned to " + d.FirstName + " " + d.Name);
                            Console.WriteLine("Patient               | Doctor          | Email Address               | Phone             | Address                 ");
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < patientlist.Count; i++)
                            {
                                if (patientlist[i].Doctor[i].FirstName.Equals(d.FirstName))
                                {
                                    Console.WriteLine(patientlist[i].FirstName +" "+ patientlist[i].Doctor[i].Name + "|" + patientlist[i].Doctor[i].FirstName+" "+ patientlist[i].Doctor[i].Name+"|"+ patientlist[i].Email + "|" + patientlist[i].Phone + "|" + patientlist[i].StreetNumber + patientlist[i].Street + "," + patientlist[i].City + "," + patientlist[i].State);
                                }
                            }
                            break;

                        case 3:
                            heading();
                            Console.WriteLine("         All Appointments        ");
                            Console.WriteLine("Doctor               | Patient          | Description               | Phone             | Address                 ");
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                            for(int i=0;i<appointmentlist.Count;i++)
                            {
                                Console.WriteLine(appointmentlist[i].Doctor.FirstName + " " + appointmentlist[i].Doctor.Name + "|" + appointmentlist[i].Patient.FirstName + " " + appointmentlist[i].Patient.Name + "|" + appointmentlist[i].Description);
                            }
                            break;

                        case 4:
                            heading();
                            Console.WriteLine("         Check Patient Details        ");
                            Console.WriteLine("Enter the ID of the patient to check: ");
                            int pid = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < patientlist.Count; i++)
                            {
                                if (patientlist[i].ID == pid)
                                {
                                    Console.WriteLine("Patient               | Doctor          | Email Address               | Phone             | Address                 ");
                                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine(patientlist[i].FirstName + " " + patientlist[i].Name + "|" + patientlist[i].Doctor[i].FirstName + " " + patientlist[i].Doctor[i].Name + "|" + patientlist[i].Email + "|" + patientlist[i].Phone + "|" + patientlist[i].StreetNumber + patientlist[i].Street + "," + patientlist[i].City + "," + patientlist[i].State);
                                }
                            }
                            break;

                        case 5:
                            heading();
                            Console.WriteLine("         Appointments With        ");
                            Console.WriteLine("Enter the ID of the patient you would like to view appointments for: ");
                            int paid = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < appointmentlist.Count; i++)
                            {
                                if (appointmentlist[i].Patient.ID == paid)
                                {
                                    Console.WriteLine("Doctor               | Patient          | Description            ");
                                    Console.WriteLine("-----------------------------------------------------------------");
                                    Console.WriteLine(appointmentlist[i].Doctor.FirstName + " " + appointmentlist[i].Doctor.Name + "|" + appointmentlist[i].Patient.FirstName + " " + appointmentlist[i].Patient.Name + " | " + appointmentlist[i].Description);


                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("Logging out...");
                         
                            return;
                            

                        case 7:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid option!!");
                            break;
                    }
                }
            }
            if (choice == 3)
            {
                bool continueLogin = true;
                while (continueLogin)
                {
                    Console.Clear();
                    heading();

                    Console.WriteLine("         Login        ");
                    Console.Write("ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Password: ");
                    string userPassword = ReadPassword(); // Renamed to userPassword

                    if (adminID == Convert.ToInt32(id) && pass == userPassword)
                    {
                        Console.WriteLine("Valid Credentials");
                        continueLogin = false; // Exit the login loop and continue with admin functionalities
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials");
                        Console.WriteLine("Press any key to try again or press 'e' to exit to main menu.");
                        var key = Console.ReadKey();
                        if (key.KeyChar == 'e' || key.KeyChar == 'E')
                        {
                            continueLogin = false; // Exit the login loop and return to main menu
                        }
                    }
                }
            }




            bool isAdminLoggedIn = true;
                while (isAdminLoggedIn)
                {
                    heading();
                    Console.WriteLine("         Administrator Menu        ");
                    Console.WriteLine("Welcome to DOTNET Hospital Management ");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1. List all doctors");
                    Console.WriteLine("2. Check doctor details");
                    Console.WriteLine("3. List all patients");
                    Console.WriteLine("4. Check patient details");
                    Console.WriteLine("5. Add doctor");
                    Console.WriteLine("6. Add patient");
                    Console.WriteLine("7. Logout");
                    Console.WriteLine("8. Exit");
                    Console.WriteLine("Enter your choice: ");
                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    
                    switch (choice1)
                    {
                        case 1:
                            heading();
                            Console.WriteLine("         All Doctors        ");
                            Console.WriteLine("All doctors registered to the DOTNET Hospital Management System");
                            Console.WriteLine("Name                     | Email Address               | Phone             | Address                 ");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < doctorlist.Count; i++)
                            {
                                Console.WriteLine(doctorlist[i].FirstName + " " + doctorlist[i].Name + "|" + doctorlist[i].Email + "|" + doctorlist[i].Phone + "|" + doctorlist[i].StreetNumber + doctorlist[i].Street + "," + doctorlist[i].City + "," + doctorlist[i].State);                
                            }
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;

                        case 2:
                            heading();
                            Console.WriteLine("         Doctor Details        ");
                            Console.WriteLine("Please enter the ID of the doctor who's details you are checking. Or press n to return to menu: ");
                            string doctorInput = Console.ReadLine().Trim().ToLower();

                            if (doctorInput == "n")
                            {
                                // Return to the menu
                                break;
                            }

                            int did;
                            if (!int.TryParse(doctorInput, out did))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid ID or press n to return to menu.");
                                break;
                            }

                            Console.WriteLine("Name                     | Email Address               | Phone             | Address                 ");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

                            for (int i = 0; i < doctorlist.Count; i++)
                            {
                                if (doctorlist[i].ID.Equals(did))
                                {
                                    Console.WriteLine(doctorlist[i].FirstName + " " + doctorlist[i].Name + "|" + doctorlist[i].Email + "|" + doctorlist[i].Phone + "|" + doctorlist[i].StreetNumber + doctorlist[i].Street + "," + doctorlist[i].City + "," + doctorlist[i].State);
                                }
                            }
                            break;


                        case 3:
                            heading();
                            Console.WriteLine("         All Patients        ");
                            Console.WriteLine("Patient               | Doctor          | Email Address               | Phone             | Address                 ");
                            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                            for (int i = 0; i < patientlist.Count; i++)
                            {
                                // Check if patient object is not null
                                if (patientlist[i] != null)
                                {
                                    // Check if Doctor array is not null and has at least one element
                                    string doctorName = "N/A";
                                    if (patientlist[i].Doctor != null && patientlist[i].Doctor.Length > 0 && patientlist[i].Doctor[0] != null)
                                    {
                                        doctorName = patientlist[i].Doctor[0].FirstName + " " + patientlist[i].Doctor[0].Name;
                                    }

                                    Console.WriteLine(patientlist[i].FirstName + " " + patientlist[i].Name + "|" + doctorName + "|" + patientlist[i].Email + " | " + patientlist[i].Phone + " | " + patientlist[i].StreetNumber + " " + patientlist[i].Street + ", " + patientlist[i].City + ", " + patientlist[i].State);
                                }
                            }
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;

                        case 4:
                            heading();
                        Console.WriteLine("         Patient Details        ");
                        Console.WriteLine("Please enter the ID of the patient who's details you are checking. Or press n to return to menu:");
                        string input = Console.ReadLine();

                        if (input.ToLower() != "n")
                        {
                            if (int.TryParse(input, out int pid))
                            {
                                Console.WriteLine($"{"Patient",-25}|{"Doctor",-20}|{"Email Address",-25}|{"Phone",-15}|{"Address"}");
                                Console.WriteLine(new string('-', 105));

                                var patient = patientlist.FirstOrDefault(p => p.ID == pid);
                                if (patient != null)
                                {
                                    string doctorName = "N/A";
                                    if (patient.Doctor != null && patient.Doctor.Length > 0 && patient.Doctor[0] != null)
                                    {
                                        doctorName = $"{patient.Doctor[0].FirstName} {patient.Doctor[0].Name}";
                                    }
                                    string patientName = $"{patient.FirstName} {patient.Name}";
                                    string address = $"{patient.StreetNumber} {patient.Street}, {patient.City}, {patient.State}";
                                    Console.WriteLine($"{patientName,-25}|{doctorName,-20}|{patient.Email,-25}|{patient.Phone,-15}|{address}");
                                }
                                else
                                {
                                    Console.WriteLine("No patient found with ID: " + pid);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid ID or press n to return to menu.");
                            }
                        }

                        break;


                        case 5:
                            heading();
                            Console.WriteLine("Enter Doctor Details:");

                            Console.Write("First Name: ");
                            firstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            lastName = Console.ReadLine();

                            Console.Write("Email: ");
                            email = Console.ReadLine();

                            Console.Write("Phone: ");
                            phone = Console.ReadLine();

                            Console.Write("Street Number: ");
                            streetNumber = Console.ReadLine();

                            Console.Write("Street: ");
                            street = Console.ReadLine();

                            Console.Write("City: ");
                            city = Console.ReadLine();

                            Console.Write("State: ");
                            state = Console.ReadLine();

                            Doctor newDoctor = new Doctor(0, lastName, "", firstName, email, phone, streetNumber, street, city, state);
                            FileManager.SaveDoctor(newDoctor);
                            doctorlist.Add(newDoctor);

                            Console.WriteLine("Doctor added successfully!");
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;

                        case 6:
                            heading();
                            Console.WriteLine("Enter Patient Details:");

                            Console.Write("First Name: ");
                            firstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            lastName = Console.ReadLine();

                            Console.Write("Email: ");
                            email = Console.ReadLine();

                            Console.Write("Phone: ");
                            phone = Console.ReadLine();

                            Console.Write("Street Number: ");
                            streetNumber = Console.ReadLine();

                            Console.Write("Street: ");
                            street = Console.ReadLine();

                            Console.Write("City: ");
                            city = Console.ReadLine();

                            Console.Write("State: ");
                            state = Console.ReadLine();

                            Patient newPatient = new Patient(0, lastName, "", firstName, email, phone, streetNumber, street, city, state);
                            FileManager.SavePatient(newPatient);
                            patientlist.Add(newPatient);

                            Console.WriteLine("Patient added successfully!");
                            Console.WriteLine("Press any key to return to menu.");
                            Console.ReadKey();
                            break;

                        case 7:
                            Console.WriteLine("Logging out...");
                            isAdminLoggedIn = false; // Set the flag to false to exit the loop
                            break;

                        case 8:
                            Console.WriteLine("Exiting system...");
                            Environment.Exit(0); // Exit the application
                            break;

                        default:
                            Console.WriteLine("Invalid option!!");
                            break;
                    }
                }
            }
        }

   }



