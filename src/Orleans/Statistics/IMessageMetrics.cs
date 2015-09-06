using Orleans.Runtime;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.Statistics
{
    public class IMessageMetrics
    {
        long MessageSentTotal { get; set; }
        long MessageReceiveTotal { get; set; }
        long LocalMessagesReceived { get; set;  }
        ConcurrentDictionary<string, long> PerSiloSendCounters { get; set; }
        ConcurrentDictionary<string, long> PerSiloReceiveCounters { get; set; }
    }
    public class MessageMetrics : IMessageMetrics
    {
        public long MessageSentTotal 
        { 
            get 
            { 
                return MessagingStatisticsGroup.MessagesSentTotal.GetCurrentValue(); 
            }
        }

        public long MessagesReceived
        {
            get
            {
                return  MessagingStatisticsGroup.MessagesReceived.GetCurrentValue();
            }
        }

        public long LocalMessagesReceived
        {
            get
            {
                var localMsSent = MessagingStatisticsGroup.LocalMessagesSent;
                return localMsSent!=null?localMsSent.GetCurrentValue():-1;
            }
        }

        public ConcurrentDictionary<string, long> PerSiloSendCounters
        {
            get
            {
                var perSiloMsgs = new ConcurrentDictionary<string, long>();
                foreach (var items in MessagingStatisticsGroup.perSiloSendCounters)
                {
                    perSiloMsgs[items.Key] = items.Value.GetCurrentValue();
                }
                return perSiloMsgs;
            }
        }

        public ConcurrentDictionary<string, long> PerSiloReceiveCounters
        {
            get
            {
                var perSiloMsgs = new ConcurrentDictionary<string, long>();
                foreach (var items in MessagingStatisticsGroup.perSiloReceiveCounters)
                {
                    perSiloMsgs[items.Key] = items.Value.GetCurrentValue();
                }
                return perSiloMsgs;
            }
        }

        //private static PerSocketDirectionStats[] perSocketDirectionStatsSend;
        //private static PerSocketDirectionStats[] perSocketDirectionStatsReceive;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloSendCounters;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloReceiveCounters;


        //internal static CounterStatistic MessagesSentTotal;
        //internal static CounterStatistic[] MessagesSentPerDirection;
        //internal static CounterStatistic TotalBytesSent;
        //internal static CounterStatistic HeaderBytesSent;

        //internal static CounterStatistic MessagesReceived;
        //internal static CounterStatistic[] MessagesReceivedPerDirection;
        //private static CounterStatistic totalBytesReceived;
        //private static CounterStatistic headerBytesReceived;

        //internal static CounterStatistic LocalMessagesSent;

        //internal static CounterStatistic[] FailedSentMessages;
        //internal static CounterStatistic[] DroppedSentMessages;
        //internal static CounterStatistic[] RejectedMessages;
        //internal static CounterStatistic[] ReroutedMessages;

        //private static CounterStatistic expiredAtSendCounter;
        //private static CounterStatistic expiredAtReceiveCounter;
        //private static CounterStatistic expiredAtDispatchCounter;
        //private static CounterStatistic expiredAtInvokeCounter;
        //private static CounterStatistic expiredAtRespondCounter;

        //internal static CounterStatistic ConnectedClientCount;

        //private static PerSocketDirectionStats[] perSocketDirectionStatsSend;
        //private static PerSocketDirectionStats[] perSocketDirectionStatsReceive;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloSendCounters;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloReceiveCounters;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloPingSendCounters;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloPingReceiveCounters;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloPingReplyReceivedCounters;
        //private static ConcurrentDictionary<string, CounterStatistic> perSiloPingReplyMissedCounters;

    }
}
