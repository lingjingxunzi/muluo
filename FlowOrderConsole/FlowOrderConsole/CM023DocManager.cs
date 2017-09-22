using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FlowOrderConsole.Models;

namespace FlowOrderConsole
{
    public class CM023DocManager
    {
        private readonly Queue<OrderModels> documentQueue = new Queue<OrderModels>();

        public void AddDocument(OrderModels doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public OrderModels GetDocument()
        {
            OrderModels doc = null;
            lock (this)
            {
                try
                {

                 doc = documentQueue.Dequeue();

                }
                catch (Exception)
                {

                    
                }
            }
            return doc;
        }
        public bool IsDoctumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }

        public Thread t;
    }
}
