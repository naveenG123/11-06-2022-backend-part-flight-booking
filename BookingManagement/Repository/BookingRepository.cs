using BookingManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _Context;
        //private UserDetailTbl detailTbl;

        public BookingRepository(BookingDbContext context)
        {
            _Context = context;
        }

        public void AddBookingDetail(BookflightTbl tbl)
        {
            try
            {
                _Context.BookflightTbls.Add(tbl);
                _Context.SaveChanges();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void AddBookingDetail(BookflightTblUsr tbl)
        //{
        //    throw new NotImplementedException();
        //}

        //public string AddBookingDetail(Model.BookflightTblUsr tbl)
        //{
        //    string pnr = String.Empty;
        //    string userpnr = String.Empty;
        //    try
        //    {
        //        foreach (var item in tbl.users)
        //        {
        //            BookflightTbl bookflight = new BookflightTbl();
        //            bookflight.EmailId = tbl.EmailId;
        //            bookflight.FlightNumber = tbl.FlightNumber;
        //            bookflight.Meal = tbl.Meal;
        //            bookflight.Name = tbl.Name;
        //            Random generateRandom = new Random();
        //            int people = generateRandom.Next(1, 1000);
        //            bookflight.peopleid = people;
        //            bookflight.Id = generateRandom.Next(1, 1000); ;
        //            //if (tbl != null)
        //            //    tbl.Pnr = userpnr;
        //            var bookingtblres = _Context.BookflightTbls.FirstOrDefault(x => x.FlightNumber == tbl.FlightNumber && x.peopleid == people);
        //            if (bookingtblres != null)
        //                throw new Exception(" User already booked ticket for flight " + tbl.FlightNumber);
        //            _Context.BookflightTbls.Add(bookflight);
        //            int p = generateRandom.Next(1, 1000);
        //            bookflight.Pnr = "PNR" + p.ToString();
        //            userpnr = userpnr + bookflight.Pnr + "  " + item.FirstName + " " + item.LastName + "\n";
        //            _Context.SaveChanges();
        //            UserDetailTbl detailTbl = new UserDetailTbl();
        //            detailTbl.FirstName = item.FirstName;
        //            detailTbl.Gender = item.Gender;
        //            detailTbl.LastName = item.LastName;
        //            detailTbl.PeopleId = people;
        //            detailTbl.Class = item.Class;
        //            detailTbl.Age = item.Age;
        //            _Context.UserDetailTbls.Add(detailTbl);
        //            _Context.SaveChanges();
        //            pnr = userpnr;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return pnr;
        //}



        public void CancelBooking(int id)
        {

            try
            {
                var bookflight = _Context.BookflightTbls.Find(id);
                if (bookflight != null)
                {
                    _Context.BookflightTbls.Remove(bookflight);
                    SaveChanges();
                    return ;
                   
                }
                throw new System.Exception("Failed to delete the Booking");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public IEnumerable<BookflightTbl> GetBookingDetail()
        {
            try
            {
                var res = _Context.BookflightTbls.ToList();
                if (res.Count == 0)
                    throw new Exception("No booking found");
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TicketDetail> GetBookingDetailFromPNR(string pnr)
        {
            return (IEnumerable<TicketDetail>)_Context.BookflightTbls.FirstOrDefault(x => x.Pnr == pnr);
        }

        //public IEnumerable<TicketDetail> GetBookingDetailFromPNR(string pnr)
        //{
        //    List<TicketDetail> res = new List<TicketDetail>();
        //    try
        //    {

        //        var bookflights = _Context.BookflightTbls.Where(x => x.Pnr.ToLower() == pnr.ToLower()).ToList<BookflightTbl>();

        //        foreach (var item in bookflights)
        //        {
        //            var inventory = _Context.InventoryTbls.Where(x => x.FlightNo.ToLower().Trim() == item.FlightNumber.ToLower().Trim()).ToList();
        //            var person = _Context.UserDetailTbls.Where(x => x.PeopleId == item.peopleid).ToList();
        //            TicketDetail data = new TicketDetail();
        //            data.FlightNumber = item.FlightNumber;
        //            data.FirstName = person[0].FirstName;
        //            data.LastName = person[0].LastName;
        //            data.Meal = item.Meal;
        //            data.Pnr = item.Pnr;
        //            data.Emailid = item.EmailId;
        //            //data.ScheduleDays = inventory[0].ScheduleDays;
        //            //data.startDateTime = inventory[0].startDateTime;
        //            //data.endDateTime = inventory[0].endDateTime;
        //            res.Add(data);
        //        }
        //        if (res.Count == 0)
        //            throw new Exception("PNR " + pnr + " is not exists. Failed to cancel the ticket");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return res;
        //}

        public IEnumerable<TicketDetail> GetUserHistory(string emailId)
        {
            throw new NotImplementedException();
        }

        //public void SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
    

        //public IEnumerable<TicketDetail> GetUserHistory(string emailId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Model.TicketDetail> GetBookingDetailFromPNR(string pnr)
        //{
        //    List<TicketDetail> res = new List<TicketDetail>();
        //    try
        //    {

        //        var bookflights = _Context.BookflightTbls.Where(x => x.Pnr.ToLower() == pnr.ToLower()).ToList<BookflightTbl>();

        //        foreach (var item in bookflights)
        //        {
        //            var inventory = _Context.InventoryTbls.Where(x => x.FlightNumber.ToLower().Trim() == item.FlightNumber.ToLower().Trim()).ToList();
        //            var person = _Context.UserDetailTbls.Where(x => x.PeopleId == item.peopleid).ToList();
        //            TicketDetail data = new TicketDetail();
        //            data.FlightNumber = item.FlightNumber;
        //            data.FirstName = person[0].FirstName;
        //            data.LastName = person[0].LastName;
        //            data.Meal = item.Meal;
        //            data.Pnr = item.Pnr;
        //            data.Emailid = item.EmailId;
        //            data.ScheduleDays = inventory[0].ScheduleDays;
        //            data.startDateTime = inventory[0].startDateTime;
        //            data.endDateTime = inventory[0].endDateTime;
        //            res.Add(data);
        //        }
        //        if (res.Count == 0)
        //            throw new Exception("PNR " + pnr + " is not exists. Failed to cancel the ticket");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return res;
        //}

        //public IEnumerable<Model.TicketDetail> GetUserHistory(string emailId)
        //{
        //    //List<TicketDetail> res = new List<TicketDetail>();
        //    //try
        //    //{
        //    //    var flight = _Context.BookflightTbls.Where(x => x.EmailId.ToLower() == emailId.ToString().ToLower()).
        //    //       ToList();
        //    //    for (int i = 0; i < flight.Count; i++)
        //    //    {
        //    //        int count = 0;
        //    //        var inventory = _Context.InventoryTbls.Where(x => x.FlightNumber.ToLower().Trim() == flight[i].FlightNumber.ToLower().Trim()).ToList();
        //    //        var person = _Context.UserDetailTbls.Where(x => x.PeopleId == flight[i].peopleid).ToList();
        //    //        TicketDetail data = new TicketDetail();
        //    //        data.FlightNumber = flight[i].FlightNumber;
        //    //        data.FirstName = person[count].FirstName;
        //    //        data.LastName = person[count].LastName;
        //    //        data.Meal = flight[i].Meal;
        //    //        data.Pnr = flight[i].Pnr;
        //    //        data.Emailid = flight[i].EmailId;
        //    //        data.ScheduleDays = inventory[count].ScheduleDays;
        //    //        data.startDateTime = inventory[count].startDateTime;
        //    //        data.endDateTime = inventory[count].endDateTime;
        //    //        res.Add(data);
        //    //        count++;
        //    //    }
        //    //    if (res.Count == 0)
        //    //        throw new Exception("No history found for emailid " + emailId);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw new Exception(ex.Message);
        //    //}
        //    //return res;
        //}

        public void SaveChanges()
        {
            try
            {
                _Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Failed to save db " + ex.Message);
            }
        }
    }
}