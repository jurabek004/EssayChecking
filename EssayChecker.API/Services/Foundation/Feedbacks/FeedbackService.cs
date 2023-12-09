using System;
using System.Linq;
using System.Threading.Tasks;
using EssayChecker.API.Brokers.Loggings;
using EssayChecker.API.Brokers.Storages;
using EssayChecker.API.Models.Foundation.Feedbacks;
using EssayChecker.API.Models.Foundation.Feedbacks.Exceptions;

namespace EssayChecker.API.Services.Foundation.Feedbacks;

public partial class FeedbackService : IFeedbackService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public FeedbackService(IStorageBroker storageBroker, 
        ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public ValueTask<Feedback> AddFeedbackAsync(Feedback feedback) =>
        TryCatch(async () =>
        {
            ValidateFeedbackOnAdd(feedback);
            return await storageBroker.InsertFeedbackAsync(feedback);
        });

    public IQueryable<Feedback> RetrieveAllFeedbacks()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}