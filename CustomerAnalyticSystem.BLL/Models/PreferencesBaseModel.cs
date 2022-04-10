﻿namespace CustomerAnalyticSystem.BLL.Models
{
    public class PreferencesBaseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int TagId { get; set; }
        public int GroupId { get; set; }
        public bool IsInterested { get; set; }
    }
}
