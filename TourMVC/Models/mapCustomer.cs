using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourMVC.Models
{
    public class mapCustomer
    {
        TourManagementEntities db = new TourManagementEntities();

        public Customer TimKiem(string email)
        {
            try
            {
                TourManagementEntities db = new TourManagementEntities();
                var user = db.Customers.SingleOrDefault(m => m.Email.ToLower() == email.ToLower());
                return user;
            }
            catch
            {
                return null;
            }
        }
        public List<Customer> DanhSach()
        {
            var users = db.Customers.ToList();
            return users;
        }

        public void ThemMoi(string firstName, string lastName, string email, string phone, string password)
        {
            Customer tk = new Customer();
            tk.FirstName = firstName;
            tk.LastName = lastName;
            tk.Email = email;
            tk.Phone = phone;
            tk.Password = password;
            db.Customers.Add(tk);
            db.SaveChanges();
        }

        public bool ThemMoi(Customer tk)
        {
            try
            {
                db.Customers.Add(tk);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}