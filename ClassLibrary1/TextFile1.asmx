﻿//  
// QuickBooks Web Connector Sample: WCWebService  
// Copyright (c) 2006-2007 Intuit, Inc  
//  
// This sample is a C# ASP.NET web service application that  
// communicates with QuickBooks Point of Sale via QBWebConnector. The  
// sample focuses primarily on demonstrating how to setup all web service  
// web methods to run against QBWebConnector and does not focus on any  
// particular use case. For simplicity, it sends three request XMLs:  
// CustomerQuery, ItenInventoryQuery and PurchaseOrderQuery.  
//  
// This sample assumes that you have configured IIS with ASP.NET and  
// have a functional system to deploy this web service sample. If you have  
// not yet configured ASP.NET with IIS, you may need to run the  
// following command from c:\windows\Microsoft.NET\Framework\  
// your_asp_dot_net_version path: -  
// aspnet_regiis /i  
// This will help avoid the occasional message from microsoft development  
// environment such as "VS.NET has detected that the specified web server  
// is not running ASP.NET version 1.1. You will be unable to run ASP.NET  
// web applications or services)".  
  
  
/* 
 * Useful note about using OwnerID and FileID in a real-world application 
 * 
 * As part of your QB Web Connector configuration (.QWC) file, you include 
 * OwnerID and FileID. Following note on these two parameters may be useful. 
 * 
 * OwnerID -- this is a GUID that represents your application or suite of 
 * applications, if your application needs to store private data in the 
 * company file for one reason or another (one of the most common cases 
 * being to check if you have communicated with this company file before, 
 * and possibly some data about that communication) that private data will 
 * be visible to any application that knows the OwnerID. 
 * 
 * FileID -- this is a GUID we stamp in the file on your behalf 
 * (using your OwnerID) as a private data extension to the "Company" object. 
 * It allows an application to verify that the company file it is exchanging 
 * data with is consistent over time (by doing a CompanyQuery with the field 
 * set appropriately and reading the DataExtRet values returned. 
 * 
 * */  
  
  
