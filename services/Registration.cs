using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace TokenApi.services
{
   
    
    public class Registration
    {
    
        dbServices ds = new dbServices();
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        

        public async Task<responseData> Register(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
           
            try{

                
                 string emailId = req.addInfo["U_Email"].ToString();
                 string mobile=req.addInfo["U_Mobile"].ToString();
                 bool validEmaild=IsValidEmail(emailId);
                  bool validMobile=IsValidMobileNumber(mobile);
                  string email;
                  string mobileNo;

                 if(validEmaild && validMobile){
                  email=emailId;
                   mobileNo=mobile;
       
                MySqlParameter[] myParams = new MySqlParameter[] {
                     new MySqlParameter("@U_Name", req.addInfo["U_Name"].ToString()),
               new MySqlParameter("@U_Mobile",mobileNo),
                new MySqlParameter("@U_Email", email),
                new MySqlParameter("@U_Password", req.addInfo["U_Password"].ToString()),
                  new MySqlParameter("@Image_Name", req.addInfo["Image_Name"].ToString()),
                    new MySqlParameter("@U_Status", 1)
                };
           //validation
                var exists= $"SELECT * FROM Food_Table WHERE U_Email = @U_Email OR U_Mobile=@U_Mobile";
                var validation = ds.executeSQL(exists,myParams);
              
                if(validation==null|| validation[0].Count()==0 ){
                var sq = $"INSERT INTO Food_Table(U_Name,U_Mobile,U_Email,U_Password,Image_Name,U_Status) VALUES(@U_Name,@U_Mobile,@U_Email,@U_Password,@Image_Name,@U_Status);";
                var dataQuery = ds.executeSQL(sq,myParams);
               
                if ( dataQuery!=null)
                {
                     resData.eventID=resData.eventID;
                     resData.rData["rMessage"] = " Registration done properly";
                }
                else 
                {  
                  resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Invalid Credentials ";
                }
                }
                 
                 else{
                    resData.rData["Message"] ="duplicate data found registration not done";
                }
                 
                }
                 else{
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Enter valid email and Phone number ";
                }
                 
            }
            catch (Exception ex)
            {
                resData.rData["rCode"]=1;
                resData.rData["rMessage"]=ex.Message;
            }
            return resData;
           
            
        }
       
 public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool IsValidMobileNumber(string phoneNumber)
        {
            string pattern = @"^[0-9]{7,15}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
       
        
    }
   
}

