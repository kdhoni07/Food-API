using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

namespace TokenApi.services
{
    public class DisplayOnCart
    {
        //order
        dbServices ds = new dbServices();
        public async Task<responseData> ShowItemOnOrder(requestData req)
        {
            responseData resData = new responseData();
           // display data when we go to add any item to cart and update in database also
            try
            {
                  var list= new ArrayList();
                MySqlParameter[] items = new MySqlParameter[]{
                    new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                     new MySqlParameter("@txt",req.addInfo["txt"]),
                                 new MySqlParameter("@Status",0)
            };
                var query = $"Select * from Food_Cart where U_FID=@U_FID and txt=@txt";
                var dataQuery = ds.ExecuteSQLName(query, items);
                if (dataQuery==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Error in Payload";  
                }
                else
                {
                      var document = new Dictionary<String, object>();

                        for (int i = 0; i < dataQuery[0].Count(); i++)
                        {
                            document.Add("U_FID", dataQuery[0][i]["U_FID"]);
                            document.Add("txt", dataQuery[0][i]["txt"]);
                            document.Add("Image", dataQuery[0][i]["Image"]);
                            document.Add("Food_Type", dataQuery[0][i]["Food_Type"]);
                            document.Add("Food_Rating", dataQuery[0][i]["Food_Rating"]);
                            document.Add("Price", dataQuery[0][i]["Price"]);
                           
                        }

                        list.Add(document);
                        resData.rData["rData"] = list;
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Data in cart displayed sucessfully";

               
    }
}
 catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }

        //"eventID":"1002"
          public async Task<responseData> OrderPizza(requestData req)
        {
            responseData resData = new responseData();
           // display data when we go to add any item to cart and update in database also
            try
            {
                  var list= new ArrayList();
                MySqlParameter[] items = new MySqlParameter[]{
                    new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                        new MySqlParameter("@txt",req.addInfo["txt"]),
                                 new MySqlParameter("@Status",1)
            };
            // just displays images to user
                var query = $"Select * from Pizza where U_FID=@U_FID and txt=@txt ";
                var dataQuery = ds.ExecuteSQLName(query, items);
                if (dataQuery==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Error in Payload";  
                }
                else
                {
                      var document = new Dictionary<String, object>();

                        for (int i = 0; i < dataQuery[0].Count(); i++)
                        {
                            document.Add("U_FID", dataQuery[0][i]["U_FID"]);
                              document.Add("txt", dataQuery[0][i]["txt"]);
                            document.Add("Image", dataQuery[0][i]["Image"]);
                            document.Add("Food_Type", dataQuery[0][i]["Food_Type"]);
                            document.Add("Food_Rating", dataQuery[0][i]["Food_Rating"]);
                            document.Add("Price", dataQuery[0][i]["Price"]);
                            // document.Add("Total_Price", dataQuery[0][i]["Total_Price"]);
                        }

                        list.Add(document);
                        resData.rData["rData"] = list;
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Successfully displayed pizza images to User";   
                      
    }

                
            }
 catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }
        //"eventID":"1003"
         public async Task<responseData> OrderPasta(requestData req)
        {
            responseData resData = new responseData();
           // display data when we go to add any item to cart and update in database also
            try
            {
                  var list= new ArrayList();
                MySqlParameter[] items = new MySqlParameter[]{
                    new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                        new MySqlParameter("@txt",req.addInfo["txt"]),
                                 new MySqlParameter("@Status",1)
            };
            // just displays images to user
                var query = $"Select * from Pasta where U_FID=@U_FID and txt=@txt ";
                var dataQuery = ds.ExecuteSQLName(query, items);
                if (dataQuery==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Error in Payload";  
                }
                else
                {
                      var document = new Dictionary<String, object>();
                        for (int i = 0; i < dataQuery[0].Count(); i++)
                        {
                            document.Add("U_FID", dataQuery[0][i]["U_FID"]);
                              document.Add("txt", dataQuery[0][i]["txt"]);
                            document.Add("Image", dataQuery[0][i]["Image"]);
                            document.Add("Food_Type", dataQuery[0][i]["Food_Type"]);
                            document.Add("Food_Rating", dataQuery[0][i]["Food_Rating"]);
                            document.Add("Price", dataQuery[0][i]["Price"]);
                          
                        }

                        list.Add(document);
                        resData.rData["rData"] = list;
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Successfully displayed pasta images to User";                   
    }  
            }
 catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }

//"eventID":"1003"
         public async Task<responseData> OrderSalad(requestData req)
        {
            responseData resData = new responseData();
           // display data when we go to add any item to cart/order it and update in database also
            try
            {
                  var list= new ArrayList();
                MySqlParameter[] items = new MySqlParameter[]{
                    new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                        new MySqlParameter("@txt",req.addInfo["txt"]),
                                 new MySqlParameter("@Status",1)
            };
            // just displays images to user
                var query = $"Select * from Salad where U_FID=@U_FID and txt=@txt ";
                var dataQuery = ds.ExecuteSQLName(query, items);
                if (dataQuery==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Error in Payload";  
                }
                else
                {
                      var document = new Dictionary<String, object>();

                        for (int i = 0; i < dataQuery[0].Count(); i++)
                        {
                            document.Add("U_FID", dataQuery[0][i]["U_FID"]);
                              document.Add("txt", dataQuery[0][i]["txt"]);
                            document.Add("Image", dataQuery[0][i]["Image"]);
                            document.Add("Food_Type", dataQuery[0][i]["Food_Type"]);
                            document.Add("Food_Rating", dataQuery[0][i]["Food_Rating"]);
                            document.Add("Price", dataQuery[0][i]["Price"]);
                            // document.Add("Total_Price", dataQuery[0][i]["Total_Price"]);
                        }

                        list.Add(document);
                        resData.rData["rData"] = list;
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Successfully displayed salad images to User";   
                      
    }

                
            }
 catch (Exception e)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = e.Message;
            }
            return resData;
        }

