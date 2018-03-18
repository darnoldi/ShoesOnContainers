using CartApi;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
//using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShoesOnContainers.Services.CartApi.Model
{
    public class RedisCartRepositoryOld : ICartRepository
    {
        private ILogger<RedisCartRepositoryOld> _logger;
        private     CartSettings _settings;

        private ConnectionMultiplexer _redis;


        public RedisCartRepositoryOld(IOptionsSnapshot<CartSettings> options, ILoggerFactory loggerFactory/*, ConnectionMultiplexer multiplexer*/)
        {
            _settings = options.Value;
            _logger = loggerFactory.CreateLogger<RedisCartRepositoryOld>();
            //_redis = multiplexer;
            _logger.LogInformation("Redis instance :" + _redis);
        }

        public async Task<bool> DeleteCartAsync(string id)
        {
            var database = await GetDatabase();
            _logger.LogInformation("Redis Delete method");
            _logger.LogInformation("Redis Delete :"+ id.ToString());
            return await database.KeyDeleteAsync(id.ToString());
        }

        public async Task<IEnumerable<string>> GetCartsAsync()
        {
            var server = await GetServer();
          

            IEnumerable<RedisKey> data = server.Keys();
            if (data == null)
            {
                return null;
            }
            return data.Select(k => k.ToString());
        }

        public async Task<Cart> GetCartAsync(string cartId)
        {
             var database = await GetDatabase();
            
            var data = await database.StringGetAsync(cartId.ToString());

            if (data.IsNullOrEmpty)
            {
                return null;
                
                
            }
            _logger.LogInformation("Data null gelmememiş: "+data.ToString());
            return JsonConvert.DeserializeObject<Cart>(data);
        }

        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            var database = await GetDatabase();
          
            var created = await database.StringSetAsync(cart.BuyerId, JsonConvert.SerializeObject(cart));
            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the item.");
                return null;
            }

            _logger.LogInformation("Basket item persisted succesfully.");

            return await GetCartAsync(cart.BuyerId);
        }

        private async Task<IDatabase> GetDatabase()
        {
            _logger.LogInformation("****REDIS 1****!");
             
            if (_redis == null)
            {

                await ConnectToRedisAsync();
                _logger.LogInformation("New redis Connection done");

            }
          
            return _redis.GetDatabase();
        }


        private async Task<IServer> GetServer()
        {
            if (_redis == null)
            {
                await ConnectToRedisAsync();
            }
            var endpoint = _redis.GetEndPoints();

            return  _redis.GetServer(endpoint.First());
        }

        private async Task ConnectToRedisAsync()
        {
            var configuration = ConfigurationOptions.Parse(_settings.ConnectionString, true);
            configuration.ResolveDns = true;
            configuration.AbortOnConnectFail = false;
            //configuration.ConnectTimeout = 10000;
            //configuration.ConnectRetry = 5;
            //configuration.AllowAdmin = true;
            _logger.LogInformation("*****REDIS 2****");
            _logger.LogInformation($"Connecting to database {configuration.SslHost}.");
             _redis = await ConnectionMultiplexer.ConnectAsync(configuration);
            //_redis = Connection;
        }

        public IEnumerable<string> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
