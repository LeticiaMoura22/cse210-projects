using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public void SetAuthor(string author)
        {
            _author = author;
        }

        public int GetLength()
        {
            return _lengthInSeconds;
        }

        public void SetLength(int lengthInSeconds)
        {
            _lengthInSeconds = lengthInSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }

        public int NumberOfComments()
        {
            return _comments.Count;
        }
    }
}
