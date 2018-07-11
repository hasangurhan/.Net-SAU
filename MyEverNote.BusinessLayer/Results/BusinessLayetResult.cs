using MyEverNote.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.BusinessLayer.Results
{
    public class BusinessLayetResult <T> where T : class
    {
        public List<ErrorMessageObj> Errors { get; set; } // hata mesajı burda
        public T Result { get; set; } //  başarılı ise sonucu bu properyde

        public BusinessLayetResult()
        {
            Errors = new List<ErrorMessageObj>();
            
        }
        public void AddError(ErrorMessageCode code , string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }

        internal void AddError(object userCouldNotUpdated, string v)
        {
            throw new NotImplementedException();
        }
    }
}
