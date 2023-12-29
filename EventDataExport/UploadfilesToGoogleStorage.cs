using System;
using System.Configuration;
using System.IO;

namespace UploadfilesToGoogleStorage
{
    class UploadfilesToGoogleStorage
    {
       
        static void Main(string[] args)
        {
           
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(UploadfilesToGoogleStorage));

            try
            {
                pushFiletoGCS();

            } catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private static void pushFiletoGCS()
        {
            using (new ExecutionTimeLogger())
            {
                string[] filePaths = Directory.GetFiles(ConfigurationSettings.AppSettings["FileStorageDirPath"]);
                string[] Scopes = new[] { @"https://www.googleapis.com/auth/devstorage.full_control" };
                log4net.Config.BasicConfigurator.Configure();
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(UploadfilesToGoogleStorage));

                try
                {
                    var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    string path = Environment.CurrentDirectory;
                    path = path.Replace(@"\bin\Debug", " ").Replace(@"\bin\Release", " ");
                    var storageService = Oauth2Authentication.GetStorageService(path + ConfigurationSettings.AppSettings["ClientScreat"], ConfigurationSettings.AppSettings["EmailAuthentication"], Scopes);
                    Google.Apis.Storage.v1.Data.Object fileInfo = new Google.Apis.Storage.v1.Data.Object();

                    foreach (var item in filePaths)
                    {
                        byte[] file = File.ReadAllBytes(item);

                        using (var streamOut = new MemoryStream(file))
                        {
                            fileInfo.Name = Path.GetFileName(item);
                            var response = InsertToGCS.Insert(storageService, ConfigurationSettings.AppSettings["BucketName"], fileInfo, streamOut);
                        }
                    }
                    log.Info(filePaths.Length + " files uploaded to GCS");
                } catch (Exception ex)
                {
                    log.Error("Failed to uplod to GCS - " + ex.Message);
                }
            }
        }

    }
}
