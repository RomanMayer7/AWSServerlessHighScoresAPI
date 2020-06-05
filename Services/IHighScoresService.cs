using AWSServerlessHighScoresAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessHighScoresAPI.Services
{
    public interface IHighScoresService
    {

        public Task<IEnumerable<GameRecord>> GetItemsFromDynamoDBTable1();
        public Task<IEnumerable<GameRecord2>> GetItemsFromDynamoDBTable2();
        public Task<IEnumerable<GameRecord3>> GetItemsFromDynamoDBTable3();

        public  Task AddItemToDynamoDBTable1(GameRecord record);
        public Task AddItemToDynamoDBTable2(GameRecord2 record);
        public Task AddItemToDynamoDBTable3(GameRecord3 record);

    }
}
