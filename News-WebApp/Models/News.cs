using System;
using System.ComponentModel.DataAnnotations;

namespace News_WebApp.Models
{
    public class News
    {
        /*
        This class should have five properties (NewsId,Title,Content,PublishedAt and UrlToImage).
        * Out of these five fields,
        * 1.the field NewsId returns a integer data type
        * 2.the field Title returns a string data type
        * 3.the filed Cotent returns a string data type
        * 4.the field PublishedAt returns a DateTime data type
        * 5.the field UrlToImage returns a string data type
       */
       [DataType(DataType.Text)]
       [Range(101,200,ErrorMessage ="Enter a value between 101 and 200")]
       [RegularExpression("^(0|[1-9][0-9]*)$",ErrorMessage ="Enter number")]
        public int NewsId { get; set; }
        
        [Required(ErrorMessage ="Title is mandatory")]
        public string Title{ get; set; }
        [Required(ErrorMessage ="Content is mandatory")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        
        [Required(ErrorMessage ="Published date is mandatory")]
        [DataType(DataType.Date)]
        [Display(Name = "Publishing Date")]
        public DateTime PublishedAt { get; set; }
        [Required(ErrorMessage ="Image is mandatory")]
        [Display(Name = "Select an image to upload")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.png|.jpg|.jpeg)$", ErrorMessage ="Upload an image")]
        //[DataType(DataType.ImageUrl)]
        public string UrlToImage { get; set; }
        public System.Collections.Generic.List<News> AllNews { get; set; }
    }
    
}