using System;  
using System.Collections;  
using System.ComponentModel;  
using System.Data;  
using System.Diagnostics;  
using System.Web;  
using System.Web.Services;  
using System.IO;  
using System.Security.Cryptography;  
using Microsoft.Win32;  
using System.Xml;  
using System.Text.RegularExpressions;  
  
  
namespace QWCPOSWebService  
{  
    /// <summary>  
    ///  Web Service Namespace="http://developer.intuit.com/",  
    ///  Web Service Name="QWCPOSWebService",  
    ///  Web Service Description="Sample WebService in ASP.NET to  
    ///  demonstrate QBWebConnector with QuickBooks POS  
    /// </summary>  
    [WebService(  
         Namespace = "http://developer.intuit.com/",  
         Name = "QWCPOSWebService",  
         Description = "Sample WebService in ASP.NET to demonstrate " +  
                "QBWebConnector with QuickBooks POS")]  
  
  
    // Important Note:  
    // You should keep the namespace as http://developer.intuit.com/ for all web  
    // services that communicates with QuickBooks Web Connector.   
    public class QWCPOSWebService : System.Web.Services.WebService  
    {  
        #region GlobalVariables  
        System.Diagnostics.EventLog evLog = new System.Diagnostics.EventLog();  
        public int count = 0;  
        public ArrayList req = new ArrayList();  
        #endregion  
 
 
        #region Constructor  
        public QWCPOSWebService()  
        {  
            //CODEGEN: This call is required by the ASP.NET  
            //Web Services Designer  
            InitializeComponent();  
            // Initializing EventLog for logging  
            initEvLog();  
        }  
        #endregion  
 
 
        #region AutoGeneratedMethods  
        //Required by the Web Services Designer   
        private IContainer components = null;  
  
  
        /// <summary>  
        /// Required method for Designer support - do not modify  
        /// the contents of this method with the code editor.  
        /// </summary>  
        private void InitializeComponent()  
        {  
        }  
  
  
        /// <summary>  
        /// Clean up any resources being used.  
        /// </summary>  
        protected override void Dispose(bool disposing)  
        {  
            if (disposing && components != null)  
            {  
                components.Dispose();  
            }  
            base.Dispose(disposing);  
        }  
 
 
        #endregion  
 
 
        #region WebMethods  
        [WebMethod]  
        /// <summary>  
        /// WebMethod# 1 - clientVersion()  
        /// To enable web service with QBWC version control  
        /// Signature: public string clientVersion(string strVersion)  
        ///  
        /// IN:  
        /// string strVersion  
        ///  
        /// OUT:  
        /// string errorOrWarning  
        /// Possible values:  
        /// string retVal  
        /// - NULL or <emptyString> = QBWC will let the web service update  
        /// - "E:<any text>" = popup ERROR dialog with <any text>  
        /// - abort update and force download of new QBWC.  
        /// - "W:<any text>" = popup WARNING dialog with <any text>  
        /// - choice to user, continue update or not.  
        /// </summary>  
        public string clientVersion(string strVersion)  
        {  
            string evLogTxt = "WebMethod: clientVersion() has been called " +  
                "by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string strVersion = " + strVersion + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
              
  
            string retVal = null;  
            double recommendedVersion = 1.5;  
            double supportedMinVersion = 1.0;  
            double suppliedVersion = Convert.ToDouble(this.parseForVersion(strVersion));  
            evLogTxt = evLogTxt + "QBWebConnector version = " + strVersion + "\r\n";  
            evLogTxt = evLogTxt + "Recommended Version = " + recommendedVersion.ToString() + "\r\n";  
            evLogTxt = evLogTxt + "Supported Minimum Version = " + supportedMinVersion.ToString() + "\r\n";  
            evLogTxt = evLogTxt + "SuppliedVersion = " + suppliedVersion.ToString() + "\r\n";  
            if (suppliedVersion < recommendedVersion)  
            {  
                retVal = "W:We recommend that you upgrade your QBWebConnector";  
            }  
            else if (suppliedVersion < supportedMinVersion)  
            {  
                retVal = "E:You need to upgrade your QBWebConnector";  
            }  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "string retVal = " + retVal;  
            logEvent(evLogTxt);  
            return retVal;  
        }  
        [WebMethod]  
        /// <summary>  
        /// WebMethod# 2 - authenticate()  
        /// To verify username and password for the web connector that is trying to connect  
        /// Signature: public string[] authenticate(string strUserName, string strPassword)  
        ///  
        /// IN:  
        /// string strUserName  
        /// string strPassword  
        ///  
        /// OUT:  
        /// string[] authReturn  
        /// Possible values:  
        /// string[0] = ticket  
        /// string[1]  
        /// - empty string = use current company file  
        /// - "none" = no further request/no further action required  
        /// - "nvu" = not valid user  
        /// - any other string value = use this company file  
        /// </summary>  
        public string[] authenticate(string strUserName, string strPassword)  
        {  
            string evLogTxt = "WebMethod: authenticate() has been called by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string strUserName = " + strUserName + "\r\n";  
            evLogTxt = evLogTxt + "string strPassword = " + strPassword + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
            string[] authReturn = new string[2];  
            // Code below uses a random GUID to use as session ticket  
            // An example of a GUID is {85B41BEE-5CD9-427a-A61B-83964F1EB426}  
            authReturn[0] = System.Guid.NewGuid().ToString();  
  
  
            // For simplicity of sample, a hardcoded username/password is used.  
            // In real world, you should handle authentication in using a standard way.  
            // For example, you could validate the username/password against an LDAP  
            // or a directory server  
            string pwd = "password";  
            evLogTxt = evLogTxt + "Password locally stored = " + pwd + "\r\n";  
            if (strUserName.ToUpper().Trim().Equals("USERNAME") && strPassword.ToUpper().Trim().Equals(pwd.ToUpper()))  
            {  
                // An empty string for authReturn[1] means asking QBWebConnector  
                // to connect to the company file that is currently openned in QB  
                authReturn[1] = "Company Data=IqbalStore";  
            }  
            else  
            {  
                authReturn[1] = "nvu";  
            }  
            // You could also return "none" to indicate there is no work to do  
            // or a company filename in the format C:\full\path\to\company.qbw  
            // based on your program logic and requirements.  
  
  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "string[] authReturn[0] = " + authReturn[0].ToString() + "\r\n";  
            evLogTxt = evLogTxt + "string[] authReturn[1] = " + authReturn[1].ToString();  
            logEvent(evLogTxt);  
            return authReturn;  
        } 
        [WebMethod(Description = "This web method facilitates web service to handle connection errors between QuickBooks and QBWebConnector", EnableSession = true)]  
        /// <summary>  
        /// WebMethod# 3 - connectionError()  
        /// To facilitate capturing of QuickBooks error and notifying it to web services  
        /// Signature: public string connectionError (string ticket, string hresult, string message)  
        ///  
        /// IN:  
        /// string ticket = A GUID based ticket string to maintain identity of QBWebConnector  
        /// string hresult = An HRESULT value thrown by QuickBooks when trying to make connection  
        /// string message = An error message corresponding to the HRESULT  
        ///  
        /// OUT:  
        /// string retVal  
        /// Possible values:  
        /// - “done” = no further action required from QBWebConnector  
        /// - any other string value = use this name for company file  
        /// </summary>  
        public string connectionError(string ticket, string hresult, string message)  
        {  
            if (Session["ce_counter"] == null)  
            {  
                Session["ce_counter"] = 0;  
            }  
  
  
            string evLogTxt = "WebMethod: connectionError() has been called by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string ticket = " + ticket + "\r\n";  
            evLogTxt = evLogTxt + "string hresult = " + hresult + "\r\n";  
            evLogTxt = evLogTxt + "string message = " + message + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
  
  
            string retVal = null;  
            //-2147418113 = Can't connect to the database  
            const string CANT_CONNECT_TO_DB = "0x8000FFFF";  
            // Add more as you need...  
  
  
            if (hresult.Trim().Equals(CANT_CONNECT_TO_DB))  
            {  
                evLogTxt = evLogTxt + "HRESULT = " + hresult + "\r\n";  
                evLogTxt = evLogTxt + "Message = " + message + "\r\n";  
                retVal = "DONE";  
            }  
            else  
            {  
                // Depending on various hresults return different value   
                if ((int)Session["ce_counter"] == 0)  
                {  
                    // Try again with this company file  
                    evLogTxt = evLogTxt + "HRESULT = " + hresult + "\r\n";  
                    evLogTxt = evLogTxt + "Message = " + message + "\r\n";  
                    evLogTxt = evLogTxt + "Sending connection string as \"Company Data=\" to QBWebConnector.";  
                    retVal = "Company Data=";  
                }  
                else  
                {  
                    evLogTxt = evLogTxt + "HRESULT = " + hresult + "\r\n";  
                    evLogTxt = evLogTxt + "Message = " + message + "\r\n";  
                    evLogTxt = evLogTxt + "Sending DONE to stop.";  
                    retVal = "DONE";  
                }  
            }  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "string retVal = " + retVal + "\r\n";  
            logEvent(evLogTxt);  
            Session["ce_counter"] = ((int)Session["ce_counter"]) + 1;  
            return retVal;  
        }  
        [WebMethod(Description = "This web method facilitates web service to send request XML to QuickBooks via QBWebConnector", EnableSession = true)]  
        /// <summary>  
        /// WebMethod# 4 - sendRequestXML()  
        /// Signature: public string sendRequestXML(string ticket, string strHCPResponse, string strCompanyFileName,  
        /// string Country, int qbXMLMajorVers, int qbXMLMinorVers)  
        ///  
        /// IN:  
        /// int qbXMLMajorVers  
        /// int qbXMLMinorVers  
        /// string ticket  
        /// string strHCPResponse  
        /// string strCompanyFileName  
        /// string Country  
        /// int qbXMLMajorVers  
        /// int qbXMLMinorVers  
        ///  
        /// OUT:  
        /// string request  
        /// Possible values:  
        /// - “any_string” = Request XML for QBWebConnector to process  
        /// - "" = No more request XML  
        /// </summary>  
        public string sendRequestXML(string ticket, string strHCPResponse, string strCompanyFileName,  
            string qbXMLCountry, int qbXMLMajorVers, int qbXMLMinorVers)  
        {  
            if (Session["counter"] == null)  
            {  
                Session["counter"] = 0;  
            }  
            string evLogTxt = "WebMethod: sendRequestXML() has been called by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string ticket = " + ticket + "\r\n";  
            evLogTxt = evLogTxt + "string strHCPResponse = " + strHCPResponse + "\r\n";  
            evLogTxt = evLogTxt + "string strCompanyFileName = " + strCompanyFileName + "\r\n";  
            evLogTxt = evLogTxt + "string qbXMLCountry = " + qbXMLCountry + "\r\n";  
            evLogTxt = evLogTxt + "int qbXMLMajorVers = " + qbXMLMajorVers.ToString() + "\r\n";  
            evLogTxt = evLogTxt + "int qbXMLMinorVers = " + qbXMLMinorVers.ToString() + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
  
  
            ArrayList req = buildRequest();  
            string request = "";  
            int total = req.Count;  
            count = Convert.ToInt32(Session["counter"]);  
  
  
            if (count < total)  
            {  
                request = req[count].ToString();  
                evLogTxt = evLogTxt + "sending request no = " + (count + 1) + "\r\n";  
                Session["counter"] = ((int)Session["counter"]) + 1;  
            }  
            else  
            {  
                count = 0;  
                Session["counter"] = 0;  
                request = "";  
            }  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "string request = " + request + "\r\n";  
            logEvent(evLogTxt);  
            return request;  
        }  
        [WebMethod(Description = "This web method facilitates web service to receive response XML from QuickBooks via QBWebConnector", EnableSession = true)]  
        /// <summary>  
        /// WebMethod# 5 - receiveResponseXML()  
        /// Signature: public int receiveResponseXML(string ticket, string response, string hresult, string message)  
        ///  
        /// IN:  
        /// string ticket  
        /// string response  
        /// string hresult  
        /// string message  
        ///  
        /// OUT:  
        /// int retVal  
        /// Greater than zero  = There are more request to send  
        /// 100 = Done. no more request to send  
        /// Less than zero  = Custom Error codes  
        /// </summary>  
        public int receiveResponseXML(string ticket, string response, string hresult, string message)  
        {  
            string evLogTxt = "WebMethod: receiveResponseXML() has been called by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string ticket = " + ticket + "\r\n";  
            evLogTxt = evLogTxt + "string response = " + response + "\r\n";  
            evLogTxt = evLogTxt + "string hresult = " + hresult + "\r\n";  
            evLogTxt = evLogTxt + "string message = " + message + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
  
  
            int retVal = 0;  
            if (!hresult.ToString().Equals(""))  
            {  
                // if there is an error with the response received, web service could also return a -ve int  
  
                evLogTxt = evLogTxt + "HRESULT = " + hresult + "\r\n";  
                evLogTxt = evLogTxt + "Message = " + message + "\r\n";  
                retVal = -101;  
            }  
            else  
            {  
                evLogTxt = evLogTxt + "Length of response received = " + response.Length + "\r\n";  
  
  
                ArrayList req = buildRequest();  
                int total = req.Count;  
                int count = Convert.ToInt32(Session["counter"]);  
  
  
                int percentage = (count * 100) / total;  
                if (percentage >= 100)  
                {  
                    count = 0;  
                    Session["counter"] = 0;  
                }  
                retVal = percentage;  
            }  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "int retVal= " + retVal.ToString() + "\r\n";  
            logEvent(evLogTxt);  
            return retVal;  
        }  
  
  
        [WebMethod]  
        /// <summary>  
        /// WebMethod# 6 - getLastError()  
        /// Signature: public string getLastError(string ticket)  
        ///  
        /// IN:  
        /// string ticket  
        ///  
        /// OUT:  
        /// string retVal  
        /// Possible Values:  
        /// Error message describing last web service error  
        /// </summary>  
        public string getLastError(string ticket)  
        {  
            string evLogTxt = "WebMethod: getLastError() has been called by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string ticket = " + ticket + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
  
  
            int errorCode = 0;  
            string retVal = null;  
            if (errorCode == -101)  
            {  
                retVal = "QuickBooks was not running!"; // This is just an example of custom user errors  
            }  
            else  
            {  
                retVal = "Error!";  
            }  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "string retVal= " + retVal + "\r\n";  
            logEvent(evLogTxt);  
            return retVal;  
        }  
        [WebMethod]  
        /// <summary>  
        /// WebMethod# 7 - closeConnection()  
        /// At the end of a successful update session, QBWebConnector will call this web method.  
        /// Signature: public string closeConnection(string ticket)  
        ///  
        /// IN:  
        /// string ticket  
        ///  
        /// OUT:  
        /// string closeConnection result  
        /// </summary>  
        public string closeConnection(string ticket)  
        {  
            string evLogTxt = "WebMethod: closeConnection() has been called by QBWebconnector" + "\r\n\r\n";  
            evLogTxt = evLogTxt + "Parameters received:\r\n";  
            evLogTxt = evLogTxt + "string ticket = " + ticket + "\r\n";  
            evLogTxt = evLogTxt + "\r\n";  
            string retVal = null;  
  
  
            retVal = "OK";  
  
  
            evLogTxt = evLogTxt + "\r\n";  
            evLogTxt = evLogTxt + "Return values: " + "\r\n";  
            evLogTxt = evLogTxt + "string retVal= " + retVal + "\r\n";  
            logEvent(evLogTxt);  
            return retVal;  
        }  
 
 
        #endregion  
 
 
        #region UtilityMethods  
        private void initEvLog()  
        {  
            try  
            {  
                string source = "WCWebService";  
                if (!System.Diagnostics.EventLog.SourceExists(source))  
                    System.Diagnostics.EventLog.CreateEventSource(source, "Application");  
                evLog.Source = source;  
            }  
            catch { };  
            return;  
        }  
  
  
        private void logEvent(string logText)  
        {  
            try  
            {  
                evLog.WriteEntry(logText);  
            }  
            catch { };  
            return;  
        }  
  
  
        public ArrayList buildRequest()  
        {  
            string strRequestXML = "";  
            XmlDocument inputXMLDoc = null;  
  
  
            // CustomerQuery  
            inputXMLDoc = new XmlDocument();  
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));  
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbposxml", "version=\"1.0\""));  
  
  
            XmlElement qbposXML = inputXMLDoc.CreateElement("QBPOSXML");  
            inputXMLDoc.AppendChild(qbposXML);  
            XmlElement qbposXMLMsgsRq = inputXMLDoc.CreateElement("QBPOSXMLMsgsRq");  
            qbposXML.AppendChild(qbposXMLMsgsRq);  
            qbposXMLMsgsRq.SetAttribute("onError", "stopOnError");  
            XmlElement customerQueryRq = inputXMLDoc.CreateElement("CustomerQueryRq");  
            qbposXMLMsgsRq.AppendChild(customerQueryRq);  
            customerQueryRq.SetAttribute("requestID", "1");  
            XmlElement maxReturned = inputXMLDoc.CreateElement("MaxReturned");  
            customerQueryRq.AppendChild(maxReturned).InnerText = "1";  
  
  
            strRequestXML = inputXMLDoc.OuterXml;  
            req.Add(strRequestXML);  
  
  
            // Clean up  
            strRequestXML = "";  
            inputXMLDoc = null;  
            qbposXML = null;  
            qbposXMLMsgsRq = null;  
            maxReturned = null;  
  
  
            // ItemInventoryQuery  
            inputXMLDoc = new XmlDocument();  
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));  
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbposxml", "version=\"1.0\""));  
  
  
            qbposXML = inputXMLDoc.CreateElement("QBPOSXML");  
            inputXMLDoc.AppendChild(qbposXML);  
            qbposXMLMsgsRq = inputXMLDoc.CreateElement("QBPOSXMLMsgsRq");  
            qbposXML.AppendChild(qbposXMLMsgsRq);  
            qbposXMLMsgsRq.SetAttribute("onError", "stopOnError");  
            XmlElement itemInventoryQueryRq = inputXMLDoc.CreateElement("ItemInventoryQueryRq");  
            qbposXMLMsgsRq.AppendChild(itemInventoryQueryRq);  
            itemInventoryQueryRq.SetAttribute("requestID", "2");  
            maxReturned = inputXMLDoc.CreateElement("MaxReturned");  
            itemInventoryQueryRq.AppendChild(maxReturned).InnerText = "1";  
  
  
            strRequestXML = inputXMLDoc.OuterXml;  
            req.Add(strRequestXML);  
  
  
            // Clean up  
            strRequestXML = "";  
            inputXMLDoc = null;  
            qbposXML = null;  
            qbposXMLMsgsRq = null;  
            maxReturned = null;  
  
  
            // PurchaseOrderQuery  
            inputXMLDoc = new XmlDocument();  
            inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0", null, null));  
            inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbposxml", "version=\"1.0\""));  
  
  
            qbposXML = inputXMLDoc.CreateElement("QBPOSXML");  
            inputXMLDoc.AppendChild(qbposXML);  
            qbposXMLMsgsRq = inputXMLDoc.CreateElement("QBPOSXMLMsgsRq");  
            qbposXML.AppendChild(qbposXMLMsgsRq);  
            qbposXMLMsgsRq.SetAttribute("onError", "stopOnError");  
            XmlElement purchaseOrderQueryRq = inputXMLDoc.CreateElement("PurchaseOrderQueryRq");  
            qbposXMLMsgsRq.AppendChild(purchaseOrderQueryRq);  
            purchaseOrderQueryRq.SetAttribute("requestID", "3");  
            maxReturned = inputXMLDoc.CreateElement("MaxReturned");  
            purchaseOrderQueryRq.AppendChild(maxReturned).InnerText = "1";  
  
  
            strRequestXML = inputXMLDoc.OuterXml;  
            req.Add(strRequestXML);  
  
  
