using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook
{
    public class Newsfeed
    {
        public List<GetNewsFeed_Result> ListOfPosts { get; set; }
        public List<PB_POSTS> ListOfPostsTimeline { get; set; }
        public Newsfeed()
        {
            ListOfPosts = new List<GetNewsFeed_Result>() { };
            ListOfPostsTimeline = new List<PB_POSTS>() { };
        }
    }
}