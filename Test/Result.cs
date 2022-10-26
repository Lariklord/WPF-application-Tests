using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Result
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Time { get; set; }
        public string Valid { get; set; }
        public Result()
        {
        }
        public Result(String Login,String Time,String Valid)
        {
            this.Login = Login;
            this.Time = Time;
            this.Valid = Valid;
        }

    }
}
