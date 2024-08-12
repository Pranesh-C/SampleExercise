using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace SampleExercise
{
   public class Smtp
    {
        private readonly IConfiguration configuration;

      
        public Smtp(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public void FileLog() 
        {
            string file = $"File_{DateTime.Now.ToString("yyy-MM-dd")}.text";
            try
            {
                Send();
                StreamWriter sw = new StreamWriter($"D:{file}.text", false);
                sw .WriteLine($"Succefully send Mail in {DateTime.Now.ToString(" yyy-MM-dd")}");
                sw.Close();


            }
            catch (Exception e) 
            {
                StreamWriter sw1 = new StreamWriter($"D:{file}.text", false);
                sw1.WriteLine(e.StackTrace);
                sw1.Close();

            }



        }

        public void Send()
        {
            Console.WriteLine("Hello World!");
            SendEmail(fromAddress: GetUserName(), GetPassword());
            Console.ReadLine();
        }
        public  void SendEmail(string fromAddress, string password)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(userName: fromAddress, password)

            };
            string subject = "PRANESH";
            string body = $"Hello! My name is pranesh, and I have a question about [specific course/issue]. Can you help me this is the main mail sent @ {DateTime.UtcNow:F}";

            try
            {
                Console.WriteLine("sending email ****");
                email.Send(fromAddress, ToAddress(), subject, body);
                Console.WriteLine("email sent");

            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }

        }
        public  string GetUserName()
        {
            var dataFromJsonFile = configuration.GetSection("FromAddress").Value;
            // Console.writeline(dataFromJsonFile);
            return dataFromJsonFile;
        }
        public  string GetPassword()
        {
            var dataFromJsonFile = configuration.GetSection("password").Value;
            // Console.writeline(dataFromJsonFile);
            return dataFromJsonFile;
        }
        public  string ToAddress()
        {
            var dataFromJsonFile = configuration.GetSection("To").Value;
            // Console.writeline(dataFromJsonFile);
            return dataFromJsonFile;
        }



    } 
}    
