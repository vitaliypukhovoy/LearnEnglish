using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LearnEnglish.Models
{
    public class ContextDB:DbContext
    {
    public ContextDB()
        :base("DataWords")
    {
       // this.Configuration.LazyLoadingEnabled = false;
    }

    public DbSet<NewWord> NewWords { get; set; }
    public DbSet<Topic> Topics { get; set; }
    }
    public class NewWord
    {            
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set;}
        [Required]
        [StringLength(50,ErrorMessage="Should be  at least 50 characters")]
        public string Word { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Should be  at least 50 characters")]
        public string Translate { get; set; }
        public string Transcription { get; set; }
        public virtual Topic Topic { get; set; }
        public int IdTopic { get; set; }
    }

    public class Topic
    {
        [Key]
        [ScaffoldColumn(true)]
        public int IdTopic { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Should be  at least 50 characters")]
        public string TopicName { get; set; }
        public  virtual List<NewWord> NewWord { get; set; }
            
    }

    public class SubmitNewWord:NewWord
    { 
    
    }
    public class SubmitNewTopic : Topic
    {
    }
}