using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Google.Cloud.VideoIntelligence.V1;
using System;


namespace CitySecuritySmart.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
			// var client = VideoIntelligenceServiceClient.Create();
            // var request = new AnnotateVideoRequest()
            // {
            //     InputUri = @"gs://mts-bucket/deneme.mp4",
            //     Features = { Feature.LabelDetection }
            // };
            // var op = client.AnnotateVideo(request).PollUntilCompleted();
            // foreach (var result in op.Result.AnnotationResults)
            // {
            //     foreach (var annotation in result.SegmentLabelAnnotations)
            //     {
            //         Console.WriteLine($"Video label: {annotation.Entity.Description}");
            //         foreach (var entity in annotation.CategoryEntities)
            //         {
            //             Console.WriteLine($"Video label category: {entity.Description}");
            //         }
            //         foreach (var segment in annotation.Segments)
            //         {
            //             Console.Write("Segment location: ");
            //             Console.Write(segment.Segment.StartTimeOffset);
            //             Console.Write(":");
            //             Console.WriteLine(segment.Segment.EndTimeOffset);
            //             System.Console.WriteLine($"Confidence: {segment.Confidence}");
            //         }
            //     }
            // }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>();
    }
}
