using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Hospital_Management_System
{
    public class FileManager
    {
        private static string doctorFilePath = Path.Combine(Environment.CurrentDirectory, "doctors.txt");
        private static string patientFilePath = Path.Combine(Environment.CurrentDirectory, "patients.txt");
        public enum UserType
        {
            Doctor,
            Patient,
            Administrator,
            Undefined
        }

        public static void SaveDoctor(Doctor doctor)
        {
            int randomID = doctor.GenerateRandomID();
            string randomPassword = doctor.GenerateRandomPassword();

            string doctorData = $"{randomID},{randomPassword},{doctor.FirstName},{doctor.Name},{doctor.Email},{doctor.Phone},{doctor.StreetNumber},{doctor.Street},{doctor.City},{doctor.State}";

            using (StreamWriter writer = new StreamWriter(doctorFilePath, append: true))
            {
                writer.WriteLine(doctorData);
            }
        }

        public static void SavePatient(Patient patient)
        {
            int randomID = patient.GenerateRandomID();
            string randomPassword = patient.GenerateRandomPassword();

            string patientData = $"{randomID},{randomPassword},{patient.FirstName},{patient.Name},{patient.Email},{patient.Phone},{patient.StreetNumber},{patient.Street},{patient.City},{patient.State}";

            using (StreamWriter writer = new StreamWriter(patientFilePath, append: true))
            {
                writer.WriteLine(patientData);
            }
        }
        public static Patient GetPatientByID(int id)
        {
            foreach (string line in File.ReadLines(patientFilePath))
            {
                var patientDetails = line.Split(',');
                int extractedID;
                if (int.TryParse(patientDetails[0], out extractedID) && extractedID == id)
                {
                    int parsedID = extractedID;
                    string firstName = patientDetails[1];
                    string lastName = patientDetails[2];
                    string email = patientDetails[3];
                    string phone = patientDetails[4];
                    string streetNumber = patientDetails[5];
                    string street = patientDetails[6];
                    string city = patientDetails[7];
                    string state = patientDetails[8];
                    return new Patient(parsedID, lastName, "", firstName, email, phone, streetNumber, street, city, state);
                }
            }
            return null;
        }


        public static bool CheckCredentials(string id, string password, UserType userType)
        {
            string selectedFilePath;

            switch (userType)
            {
                case UserType.Doctor:
                    selectedFilePath = doctorFilePath;
                    break;
                case UserType.Patient:
                    selectedFilePath = patientFilePath; 
                    break;
                default:
                    throw new ArgumentException("Invalid user type.");
            }

            try
            {
                foreach (string line in File.ReadLines(selectedFilePath))
                {
                    var credentials = line.Split(',');

                    if (credentials[0] == id && credentials[1] == password)  
                    {
                        return true;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }

            return false;  
        }
        }

    }



