using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitySecuritySmart.Entity;
using Google.Cloud.VideoIntelligence.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitySecuritySmart.Web.Controllers
{
    public class MonitoringController : ApiController
    {
		 [HttpGet]
        public async Task<IActionResult> Get()
        {
			var list = await Db.Monitors.ToListAsync();
            return Success(null, list);
        }
		int result = 0;
		[HttpPost]
        public async Task<IActionResult> Post([FromBody]CSSDMonitor value)
        {
			var userId = UserManager.GetUserId(User);
			if(string.IsNullOrEmpty(value.Name))
				return Error("Name is required.");
			
			var dataObject = new CSSDMonitor(){
				Name = value.Name,
				UserId = Guid.Parse(userId),
			};
			Uri baseUri = new Uri(@"gs://mts-bucket");
			Uri myUri = new Uri(baseUri, dataObject.Name);
			var client = VideoIntelligenceServiceClient.Create();
            var request = new AnnotateVideoRequest()
            {
				//deneme.mp4
                InputUri = myUri.ToString(),
                Features = { Feature.LabelDetection }
            };
            var op = client.AnnotateVideo(request).PollUntilCompleted();
            foreach (var Result in op.Result.AnnotationResults)
            {
                foreach (var annotation in Result.SegmentLabelAnnotations)
                {
					dataObject.Label = annotation.Entity.Description;
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