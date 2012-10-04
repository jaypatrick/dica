/*
* BSD License
* Copyright(c)2006, VelocIT, Inc.
* All rights reserved.
* Redistribution and use in source and binary forms,with or without
* modification, are permitted provided that the following conditions are met:
*
*
*  Redistributions of source code must retain the above copyright
*  notice,this list of conditionsandthefollowing disclaimer.
*  
*  Redistributions in binary form must reproduce the above copyright
*  notice,this list of conditions and the following disclaimer inthe
*  documentation and/or othermaterials provided withthedistribution.
*  
*  Neither the name of VelocIT nor the
*  names of its contributors may be used to endorse or promote products
*  derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY THE DEVELOPER AND CONTRIBUTORS ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL THE REGENTS AND CONTRIBUTORS BE LIABLE FOR ANY
* DIRECT, INDIRECT,INCIDENTAL,SPECIAL, EXEMPLARY,OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE,EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DigitallyImported.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plsUrl"></param>
        /// <returns></returns>
        public static string ParsePls(string plsUrl)
        {
            if (plsUrl.EndsWith(".asx"))
                return plsUrl;

            try
            {
                WebResponse webResponse = WebRequest.Create(plsUrl).GetResponse();

                using (StreamReader contentReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string pls = contentReader.ReadToEnd();
                    Regex http = new Regex(@"http://(.*)");

                    string url = http.Match(pls).Value;
                    //fix unix style line ending
                    if (url.EndsWith("\r")) url = url.Replace("\r", "");

                    try
                    {
                        WebResponse wres = WebRequest.Create(url).GetResponse();

                        //if aac+ stream replace http with icyxto playwith orban
                        if (wres.Headers.Get("content-type") == "audio/aacp")
                            url = url.Replace("http", "icyx");
                    }
                    catch
                    {
                        if (!flagWritten())
                        {
                            MessageBox.Show("Unable to check the stream for AAC+. " +
                                "Open PLS In WMP is unable to connect to this stream to check for AAC+. " +
                                "If the music still plays, this may mean that your firewall is preventing the program from connecting; " +
                                "please change your firewall settings to allow this program to access the internet if you would like AAC+ support. ",
                                "Open PLS In WMP - Connection Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            writeFlag();
                        }
                    }
                    finally
                    {
                        webResponse.Close();
                    }

                    if (url != string.Empty)
                        return url;
                    else
                    {
                        log("Streamnotfound");

                        //Unable tofindMP3serverstream URL.Show errormessage.
                        MessageBox.Show("Playlist error\n" +
                            "An error has been detected in the Playlist file. OpenPlsInWMP is unable to play this file.",
                            "Open PLS In WMP");

                        return string.Empty;
                    }
                }
            }
            catch (Exception e)
            {
                log(e.ToString());

                MessageBox.Show("Application error\n" +
                    "Ane rror has occurred. Please report the error here: " +
                    "http://tools.veloc-it.com/tabid/58/grm2id/7/Default.aspx" +
                    "Include this information in your error report:\n\n" + e.ToString(),
                    "Open PLS In WMP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return string.Empty;
        }

        static void log(string message)
        {
            try
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                {
                    using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream("OpenPlsInWMP.log", FileMode.Create, isoStore)))
                    { writer.Write(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + message); }
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message.ToString()); }
        }

        static bool flagWritten()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {

                return isoStore.GetFileNames("FirewallBlocked.txt").Length > 0;
            }
        }

        static void writeFlag()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream("FirewallBlocked.txt", FileMode.Create, isoStore)))
                { writer.Write(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")); }
            }
        }
    }
}