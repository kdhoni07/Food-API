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
    public class ShowOrder
    {
        dbServices ds = new dbServices();
        public async Task<responseData> DisplayOrder(requestData req)
        {
            responseData resData = new responseData();

            try
            {
                 MySqlParameter[] items = new MySqlParameter[]{
                                 new MySqlParameter("@ID",req.addInfo["ID"]),
                                  new MySqlParameter("@txt",req.addInfo["txt"]),
                                   new MySqlParameter("@Food_Type",req.addInfo["Food_Type"].ToString()),
                                    new MySqlParameter("@Food_Rating",req.addInfo["Food_Rating"].ToString()),
                                   new MySqlParameter("@Quantity",req.addInfo["Quantity"]),
                                    new MySqlParameter("@Price",req.addInfo["Price"]),
                                     new MySqlParameter("@Total_Price",req.addInfo["Total_Price"]),    
                                     new MySqlParameter("@Image",req.addInfo["Image"].ToString()),    
                                 new MySqlParameter("@Status",1),
                 };
                var result = new ArrayList();
                var query = $"Insert into Food_FinalCart(ID, txt, Image, Food_Type, Food_Rating, Quantity, Price, Total_Price, Status) values(@ID, @txt, @Image, @Food_Type, @Food_Rating, @Quantity, @Price, @Total_Price, @Status)" ;
                var checkData = ds.ExecuteSQLName(query, items);
                if (checkData == null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "No order placed";
                }
                else
                {
                    // takes the user order  into Food_FinalCart and then display that order to user
                    var document = new Dictionary<string, object>();
                    var query1 = $"Select * from Food_FinalCart WHERE ID=@ID  and Status=@Status";
                    var data = ds.ExecuteSQLName(query1, items);
                    if (data != null)
                    {
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Order placed sucessfully";
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
                     resData.rData["ID"] = data[0][0]["ID"];
                     resData.rData["rMessage"] = "displayed data";
                    }
                    else
                    {
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "No order to show";
                    }
            }
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
    
