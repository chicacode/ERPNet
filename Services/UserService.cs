using ERPNet.Data;
using ERPNet.Entities;
using ERPNet.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Services
{
    public interface IUserService
    {
        User Authenticate ( string username, string password );
        IEnumerable<User> GetAll ( );
        User GetById ( int id );
        User Create ( User user, string password );
        void Update ( User user, string password = null );
        void Delete ( int id );
    }
    public class UserService : IUserService
    {
        private readonly ERPNetContext _context;

        public UserService ( ERPNetContext context )
        {
            _context = context;
        }
       public User Authenticate ( string username, string password )
        {
            if(string.IsNullOrEmpty ( username ) || string.IsNullOrEmpty ( password ))
                return null;

            var user = _context.Users.SingleOrDefault ( x => x.Username == username );

            // check if username exists
            if(user == null)
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<User> GetAll ( )
        {
            return _context.Users;
        }

        public User GetById ( int id )
        {
            return _context.Users.Find ( id );
        }

        public User Create ( User user, string password )
        {
            // validation
            if(string.IsNullOrWhiteSpace ( password ))
                throw new AppException ( "Password is required" );

            if(_context.Users.Any ( x => x.Username == user.Username ))
                throw new AppException ( "Username \"" + user.Username + "\" is already taken" );

            _context.Users.Add ( user );
            _context.SaveChanges ();

            return user;
        }


       public void Update ( User userParam, string password = null )
        {
            var user = _context.Users.Find ( userParam.Id );

            if(user == null)
                throw new AppException ( "User not found" );

            // update username if it has changed
            if(!string.IsNullOrWhiteSpace ( userParam.Username ) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if(_context.Users.Any ( x => x.Username == userParam.Username ))
                    throw new AppException ( "Username " + userParam.Username + " is already taken" );

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if(!string.IsNullOrWhiteSpace ( userParam.FirstName ))
                user.FirstName = userParam.FirstName;

            if(!string.IsNullOrWhiteSpace ( userParam.LastName ))
                user.LastName = userParam.LastName;

            _context.Users.Update ( user );
            _context.SaveChanges ();
        }

        public void Delete ( int id )
        {
            var user = _context.Users.Find ( id );
            if(user != null)
            {
                _context.Users.Remove ( user );
                _context.SaveChanges ();
            }
        }

    }
}
