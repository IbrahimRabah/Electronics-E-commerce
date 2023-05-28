using dayOne.DTO;
using dayOne.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dayOne.Repositries
{
    public class ShipperRepository : Repository<Shipper, string>, IShipperRepository
    {
        private Context Context;
        private string confirmMessage = "Confirmed";
        private string regictMessage = "Regicted";
        private List<orderPure> Orderss=new List<orderPure>();
        public ShipperRepository(Context context  ) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(String id)
        {
            Shipper shipper = GetById(id);
            shipper.ApplicationUser.isDeleted = true;
            Context.SaveChanges();
        }

        public override IEnumerable<Shipper> GetAll(Func<Shipper, bool> predicate)
        {
            List<Shipper> ShippersList=  Context.Shipper.Include(e=>e.ApplicationUser).Include(e => e.orders).Where(predicate).ToList();
            return ShippersList;
        }


        public Shipper GetById(string id)
        {

            //return GetById(id);
          return Context.Shipper.Include(e => e.ApplicationUser).Include(e => e.orders).FirstOrDefault(e=>e.ApplicationUserId==id);

        }

        public void Edit(string id, Shipper newShipper)
        {
            Shipper oldShipper= GetById(id);
            oldShipper.ApplicationUser.FirstName = oldShipper.ApplicationUser.FirstName;
            oldShipper.ApplicationUser.LastName = oldShipper.ApplicationUser.LastName;
            oldShipper.ApplicationUser.Address = oldShipper.ApplicationUser.Address;
            oldShipper.ApplicationUser.isDeleted = oldShipper.ApplicationUser.isDeleted;
            oldShipper.Status = oldShipper.Status;
            oldShipper.Ssd = oldShipper.Ssd;
            oldShipper.LicenseImage = oldShipper.LicenseImage;
            Context.SaveChanges();
        }

        public string confirm(string id)
        {
            Shipper shipper = GetById(id);
            shipper.Status = status.confirmed;
            Context.SaveChanges();
            return confirmMessage;
        }

        public string reject(string id)
        {
            Shipper shipper = GetById(id);
            shipper.Status = status.rejected;
            Context.SaveChanges();
            return regictMessage;
        }

        public IEnumerable<orderPure> GetOrders(string ShId)
        {

            Shipper shipper = GetById(ShId);
            foreach(var o in shipper.orders.ToList())
            {
                if (o.isDeleted == false)
                {
                    Orderss.Add(new orderPure { CustomerId = o.CustomerId, Address = o.Address, Phone = o.Phone, ShipperId = o.ShipperId, TotalPrice = (int)o.TotalPrice, Id = o.Id });

                }
            }
            return Orderss;
        }
        public IEnumerable<Order> GetOrderNdto(string ShId)
        {

            Shipper shipper = GetById(ShId);
          return shipper.orders.ToList();
        }

        public void OrderDone(int orderId, string ShId)
        {
            IEnumerable<Order> order = GetOrderNdto(ShId);
            Order O = order.Where(o => o.Id == orderId).First();
            O.isDeleted = true;
            Context.SaveChanges();
            
        }
    }
}
