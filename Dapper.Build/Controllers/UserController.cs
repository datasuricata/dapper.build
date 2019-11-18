using System;
using System.Threading.Tasks;
using Dapper.Build.Commands;
using Dapper.Build.Data.Repository.Base;
using Dapper.Build.Handlers;
using Dapper.Build.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Build.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class UserController : ControllerBase {
        private readonly IRepository<User> _user;
        private readonly IRepository<Address> _address;

        public UserController (IRepository<User> user, IRepository<Address> address) {
            _user = user;
            _address = address;
        }

        [HttpGet ("seed")]
        public async Task<IActionResult> Seeder () {
            try {
                var address1 = new Address ("Rua 01");
                var address2 = new Address ("Rua 02");
                var address3 = new Address ("Rua 03");

                await _address.Insert (address1);
                await _address.Insert (address2);
                await _address.Insert (address3);

                var user1 = new User ("Lucas", "lucas@gmail.com", address1.Id);
                var user2 = new User ("Daniel", "daniel@gmail.com", address2.Id);
                var user3 = new User ("Garcia", "garcia@gmail.com", address3.Id);

                await _user.Insert (user1);
                await _user.Insert (user2);
                await _user.Insert (user3);

                return Ok ("Populado");

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpGet ("name/{param}")]
        public async Task<IActionResult> ByName (string param) {
            try {
                return Ok (await _user.By (u => u.Name.Equals (param, StringComparison.InvariantCultureIgnoreCase)));
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpGet ("list")]
        public async Task<IActionResult> List () {
            try {
                return Ok (await _user.List ());
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpGet ("list/{param}")]
        public async Task<IActionResult> ListBy (bool param) {
            try {
                return Ok (await _user.ListBy (u => param));
            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpGet ("dynamic")]
        public async Task<IActionResult> Dynamic () {
            try {
                return Ok (await _user.QueryAsync ("select * from users"));

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpPost ("subscribe")]
        public async Task<IActionResult> Subscribe ([FromBody] UserSubscriptionCommand model) {
            try {
                var handler = new SubscriptionHandler (_user, _address);
                return Ok (await handler.Handle (model));

            } catch (Exception ex) {
                return BadRequest (ex.Message);
            }
        }
    }
}