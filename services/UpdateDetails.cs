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
    public class UpdateDetails
    {

        dbServices ds = new dbServices();
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
//user details like name,emaiid and mobile
        public async Task<responseData> UpdateAll(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
           
            try{

                  var id=req.addInfo["ID"];
                 string name=req.addInfo["U_Name"].ToString();
                 string emailId = req.addInfo["U_Email"].ToString();
                 string mobile=req.addInfo["U_Mobile"].ToString();        
                string image= req.addInfo["Image_Name"].ToString();
                MySqlParameter[] myParams = new MySqlParameter[] {
                     new MySqlParameter("@ID", req.addInfo["ID"]),
                     new MySqlParameter("@U_Name",req.addInfo["U_Name"]),
                new MySqlParameter("@U_Email", req.addInfo["U_Email"]),
               new MySqlParameter("@U_Mobile",req.addInfo["U_Mobile"]),
                  new MySqlParameter("@Image_Name", image),
                    new MySqlParameter("@U_Status", 1)
                };
                
         var updateQuery=$"UPDATE Food_Table SET U_Name=@U_Name,U_Email=@U_Email,U_Mobile=@U_Mobile,Image_Name=@Image_Name,U_Status=@U_Status WHERE ID=@ID";
         var updateStore=ds.executeSQL(updateQuery, myParams);
               if(updateStore==null){
                 resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "No details updated ";
               }
               else{ 
               
                    resData.eventID=resData.eventID;
                     resData.rData["rCode"] = 0;
                     resData.rData["rMessage"] = " User Details updated properly";
              
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


    

    
