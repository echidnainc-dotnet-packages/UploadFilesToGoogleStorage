using Google.Apis.Storage.v1;
using Google.Apis.Upload;
using System;
using System.IO;

namespace UploadfilesToGoogleStorage
{
    class InsertToGCS
    {
        public static Google.Apis.Storage.v1.Data.Object Insert(StorageService service, string bucket, Google.Apis.Storage.v1.Data.Object body, Stream streamOut)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(UploadfilesToGoogleStorage));
            try
            {

                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");
                if (bucket == null)
                    throw new ArgumentNullException(bucket);

                // Building the initial request.
                var request = service.Objects.Insert(body, bucket, streamOut, "application/json; charset=UTF-8").Upload();

                // Applying optional parameters to the request.                
                //request = (ObjectsResource.InsertMediaUpload)SampleHelpers.ApplyOptionalParms(request, optional);
                if (request.Status == UploadStatus.Completed)
                {
                    log.Info(body.Name + " added");
                }
                else
                {
                    log.Error("Failed to upload :" + body.Name);
                }
                // Requesting data.
                return body;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw new Exception("Request Objects.Insert failed.", ex);
            }
        }

    }
}
