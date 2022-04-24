using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumEF.Data.Entities
{
    class Reservation
    {
        public int Id { get; set; }

        public Stadium Stadium { get; set; }
        public int StadiumId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
