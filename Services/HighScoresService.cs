
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using AWSServerlessHighScoresAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessHighScoresAPI.Services
{
    public class HighScoresService: IHighScoresService
    {
        private IEnumerable<GameRecord> highscores;
        private IEnumerable<GameRecord2> highscores2;
        private IEnumerable<GameRecord3> highscores3;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUWest1;
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient(bucketRegion);


        //==================DYNAMO DB SERVICES FOR SNAKE GAME=============================================================================
        public async Task <IEnumerable<GameRecord>> GetItemsFromDynamoDBTable1()
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig
            {
                ConsistentRead = false,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (DynamoDBContext context = new DynamoDBContext(client, config))
            {
                // you can add scan conditions, or leave empty
                var conditions = new List<ScanCondition>();  
                 highscores = await context.ScanAsync<GameRecord>(conditions).GetRemainingAsync();
            }
            return highscores;
        }

        public async Task AddItemToDynamoDBTable1(GameRecord record)
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig
            {
                ConsistentRead = false,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (DynamoDBContext context = new DynamoDBContext(client, config))
            {
                await context.SaveAsync(record);
            }


        }

        //==================DYNAMO DB SERVICES FOR MSWEEPER GAME=============================================================================
        public async Task<IEnumerable<GameRecord2>> GetItemsFromDynamoDBTable2()
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig
            {
                ConsistentRead = false,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (DynamoDBContext context = new DynamoDBContext(client, config))
            {
                // you can add scan conditions, or leave empty
                var conditions = new List<ScanCondition>();
                highscores2 = await context.ScanAsync<GameRecord2>(conditions).GetRemainingAsync();
            }
            return highscores2;
        }


        public async Task AddItemToDynamoDBTable2(GameRecord2 record)
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig
            {
                ConsistentRead = false,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (DynamoDBContext context = new DynamoDBContext(client, config))
            {
                await context.SaveAsync(record);
            }


        }

        //==================DYNAMO DB SERVICES FOR TETRIS GAME=============================================================================
        public async Task<IEnumerable<GameRecord3>> GetItemsFromDynamoDBTable3()
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig
            {
                ConsistentRead = false,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (DynamoDBContext context = new DynamoDBContext(client, config))
            {
                // you can add scan conditions, or leave empty
                var conditions = new List<ScanCondition>();
                highscores3 = await context.ScanAsync<GameRecord3>(conditions).GetRemainingAsync();
            }
            return highscores3;
        }


        public async Task AddItemToDynamoDBTable3(GameRecord3 record)
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig
            {
                ConsistentRead = false,
                Conversion = DynamoDBEntryConversion.V2
            };

            using (DynamoDBContext context = new DynamoDBContext(client, config))
            {
                await context.SaveAsync(record);
            }


        }
    }
}
