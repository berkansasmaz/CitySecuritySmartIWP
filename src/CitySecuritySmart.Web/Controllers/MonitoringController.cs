using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitySecuritySmart.Entity;
using Google.Cloud.Storage.V1;
using Google.Cloud.VideoIntelligence.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitySecuritySmart.Web.Controllers
{
    public class MonitoringController : ApiController
    {
		List<string> listbuckets = new List<string>();
		private List<string> ListBucket(string bucketName)
		{
			var storage = StorageClient.Create();
			foreach (var storageObject in storage.ListObjects(bucketName, ""))
			{
				listbuckets.Add(storageObject.Name);	
			}
			return  listbuckets;
		}
	 	[HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute]Guid? id)
        {
            if (id.HasValue)
            {
                if (id.Value == Guid.Empty)
                {
                    return Error("You must send monitor id to get.");
                }
                var monitor = await Db.Monitors.FirstOrDefaultAsync(x => x.MonitorId == id.Value && x.UserId == UserId);
                if (monitor == null)
                    return Error("Monitor not found.", code: 404);

                return Success(data: new
                {
                    monitor.MonitorId,
					monitor.UserId,
                    monitor.Uri,
                    monitor.Url,
                    monitor.Name,
                    monitor.Label,
                    monitor.LabelCategory,
                    monitor.StartTimeOffset,
                    monitor.EndTimeOffset,
					monitor.Confidence
                });
            }
			var videoList = ListBucket("mts-bucket");
	
            var list = await Db.Monitors.ToListAsync();
            return Success(null, list,videoList);
        }
		
		
		int result = 0;
		[HttpPost]
        public async Task<IActionResult> Post([FromBody]CSSDMonitor value)
        {
			var DangerList = await Db.DangerLabels.ToListAsync();
			List<string> DangerName = new List<string>();
			foreach (var item in DangerList)
			{
				 DangerName.Add(item.DangerLabelName);
			} 
			var userId = UserManager.GetUserId(User);
			if(string.IsNullOrEmpty(value.Name))
				return Error("Name is required.");
			
			var dataObject = new CSSDMonitor(){
				Name = value.Name,
				UserId = Guid.Parse(userId),
			};
			Uri videoBaseUri = new Uri(@"gs://mts-bucket");
			Uri previewBaseUrl = new Uri(@"https://storage.cloud.google.com/mts-bucket/");
			Uri bucketUri = new Uri(videoBaseUri, dataObject.Name);
			Uri previewUrl = new Uri(previewBaseUrl, dataObject.Name);
			dataObject.Uri = bucketUri.ToString();
			dataObject.Url = previewUrl.ToString();
			var client = VideoIntelligenceServiceClient.Create();
            var request = new AnnotateVideoRequest()
            {
				//deneme.mp4
                InputUri = bucketUri.ToString(),
                Features = { Feature.LabelDetection }
            };
            var op = client.AnnotateVideo(request).PollUntilCompleted();
            foreach (var Result in op.Result.AnnotationResults)
            {
                foreach (var annotation in Result.SegmentLabelAnnotations)
                {
					dataObject.Label = annotation.Entity.Description;
					if (DangerName.Contains(dataObject.Label))
					{
						Console.WriteLine(dataObject.Label+"============?=====================================\n\n");
						dataObject.DangerLevel = 1;
					}
                    Console.WriteLine($"Video label: {annotation.Entity.Description}");
                    foreach (var entity in annotation.CategoryEntities)
                    {
						 dataObject.LabelCategory = entity.Description;
                        Console.WriteLine($"Video label category: {entity.Description}");
                    }
                    foreach (var segment in annotation.Segments)
                    {
						 dataObject.StartTimeOffset = segment.Segment.StartTimeOffset.ToString();
                        Console.Write("Segment location: ");
                        Console.Write(segment.Segment.StartTimeOffset);
                        Console.Write(":");
						 dataObject.EndTimeOffset = segment.Segment.EndTimeOffset.ToString();
                        Console.WriteLine(segment.Segment.EndTimeOffset);
						 dataObject.Confidence = segment.Confidence;
                        System.Console.WriteLine($"Confidence: {segment.Confidence}");
						dataObject.MonitorId = new Guid();
						Db.Monitors.Add(dataObject); 
						result = await Db.SaveChangesAsync();
                    }
                }
            }
				if(result > 0)
					return Success("Monitoring saved successfully");
				else
					return Error("Something is wrong with your model.");
	   }
	}
}