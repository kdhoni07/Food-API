using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System.Collections;

namespace TokenApi.services
{
    // used to display user details like NAME PHONE EMAIL AND PASSWORD
    public class UserDetails
    {
        dbServices ds = new dbServices();
        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        

        public async Task<responseData> GetDataById(requestData req)
        {
            responseData resData= new responseData();
            resData.rData["rCode"]=0;
           
            try{

               var list= new ArrayList();
                MySqlParameter[] myParams = new MySqlParameter[] {
                    new MySqlParameter("@ID",req.addInfo["ID"]),
                    //    new MySqlParameter("@System_Guid",req.addInfo["System_Guid"]),
                        
                };

             var query=$"SELECT * FROM Food_Table where ID=@ID;";
             var dataQuery=ds.ExecuteSQLName(query,myParams);
                if ( dataQuery==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "cannot display data";

                }
                
                else{
                   var document= new Dictionary<String,object>();
                   for(int i=0;i<dataQuery[0].Count();i++){
                    document.Add("U_Name",dataQuery[0][i]["U_Name"]);
                    document.Add ("U_Email",dataQuery[0][i]["U_Email"]);  
                     document.Add("U_Mobile",dataQuery[0][i]["U_Mobile"]);
                    document.Add("Image_Name",dataQuery[0][i]["Image_Name"]);
                  
                   
                 }
                 
 list.Add(document);
              resData.rData["rData"] =list;
                     
               resData.rData["rCode"]=0;
                   resData.rData["ID"] = dataQuery[0][0]["ID"];
                     resData.rData["rMessage"] = "displayed data";    
             
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




    

    

    
