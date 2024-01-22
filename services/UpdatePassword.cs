using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace TokenApi.services
{
    public class UpdatePassword
    {
        dbServices ds = new dbServices();
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        public async Task<responseData> PasswordUpdate(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
            try
            {
                
                MySqlParameter[] myParams = new MySqlParameter[] {

                new MySqlParameter("@ID",req.addInfo["ID"]),
                new MySqlParameter("@U_OldPassword",req.addInfo["U_OldPassword"].ToString()),
                // new MySqlParameter("@U_Mobile",mobile),
                new MySqlParameter("@U_NewPassword",req.addInfo["U_NewPassword"].ToString()),
                }; 
                var exist=$"select * from Food_Table where U_Password=@U_OldPassword";
                var exists = ds.executeSQL(exist, myParams);
                if(exists!=null && exists[0].Count()>0) 
                {
                    var sq = $"update Food_Table set U_Password=@U_NewPassword where ID=@ID;";
                     var data = ds.executeSQL(sq, myParams);
                
                if (data!=null)
                {
                    resData.eventID = req.eventID;
                    resData.rData["rMessage"] = "Password Updated Successfully";
                }
                else
                {
                  resData.rData["rCode"] = 1;
                  resData.rData["rMessage"] = "Invalid Credentials and password not updated";  
                } 
                }
                else{
                    resData.rData["rMessage"] = "The old password entered does not exist"; 
                    resData.rData["rCode"]=1;
                }
                
            }
            catch (Exception ex)
            {
                resData.rData["rCode"]=1;
                resData.rData["rMessage"]=ex.Message;
            }
            return resData;
    }
    }
}







