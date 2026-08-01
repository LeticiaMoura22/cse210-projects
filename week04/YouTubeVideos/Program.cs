using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Video 1
            Video video1 = new Video("Top 10 C# Tips for Beginners", "CodeWithClara", 612);
            video1.AddComment(new Comment("Marcus T.", "This finally made interfaces click for me!"));
            video1.AddComment(new Comment("Priya S.", "Great pacing, subscribed."));
            video1.AddComment(new Comment("DevDan", "Could you do one on LINQ next?"));
            videos.Add(video1);

            // Video 2
            Video video2 = new Video("Building a REST API in an Afternoon", "TechWithTasha", 1450);
            video2.AddComment(new Comment("Older_Coder", "Solid walkthrough, no fluff."));
            video2.AddComment(new Comment("Nia R.", "The error handling section was clutch."));
            video2.AddComment(new Comment("sam_dev", "Followed along and it actually worked!"));
            video2.AddComment(new Comment("Priya S.", "More of these please."));
            videos.Add(video2);

            // Video 3
            Video video3 = new Video("Unit Testing Explained Simply", "QAWithQuinn", 823);
            video3.AddComment(new Comment("Marcus T.", "Wish I'd watched this before my last project."));
            video3.AddComment(new Comment("Fatima K.", "Clear examples, thank you!"));
            video3.AddComment(new Comment("DevDan", "Mocking finally makes sense."));
            videos.Add(video3);

            // Video 4
            Video video4 = new Video("Git Branching Strategies", "GitGuyGreg", 940);
            video4.AddComment(new Comment("Nia R.", "The diagrams really helped."));
            video4.AddComment(new Comment("sam_dev", "Trunk-based vs Git Flow debate in the comments, lol."));
            video4.AddComment(new Comment("Fatima K.", "Saving this for my team."));
            videos.Add(video4);

            // Display every video and its comments
            foreach (Video video in videos)
            {
                Console.WriteLine("Title: " + video.GetTitle());
                Console.WriteLine("Author: " + video.GetAuthor());
                Console.WriteLine("Length (seconds): " + video.GetLength());
                Console.WriteLine("Number of Comments: " + video.NumberOfComments());
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine("  - " + comment.GetName() + ": " + comment.GetText());
                }

                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