// InvoiceQuery  
//inputXMLDoc = new XmlDocument();  
//inputXMLDoc.AppendChild(inputXMLDoc.CreateXmlDeclaration("1.0",null, null));  
//          inputXMLDoc.AppendChild(inputXMLDoc.CreateProcessingInstruction("qbxml", "version=\"4.0\""));  
              
//          qbXML = inputXMLDoc.CreateElement("QBXML");  
//          inputXMLDoc.AppendChild(qbXML);  
//          qbXMLMsgsRq = inputXMLDoc.CreateElement("QBXMLMsgsRq");  
//          qbXML.AppendChild(qbXMLMsgsRq);  
//          qbXMLMsgsRq.SetAttribute("onError", "stopOnError");  
//          XmlElement invoiceQueryRq = inputXMLDoc.CreateElement("InvoiceQueryRq");  
//qbXMLMsgsRq.AppendChild(invoiceQueryRq);  
//          invoiceQueryRq.SetAttribute("requestID", "2");  
//          maxReturned=inputXMLDoc.CreateElement("MaxReturned");  
//          invoiceQueryRq.AppendChild(maxReturned).InnerText="1";  
              
//          strRequestXML = inputXMLDoc.OuterXml;  
//          req.Add(strRequestXML);  
  
  
            return req;  
        }  
        private string parseForVersion(string input)  
        {  
            // This method is created just to parse the first two version components  
            // out of the standard four component version number:  
            // <Major>.<Minor>.<Release>.<Build>  
            //  
            // As long as you get the version in right format, you could use  
            // any algorithm here.   
            string retVal = "";  
            string major = "";  
            string minor = "";  
            Regex version = new Regex(@"^(?\d+)\.(?\d+)(\.\w+){0,2}$", RegexOptions.Compiled);  
            Match versionMatch = version.Match(input);  
            if (versionMatch.Success)  
            {  
                major = versionMatch.Result("${major}");  
                minor = versionMatch.Result("${minor}");  
                retVal = major + "." + minor;  
            }  
            else  
            {  
                retVal = input;  
            }  
            return retVal;  
        }  
        #endregion  
    }  
} 