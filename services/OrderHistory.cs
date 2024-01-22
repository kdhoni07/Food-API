using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
namespace TokenApi.services
{
    public class OrderHistory
    {
        dbServices ds = new dbServices();
        public async Task<responseData> PlaceOrder(requestData req)
        {
            responseData resData = new responseData();
            MySqlParameter[] items = new MySqlParameter[]{
                                 new MySqlParameter("@ID",req.addInfo["ID"]),
                              
                               
            };
            try
            {

                var result = new ArrayList();
                var query1 = $"Select * from Food_FinalCart WHERE ID=@ID and (Status=1 or Status=2)";
                var data = ds.ExecuteSQLName(query1, items);
                if (data == null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "No order placed";
                }
                else
                {
                    var list = new List<Dictionary<string, object>>();
                    for (var i = 0; i < data.Count(); i++)
                    {
                      foreach (var row in data[i])
                        {
                            Dictionary<string, object> myDict = new Dictionary<string, object>();

                            foreach (var field in row.Keys)
                            {
                                myDict[field] = row[field].ToString();
                            }

                            result.Add(myDict);
                        } 
                    }
                   resData.rData["rData"] =result;
                   resData.rData["rCode"]=0;
                     resData.rData["rMessage"] = "displayed data";
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Previous order displayed sucessfully";
                    }
                   
                resData.rData["ID"] = data[0][0]["ID"];

                resData.rData["rMessage"] = "displayed data";
            }
            catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
    }
}