        //"eventID":"1005"
         public async Task<responseData> OrderBurger(requestData req)
        {
            responseData resData = new responseData();
           // display data when we go to add any item to cart and update in database also
            try
            {
                  var list= new ArrayList();
                MySqlParameter[] items = new MySqlParameter[]{
                    new MySqlParameter("@U_FID",req.addInfo["U_FID"]),
                    //   new MySqlParameter("@ID",req.addInfo["ID"]),
                        new MySqlParameter("@txt",req.addInfo["txt"]),
                                //    new MySqlParameter("@Total_Price",req.addInfo["Total_Price"]),
                                //    new MySqlParameter("@Quantity",req.addInfo["Quantity"]),
                                 new MySqlParameter("@Status",1)
            };
            // just displays images to user
                var query = $"Select * from Burger where U_FID=@U_FID and txt=@txt ";
                var dataQuery = ds.ExecuteSQLName(query, items);
                if (dataQuery==null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Error in Payload";  
                }
                else
                {
                      var document = new Dictionary<String, object>();

                        for (int i = 0; i < dataQuery[0].Count(); i++)
                        {
                            document.Add("U_FID", dataQuery[0][i]["U_FID"]);
                              document.Add("txt", dataQuery[0][i]["txt"]);
                            document.Add("Image", dataQuery[0][i]["Image"]);
                            document.Add("Food_Type", dataQuery[0][i]["Food_Type"]);
                            document.Add("Food_Rating", dataQuery[0][i]["Food_Rating"]);
                            document.Add("Price", dataQuery[0][i]["Price"]);
                            // document.Add("Total_Price", dataQuery[0][i]["Total_Price"]);
                        }

                        list.Add(document);
                        resData.rData["rData"] = list;
                        resData.rData["rCode"] = 0;
                        resData.rData["rMessage"] = "Successfully displayed burger images to User";             
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

                        
    


    

























