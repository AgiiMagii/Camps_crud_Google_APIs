using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Services
{
    public class Sheets
    {
        private static SheetsService _service;

        public Sheets()
        {
            string[] scopes = { SheetsService.Scope.Spreadsheets };

            ServiceAccountCredential credential; // Load the service account credentials from the JSON file
            using (var stream = new FileStream("Config/testcamps-490318-460af90fabdc.json", FileMode.Open, FileAccess.Read)) // Path to your service account JSON file
            {
                credential = ServiceAccountCredential.FromServiceAccountData(stream); // Create the SheetsService using the credentials
            }

            if (_service == null)
            {
                _service = new SheetsService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Camps"
                });
            }
        }

        public async Task<IList<IList<object>>> GetRangeAsync(string spreadsheetId, string range)
        {
            try
            {
                var request = _service.Spreadsheets.Values.Get(spreadsheetId, range);
                ValueRange response = await request.ExecuteAsync(); // ← sagaida ValueRange
                return response.Values ?? new List<IList<object>>(); // ← ja null, atgriež tukšu sarakstu
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data from Google Sheets: {ex.Message}");
                return new List<IList<object>>(); // ← nekad neatsauc null, lai vieglāk mapot
            }
        }

        public async Task MarkRowAsProcessed(string spreadsheetId, string sheetName, int rowIndex)
        {
            try
            {
                string range = $"{sheetName}!U{rowIndex}";

                var valueRange = new ValueRange
                {
                    Values = new List<IList<object>>
                    {
                        new List<object> { "Processed" }
                    }
                };

                var request = _service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
                request.ValueInputOption =
                    SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

                await request.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error marking row processed: {ex.Message}");
            }
        }
    }
}
