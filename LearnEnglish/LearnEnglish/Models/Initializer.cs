using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LearnEnglish.Models
{
    public class Initializer : CreateDatabaseIfNotExists<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {

                var worlds = new List<Topic>{

             new Topic {IdTopic=1,TopicName="Sport"},
             new Topic {IdTopic=2,TopicName ="Weather"},
             new Topic {IdTopic=3,TopicName="Politic"},
             new Topic {IdTopic=4,TopicName="Peace"}                                     
            };
                worlds.ForEach(s => context.Topics.Add(s));                                    
        }

    }
}