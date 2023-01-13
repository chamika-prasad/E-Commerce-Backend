﻿using Models;

namespace Assignment.Model
{
    public class NewOrder
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string userEmail { get; set; }
        public User User { get; set; }

        public int productId { get; set; }
        public Product product { get; set; }

        public int quantity { get; set; }

        public State state { get; set; }

    }

    public enum State
    {
        Pending,
        Accept,
        Decline,
    }
}
