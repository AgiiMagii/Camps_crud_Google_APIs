using Google.Apis.Auth.OAuth2;
using Google.Apis.Forms.v1;
using Google.Apis.Forms.v1.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camps.Services
{
    public class GForms
    {
        private static FormsService _service;
        public GForms()
        {
            ServiceAccountCredential credential; // Load the service account credentials from the JSON file
            using (var stream = new FileStream("Config/testcamps-490318-460af90fabdc.json", FileMode.Open, FileAccess.Read)) // Path to your service account JSON file
            {
                credential = ServiceAccountCredential.FromServiceAccountData(stream); // Create the FormsService using the credentials
            }
            if (_service == null)
            {
                _service = new FormsService(new Google.Apis.Services.BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Camps"
                });
            }
        }
        public async Task<Google.Apis.Forms.v1.Data.Form> GetFormAsync(string formId)
        {
            try
            {
                var request = _service.Forms.Get(formId);
                return await request.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving form from Google Forms: {ex.Message}");
                return null;
            }

        }
        public async Task SyncQuestionOptionsToFormAsync(string formId, string questionId, List<string> data)
        {
            try
            {
                Form form = await GetFormAsync(formId);
                if (form == null)
                {
                    Console.WriteLine("Form not found.");
                    return;
                }
                Item questionItem = form.Items.FirstOrDefault(i => i.ItemId == questionId);
                if (questionItem == null)
                {
                    Console.WriteLine("Question not found in the form.");
                    return;
                }

                // Inicializē ChoiceQuestion un Options
                if (questionItem.QuestionItem.Question.ChoiceQuestion == null)
                    questionItem.QuestionItem.Question.ChoiceQuestion = new ChoiceQuestion();

                questionItem.QuestionItem.Question.ChoiceQuestion.Options = data
                    .Select(c => new Option { Value = c })
                    .ToList();
                int index = form.Items.ToList().FindIndex(i => i.ItemId == questionId);
                List<Request> requests = new List<Request>
                {
                    new Request
                    {
                        UpdateItem = new UpdateItemRequest
                        {
                            Item = questionItem,
                            Location = new Location
                            {
                                Index = index
                            },
                            UpdateMask = "questionItem.question.choiceQuestion.options"
                        }
                    }
                };

                BatchUpdateFormRequest batchRequest = new BatchUpdateFormRequest { Requests = requests };
                await _service.Forms.BatchUpdate(batchRequest, formId).ExecuteAsync();

                Console.WriteLine("Form options synced successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner: {ex.InnerException.Message}");
                }
            }
        }
    }
}
